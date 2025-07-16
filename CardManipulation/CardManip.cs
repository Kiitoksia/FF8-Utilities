using CardManipulation.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace CardManipulation
{
    public class CardManip
    {
        public List<Card> CardTable { get; }
        public Dictionary<string, PlayerProfile> PlayerProfiles { get; }
        public Options Options { get; set; }

        public CardManip()
        {
            CardTable = Const.CreateCardTable();
            PlayerProfiles = Const.CreatePlayerProfiles();
            Options = Options.Default();
        }

        public async Task RareTimerAsync(uint state, string playerKey, SearchType searchType, Action<RareTimerResult> onTick, CancellationToken token, int fps = 60, int count = 0)
        {
            // Advance RNG by count if needed
            if (count > 0)
            {
                var rng = new CardRng(state);
                for (int i = 0; i < count; i++) rng.Next();
                state = rng.State;
            }

            var start = DateTime.Now.SecondsSinceEpoch();
            while (!token.IsCancellationRequested)
            {
                double current = DateTime.Now.SecondsSinceEpoch();
                double elapsed = current - start;
                var result = GetRareTimerStep(state, playerKey, elapsed, searchType);
                onTick?.Invoke(result);
                await Task.Delay(1000 / fps, token);
            }
        }

        public RareTimerResult GetRareTimerStep(
            uint state,
            string playerKey,
            double elapsedSeconds,
            SearchType searchType = SearchType.First,
            int count = 0)
        {

            // Advance RNG by count if needed
            if (count > 0)
            {
                var rng = new CardRng(state);
                for (int i = 0; i < count; i++) rng.Next();
                state = rng.State;
            }
            int tableWidth = 600;
            var fps = Options.ConsoleFps;

            var delay = Options.DelayFrame / Options.GameFps;

            var incr = 0U;
            var incrStart = delay - (Options.ForcedIncr / Options.GameFps);


            incr = (uint)Math.Max(
                Math.Round((elapsedSeconds - incrStart) * Options.GameFps),
                Options.ForcedIncr + Options.AcceptDelayFrame
            );

            if (incr <= Options.ForcedIncr + Options.AcceptDelayFrame)
            {
                incr = Options.ForcedIncr;
            }
            var player = PlayerProfiles[playerKey];


            var rareTbl = new int[tableWidth].Select((_, idx) => NextRare(state + incr + (uint)idx, player.RareLimit));

            return new RareTimerResult
            {
                Incr = (int)incr,
                RareTable = rareTbl.ToList(),
                DurationSeconds = elapsedSeconds
            };
        }

        public PatternParseResult ParsePattern(string input, string playerKey, bool fuzzyRanks = false)
        {
            var player = PlayerProfiles[playerKey];
            var rare = player.Rares.FirstOrDefault();
            var ranksArr = Regex.Matches(input, @"[0-9aA]{4}")
                                .Cast<Match>().Select(m => m.Value).Take(5).ToList();

            if (ranksArr.Count < (rare == 0 ? 5 : 4))
                return new PatternParseResult { Error = $"There are not 4 or more cards: {input}" };

            // Initiative: last + or - in string
            bool? initiative = null;
            //foreach (Match m in Regex.Matches(input, @"[+-]"))
            //    initiative = m.Value == "+";


            // Custom ranks order (default: "urdl")
            var order = Options.RanksOrder ?? "ulrd";
            var customOrder = "urdl".Select(c => order.IndexOf(c)).ToArray();

            // Convert to urdl arrays
            var urdlArr = ranksArr.Select(ranks =>
            {
                var nums = ranks.ToLower().Select(c =>
                {
                    int n = Convert.ToInt32(c.ToString(), 16);
                    return n == 0 ? 10 : n;
                }).ToArray();
                return customOrder.Select(idx => nums[idx]).ToArray();
            }).ToList();

            // Find matching card IDs for each urdl
            List<List<int>> idsArr = urdlArr.Select(urdl =>
                CardTable.Where(card =>
                    fuzzyRanks
                        ? card.Urdl.OrderBy(x => x).SequenceEqual(urdl.OrderBy(x => x))
                        : card.Urdl.SequenceEqual(urdl)
                ).Select(card => card.Id).ToList()
            ).ToList();

            // Error if any are empty
            if (idsArr.Any(ids => ids.Count == 0))
            {
                var emptyIdx = idsArr.FindIndex(ids => ids.Count == 0);
                return new PatternParseResult
                {
                    Error = $"There is no card corresponding to ranks: #{emptyIdx + 1}:{ranksArr[emptyIdx]}"
                };
            }

            // Error if duplicates (non-fuzzy)
            if (!fuzzyRanks)
            {
                var seen = new HashSet<string>();
                foreach (var ids in idsArr)
                {
                    var key = string.Join(",", ids);
                    if (!seen.Add(key))
                        return new PatternParseResult { Error = $"Duplicated Cards: {key}" };
                }
            }

            // If only 4, insert rare at front
            if (idsArr.Count == 4)
                idsArr.Insert(0, new List<int> { rare });

            return new PatternParseResult
            {
                Raw = input,
                Deck = idsArr,
                Initiative = initiative
            };
        }

        private bool NextRare(uint state, int rareLimit)
        {
            var nextRnd = ((state * 0x10dcd + 1) & 0xffffffff) >> 17;
            return nextRnd % 100 < rareLimit;
        }

        IList<TableEntry> MakeOpeningTable(uint from, uint to, uint state, PlayerProfile player, SearchType searchType, uint incr, uint count = 0, Options optionsOverride = null)
        {
            var options = optionsOverride ?? this.Options;
            var size = to + 1;
            IList<uint> rngStateArr;
            IList<int> offsetArr;

            if (searchType == SearchType.First)
            {
                var rng = new CardRng(state);
                rngStateArr = new uint[size];
                for (int i = 0; i < size; i++)
                {
                    rngStateArr[i] = rng.State;
                    rng.Next();
                }
                int offsetArrSize = (int)(60f / options.AutofireSpeed);
                offsetArr = Enumerable.Range(0, offsetArrSize)
                    .Select(i => (int)options.ForcedIncr + i)
                    .ToList();
            }
            else if (searchType == SearchType.Counting)
            {
                var rng = new CardRng(state);
                int maxIdx = (int)(count + options.CountingWidth);
                rngStateArr = new uint[maxIdx].Select(_ =>
                {
                    var stateCopy = rng.State;
                    rng.Next();
                    return stateCopy + incr;
                }).ToList();
                offsetArr = new int[options.CountingFrameWidth].Select((_, i) =>
                {
                    return i - (int)options.CountingFrameWidth / 2;
                }).ToList();
            }
            else // Recovery
            {
                rngStateArr = new uint[size];
                for (int i = 0; i < size; i++)
                {
                    rngStateArr[i] = (state + (uint)i) & 0xffff_ffff;
                }
                offsetArr = new List<int> { 0 };
            }

            var table = new List<TableEntry>();
            for (int idx = (int)from; idx <= (int)to; idx++)
            {
                if (idx >= rngStateArr.Count) continue;
                foreach (var offset in offsetArr)
                {
                    var rngState = (rngStateArr[idx] + (uint)offset) & 0xffff_ffff;
                    table.Add(new TableEntry
                    {
                        Index = idx,
                        Offset = offset,
                        Opening = OpeningSituation((uint)rngState, player)
                    });
                }
            }
            return table;
        }

        /// <summary>
        /// Returns a list of possible opening situations matching the pattern.
        /// </summary>
        public List<SearchResult> SearchOpenings(
            uint state,
            string playerKey,
            PatternParseResult pattern,
            bool fuzzyOrder = false,
            uint? startIndexOverride = null,
            uint? widthOverride = null,
            int count = 0,
            SearchType searchType = SearchType.First,
            double? elapsedSeconds = null,
            uint incr = 0)
        {
            // Advance RNG by count if needed
            var player = PlayerProfiles[playerKey];

            if (elapsedSeconds != null)
            {
                double delay = Options.DelayFrame / Options.GameFps;
                int forcedIncr = (int)Options.ForcedIncr;
                int acceptDelay = (int)Options.AcceptDelayFrame;
                double incrStart = delay - (forcedIncr / Options.GameFps);
                int calcIncr = Math.Max(
                    (int)Math.Round((elapsedSeconds.Value - incrStart) * Options.GameFps),
                    forcedIncr + acceptDelay
                );
                if (calcIncr <= forcedIncr + acceptDelay)
                    calcIncr = forcedIncr;
                incr = (uint)calcIncr;
            }


            // Select width and startIndex based on searchType
            uint width;
            uint startIndex;
            switch (searchType)
            {
                case SearchType.Counting:
                    width = Options.CountingWidth;
                    startIndex = Convert.ToUInt32(count);
                    break;
                case SearchType.Recovery:
                    width = Options.RecoveryWidth;
                    startIndex = startIndexOverride ?? (Options.RecoveryWidth / 2);
                    state = (state + incr - startIndex) & 0xffff_ffff;
                    break;
                case SearchType.First:
                default:
                    width = widthOverride ?? Options.Width;

                    //if (playerKey == "fc01")
                    //{
                    //    // Start of game, assume 0
                    //    startIndex = 0;
                    //}
                    //else
                    //{
                    //    // At least up to zell card
                    //    startIndex = Options.Base;
                    //}
                    startIndex = 0;
                    break;
            }


            width = 1500;
            // Build search order (centered, then +/-1, +/-2, ...)
            var order = Enumerable.Range(1, (int)(width / 2))
                .Select(offset => new[] { startIndex + offset, startIndex - offset })
                .SelectMany(x => x)
                .ToList();

            order.Insert(0, startIndex);

            order = order.Where(x => x >= 0).ToList();

            if (width % 2 == 0)
            {
                order.Remove(order.Max());
            }

            switch (Options.Order)
            {
                case TOrder.Reverse:
                    order.Reverse();
                    break;
                case TOrder.Ascending:
                    order.Sort();
                    break;
                case TOrder.Descending:
                    order.Sort();
                    order.Reverse();
                    break;
            }

            uint firstState = state;

            // Build opening table
            //if (count > 0)
            //{
            //    var rng = new CardRng(state);
            //    for (int i = 0; i < count; i++)
            //    {
            //        rng.Next();
            //    }

            //    state = rng.State;
            //}


            var table = MakeOpeningTable((uint)order.Min(), (uint)order.Max(), state, player, searchType, incr, (uint)count, Options);

            // Match pattern
            var results = new List<SearchResult>();

            return order.Select(idx =>
            {
                var dataArr = table.Where(x => x.Index == idx);
                return dataArr.Select(data =>
                {
                    if (PatternMatches(pattern, data.Opening, fuzzyOrder))
                    {
                        return new SearchResult
                        {
                            Diff = (int)idx - (int)startIndex,
                            Index = (uint)idx,
                            Offset =  data.Offset,
                            LastState = data.Opening.LastState,
                            Initiative = data.Opening.Initiative,
                            Deck = data.Opening.Deck,
                            Cards = data.Opening.Deck.Select(id => CardTable.Single(c => c.Id == id).NameEn).ToList()
                        };
                    }

                    return null;
                });
            }).SelectMany(x => x)
            .Where(x => x != null).ToList();
        }

        private bool PatternMatches(PatternParseResult pattern, OpeningSituation data, bool fuzzyOrder)
        {
            var opening = data;

            if (pattern.Initiative.HasValue && pattern.Initiative.Value != opening.Initiative)
            {
                return false;
            }

            var patDeck = fuzzyOrder ? pattern.Deck.OrderBy(x => x, new ListComparer()).ToList() : pattern.Deck;
            var deck = fuzzyOrder ? opening.Deck.OrderBy(x => x).ToList() : opening.Deck;

            return patDeck
                .Zip(deck, (first, second) => (first, second))
                .All(x =>
                {
                    var (ids, id) = x;
                    return ids.Contains(id);
                });
        }

        private OpeningSituation OpeningSituation(uint state, PlayerProfile player, bool noRare = false)
        {
            const int DECK_MAX = 5;

            var rng = new CardRng(state);
            var deck = new List<int>();

            if (!noRare)
            {
                foreach (var rareId in player.Rares)
                {
                    var limit = deck.Count == 0 ? player.RareLimit : player.RareLimit / 2;

                    if (rng.Next() % 100 < limit)
                    {
                        deck.Add(rareId);
                    }

                    if (deck.Count >= DECK_MAX)
                    {
                        break;
                    }
                }
            }

            var pupuId = CardTable.Single(t => t.NameEn == "PuPu").Id;

            while (deck.Count < DECK_MAX)
            {
                var lv = player.Levels[rng.Next() % player.Levels.Count];
                var row = rng.Next() % 11;
                var cardId = (lv - 1) * 11 + (int)row;

                if (cardId == pupuId || deck.Contains(cardId))
                {
                    continue;
                }

                deck.Add(cardId);
            }

            var initiative = (rng.Next() & 1) != 0;

            return new OpeningSituation()
            {
                Deck = deck,
                Initiative = initiative,
                FirstState = state,
                LastState = rng.State,
            };
        }

        class TableEntry
        {
            public int Index { get; set; }
            public int Offset { get; set; }
            public OpeningSituation Opening { get; set; }
        }

        class ListComparer : IComparer<IList<int>>
        {
            public int Compare(IList<int> a, IList<int> b)
            {
                if (a.Count == 0 && b.Count == 0)
                {
                    return 0;
                }
                else if (a.Count == 0)
                {
                    return -1;
                }
                else if (b.Count == 0)
                {
                    return 1;
                }
                else if (a[0] == b[0])
                {
                    return Compare(a.Skip(1).ToList(), b.Skip(1).ToList());
                }
                else if (a[0] < b[0])
                {
                    return -1;
                }
                else
                {
                    return 1;
                }
            }
        }

    }
}

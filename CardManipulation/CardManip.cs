using CardManipulation.Models;
using System;
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

        public async Task RareTimerAsync(uint state, string playerKey, Action<RareTimerResult> onTick, CancellationToken token, int fps = 60, int count = 0)
        {
            // Advance RNG by count if needed
            if (count > 0)
            {
                var rng = new CardRng(state);
                for (int i = 0; i < count; i++) rng.Next();
                state = rng.State;
            }

            var start = DateTime.UtcNow;
            while (!token.IsCancellationRequested)
            {
                double elapsed = (DateTime.UtcNow - start).TotalSeconds;
                var result = GetRareTimerStep(state, playerKey, elapsed);
                onTick?.Invoke(result);
                await Task.Delay(1000 / fps, token);
            }
        }

        private RareTimerResult GetRareTimerStep(uint state, string playerKey, double elapsedSeconds, int width = 60, int count = 0)
        {
            // Advance RNG by count if needed
            if (count > 0)
            {
                var rng = new CardRng(state);
                for (int i = 0; i < count; i++) rng.Next();
                state = rng.State;
            }

            var player = PlayerProfiles[playerKey];
            int rareLimit = player.RareLimit;
            double delay = Options.DelayFrame / Options.GameFps;
            int forcedIncr = (int)Options.ForcedIncr;
            int acceptDelay = (int)Options.AcceptDelayFrame;
            int timerWidth = 8;
            int tableWidth = width;

            double incrStart = delay - (forcedIncr / Options.GameFps);
            int incr = Math.Max(
                (int)Math.Round((elapsedSeconds - incrStart) * Options.GameFps),
                forcedIncr + acceptDelay
            );
            if (incr <= forcedIncr + acceptDelay)
                incr = forcedIncr;

            var rareTbl = Enumerable.Range(0, tableWidth)
                .Select(i => NextRare(state + (uint)incr + (uint)i, rareLimit))
                .ToList();

            return new RareTimerResult
            {
                Incr = incr,
                RareTable = rareTbl,
                DurationSeconds = elapsedSeconds
            };
        }

        private OpeningSituation GenerateOpeningSituation(uint state, string playerKey, bool noRare = false)
        {
            var player = PlayerProfiles[playerKey];
            var rng = new CardRng(state);
            var deck = new List<int>();

            if (!noRare)
            {
                foreach (var rareId in player.Rares)
                {
                    var limit = deck.Count == 0 ? player.RareLimit : player.RareLimit / 2;
                    if (rng.Next() % 100 < limit)
                        deck.Add(rareId);
                    if (deck.Count >= 5) break;
                }
            }

            while (deck.Count < 5)
            {
                var lv = player.Levels[rng.Next() % player.Levels.Count];
                var row = rng.Next() % 11;
                var cardId = (lv - 1) * 11 + row;
                if (deck.Contains(cardId)) continue;
                deck.Add(cardId);
            }

            var initiative = (rng.Next() & 1) != 0;

            return new OpeningSituation
            {
                Deck = deck,
                Initiative = initiative,
                FirstState = state,
                LastState = rng.State
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
            foreach (Match m in Regex.Matches(input, @"[+-]"))
                initiative = m.Value == "+";

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

        /// <summary>
        /// Simulates the rare card timer. Returns the increment and rare table for UI display.
        /// </summary>
        private RareTimerResult RunRareTimer(uint state, string playerKey, int width = 60, int? overrideFps = null, int? overrideDelayMs = null, CancellationToken? cancel = null, int count = 0)
        {
            // Advance RNG by count if needed
            if (count > 0)
            {
                var rng = new CardRng(state);
                for (int i = 0; i < count; i++) rng.Next();
                state = rng.State;
            }

            var player = PlayerProfiles[playerKey];
            int rareLimit = player.RareLimit;
            int fps = overrideFps ?? Options.ConsoleFps;
            double delay = Options.DelayFrame / Options.GameFps;
            int forcedIncr = (int)Options.ForcedIncr;
            int acceptDelay = (int)Options.AcceptDelayFrame;
            int timerWidth = 8;
            int tableWidth = width;

            var start = DateTime.UtcNow;
            int incr = 0;
            double incrStart = delay - (forcedIncr / Options.GameFps);

            List<bool> rareTbl = new List<bool>();
            double duration = 0;

            // For WPF, you can call this in a Task and update UI on each tick if desired.
            while (true)
            {
                duration = (DateTime.UtcNow - start).TotalSeconds;
                incr = Math.Max(
                    (int)Math.Round((duration - incrStart) * Options.GameFps),
                    forcedIncr + acceptDelay
                );
                if (incr <= forcedIncr + acceptDelay)
                    incr = forcedIncr;

                rareTbl = Enumerable.Range(0, tableWidth)
                    .Select(i => NextRare(state + (uint)incr + (uint)i, rareLimit))
                    .ToList();

                // For WPF: break on cancellation or user input
                if (cancel?.IsCancellationRequested == true)
                    break;

                if (overrideDelayMs.HasValue)
                    Thread.Sleep(overrideDelayMs.Value);
                else
                    Thread.Sleep(1000 / fps);
            }

            return new RareTimerResult
            {
                Incr = incr,
                RareTable = rareTbl,
                DurationSeconds = duration
            };
        }

        private bool NextRare(uint state, int rareLimit)
        {
            var nextRnd = ((state * 0x10dcd + 1) & 0xffffffff) >> 17;
            return nextRnd % 100 < rareLimit;
        }

        /// <summary>
        /// Returns a list of possible opening situations matching the pattern.
        /// </summary>
        public List<SearchResult> SearchOpenings(uint state, string playerKey, PatternParseResult pattern, bool fuzzyOrder = false, int? startIndexOverride = null, int? widthOverride = null, int? offsetOverride = null, int count = 0)
        {
            // Advance RNG by count if needed
            if (count > 0)
            {
                var rng = new CardRng(state);
                for (int i = 0; i < count; i++) rng.Next();
                state = rng.State;
            }

            var player = PlayerProfiles[playerKey];
            int startIndex = startIndexOverride ?? (int)Options.Base;
            int width = widthOverride ?? (int)Options.Width;
            int offset = offsetOverride ?? 0;

            // Build search order (centered, then +/-1, +/-2, ...)
            var order = new List<int> { startIndex };
            for (int i = 1; i <= width / 2; i++)
            {
                order.Add(startIndex + i);
                order.Add(startIndex - i);
            }
            order = order.Where(x => x >= 0).ToList();
            if (width % 2 == 0 && order.Count > 0)
                order.Remove(order.Max());

            // Build opening table
            var table = new List<(int Index, int Offset, OpeningSituation Opening)>();
            foreach (var idx in order)
            {
                var rng = new CardRng(state);
                for (int i = 0; i < idx; i++) rng.Next();
                var opening = GenerateOpeningSituation(rng.State, playerKey);
                table.Add((idx, 0, opening));
            }

            // Match pattern
            var results = new List<SearchResult>();
            foreach (var entry in table)
            {
                if (PatternMatches(pattern, entry.Opening, fuzzyOrder))
                {
                    results.Add(new SearchResult
                    {
                        Diff = entry.Index - startIndex,
                        Index = entry.Index,
                        Offset = entry.Offset,
                        LastState = entry.Opening.LastState,
                        Initiative = entry.Opening.Initiative,
                        Deck = entry.Opening.Deck
                    });
                }
            }
            return results;
        }

        private bool PatternMatches(PatternParseResult pattern, OpeningSituation opening, bool fuzzyOrder)
        {
            if (pattern.Initiative.HasValue && pattern.Initiative.Value != opening.Initiative)
                return false;

            var patDeck = fuzzyOrder
                ? pattern.Deck.OrderBy(x => string.Join(",", x)).ToList()
                : pattern.Deck;
            var deck = fuzzyOrder
                ? opening.Deck.OrderBy(x => x).ToList()
                : opening.Deck;

            // Each pattern entry is a list of possible card IDs (from fuzzy parsing)
            for (int i = 0; i < patDeck.Count && i < deck.Count; i++)
            {
                if (!patDeck[i].Contains(deck[i]))
                    return false;
            }
            return true;
        }
    }
}

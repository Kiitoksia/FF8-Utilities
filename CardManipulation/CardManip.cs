using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using static CardManipulation.CardManip;

namespace CardManipulation
{
    public class CardManip
    {
        // EventArgs for input requests, allowing the handler to set the result
        public class InputRequestedEventArgs : EventArgs
        {
            public string Prompt { get; }
            public string Result { get; set; }
            public InputRequestedEventArgs(string prompt) => Prompt = prompt;
        }

        public class KeyRequestedEventArgs : EventArgs
        {
            public bool Intercept { get; }
            public ConsoleKeyInfo KeyInfo { get; set; }
            public KeyRequestedEventArgs(bool intercept) => Intercept = intercept;
        }

        public class IOHandler
        {
            public IOHandler(int windowWidth)
            {
                WindowWidth = windowWidth;
            }

            public int WindowWidth { get; }

            // Event for output (write)
            public event EventHandler<string> OutputRequested;

            // Event for input (read)
            public event EventHandler<InputRequestedEventArgs> InputRequested;

            // Event for key input (read key)
            public event EventHandler<KeyRequestedEventArgs> KeyRequested;

            // Call this to write output
            public void WriteLine(string message)
            {
                OutputRequested?.Invoke(this, message);
            }

            public void WriteLine()
            {
                OutputRequested?.Invoke(this, Environment.NewLine);
            }

            public void Write(string message)
            {
                OutputRequested?.Invoke(this, message);
            }

            public string ReadLine(string prompt = null)
            {
                var args = new InputRequestedEventArgs(prompt);
                InputRequested?.Invoke(this, args);
                return args.Result;
            }

            // Read a key, like Console.ReadKey
            public ConsoleKeyInfo ReadKey(bool intercept = false)
            {
                var args = new KeyRequestedEventArgs(intercept);
                KeyRequested?.Invoke(this, args);
                return args.KeyInfo;
            }
        }


        public CardManip(IOHandler handler, Options options, params string[] args)
        {
            _handler = handler ?? throw new ArgumentNullException(nameof(handler));
            _options = options ?? throw new ArgumentNullException(nameof(options));
            _args = args ?? throw new ArgumentNullException(nameof(args));
        }

        private IOHandler _handler;
        private string[] _args;
        private Options _options;



        // Main logic, can be called externally
        public void Run()
        {
            if (_args == null || _args.Length == 0)
            {
                if (_options.Interactive)
                {
                    _args = PromptArgs();
                }
                else
                {
                    ShowHelp();
                    return;
                }
            }

            var (firstState, state, count, searchType) = ReadArgs(_args);
            var player = PlayerTable.Get(_options.Player);

            if (searchType == TSearchType.First)
            {
                while (true)
                {
                    _handler.WriteLine();
                    _handler.WriteLine();
                    _handler.WriteLine(Translate.Get("prompt.second_game_method"));
                    var line = Prompt();

                    if (line.StartsWith("h"))
                    {
                        ShowPatternHelp();
                    }
                    else if (line.StartsWith("q"))
                    {
                        Environment.Exit(0);
                    }
                    else
                    {
                        var pattern = StringToPattern(line, player);

                        if (pattern == null)
                        {
                            continue;
                        }

                        var scanner = OpeningScanner(state, player, searchType);
                        StartSearch(scanner, pattern, player);
                    }
                }
            }
            else
            {
                while (true)
                {
                    _handler.WriteLine();
                    _handler.WriteLine(Translate.Get("prompt.first_game_method"));
                    var line = Prompt();

                    if (line.StartsWith("h"))
                    {
                        ShowPatternHelp();
                    }
                    else if (line.StartsWith("q"))
                    {
                        Environment.Exit(0);
                    }
                    else
                    {
                        RareSearch(state, player, counting: searchType == TSearchType.Counting);
                    }
                }
            }
        }

        void StartSearch(Func<Pattern, bool, IEnumerable<ScanEntry>> scanner, Pattern pattern, Player player)
        {
            IEnumerable<ScanEntry> result = Enumerable.Empty<ScanEntry>();

            for (var i = 0; i < _options.Fuzzy.Length; i++)
            {
                var fuzzy = _options.Fuzzy[i];

                var fuzzyRanks = fuzzy.Contains('r');
                var fuzzyOrder = fuzzy.Contains('o');
                _handler.WriteLine(new string('-', 60));
                _handler.WriteLine(string.Format(Translate.Get("fuzzy.fmt"), FuzzyToString(fuzzy)));

                pattern = StringToPattern(pattern.Str, player, fuzzyRanks, silent: true);
                _handler.WriteLine(PatternToString(pattern));

                var r = scanner(pattern, fuzzyOrder);
                var msg = r.Count() == 0 ? "not" : r.Count().ToString();
                msg = msg + " found.";

                var lastp = (i == (_options.Fuzzy.Length - 1));

                if (!r.Any() && !lastp)
                {
                    msg = msg + " retry...";
                }

                _handler.WriteLine(msg);

                if (r.Any())
                {
                    OutputSearchResults(r);
                    result = r;
                    break;
                }
            }

            while (true)
            {
                _handler.WriteLine();
                _handler.WriteLine(Translate.Get("prompt.after_normal_search"));
                var line = Prompt();

                if (string.IsNullOrEmpty(line))
                {
                    var target = result.OrderBy(x => Math.Abs(x.Index)).FirstOrDefault();

                    if (target == null)
                    {
                        _handler.WriteLine(Translate.Get("no_target"));
                        continue;
                    }

                    var lastState = target.Data.Opening.LastState;
                    RareSearch(lastState, player);
                }
                else if (line.StartsWith("h"))
                {
                    ShowPatternHelp();
                }
                else if (line.StartsWith("q"))
                {
                    Environment.Exit(0);
                }
                else
                {
                    var newPattern = StringToPattern(line, player, fuzzyRanks: false);

                    if (newPattern == null)
                    {
                        continue;
                    }

                    StartSearch(scanner, newPattern, player);
                }
            }
        }

        void RareSearch(uint state, Player player, bool counting = false)
        {
            var lastIncr = RareTimer(state, player);

            while (true)
            {
                _handler.WriteLine();
                _handler.WriteLine(Translate.Get("prompt.rare_search"));
                var line = Prompt();

                if (string.IsNullOrEmpty(line))
                {
                    RareSearch(state, player, counting);
                }
                else if (line.StartsWith("h"))
                {
                    ShowPatternHelp();
                }
                else if (line.StartsWith("q"))
                {
                    Environment.Exit(0);
                }
                else
                {
                    var recoveryPattern = StringToPattern(line, player);

                    if (recoveryPattern == null)
                    {
                        continue;
                    }

                    var nextSearchType = counting ? TSearchType.Counting : TSearchType.Recovery;
                    var recoveryScanner = OpeningScanner(state, player, nextSearchType, lastIncr);
                    StartSearch(recoveryScanner, recoveryPattern, player);
                }
            }
        }

        uint RareTimer(uint state, Player player)
        {
            var fps = _options.ConsoleFps;

            var start = DateTime.Now.SecondsSinceEpoch();
            var delay = _options.DelayFrame / _options.GameFps;

            var incr = 0U;
            var incrStart = delay - (_options.ForcedIncr / _options.GameFps);
            var timerWidth = 8;
            var width = Math.Min(_handler.WindowWidth - 1 - timerWidth, 60);

            var header = "timer".PadRight(timerWidth) + "! " + Translate.Get("prompt.rare_timer");
            _handler.WriteLine(header);

            while (true)
            {
                var duration = DateTime.Now.SecondsSinceEpoch() - start;

                incr = (uint)Math.Max(
                    Math.Round((duration - incrStart) * _options.GameFps),
                    _options.ForcedIncr + _options.AcceptDelayFrame
                );

                if (incr <= _options.ForcedIncr + _options.AcceptDelayFrame)
                {
                    incr = _options.ForcedIncr;
                }

                var rareTbl = new int[width].Select((_, idx) => NextRare(state + incr + (uint)idx, player.RareLimit));

                var durationS = (duration - delay).ToString("0.00") + "s" + (rareTbl.First() ? "!" : "");

                var tableS = rareTbl.Select((x, i) =>
                {
                    if (x)
                    {
                        return "*";
                    }
                    else if (i == 0)
                    {
                        return "!";
                    }
                    else
                    {
                        return "-";
                    }
                }).Aggregate((acc, x) => acc + x);

                _handler.Write(durationS.PadRight(timerWidth) + tableS + "\r");

                Thread.Sleep(1000 / fps);

                if (_handler.KeyAvailable && _handler.ReadKey(true).Key == ConsoleKey.Enter)
                {
                    _handler.WriteLine();
                    _handler.CursorVisible = true;
                    return incr;
                }
            }
        }

        bool NextRare(uint state, int limit)
        {
            var nextRnd = ((state * 0x10dcd + 1) & 0xffff_ffff) >> 17;
            return nextRnd % 100 < limit;
        }

        Pattern StringToPattern(string s, Player player, bool fuzzyRanks = false, bool silent = false)
        {
            var rare = player.Rares.Any() ? player.Rares.First() : new int?();

            var cardRegex = new Regex("[0-9a]{4}", RegexOptions.IgnoreCase);
            var ranksArr = cardRegex.Matches(s).Cast<Match>().Select(x => x.Value).Take(5).ToList();

            if (ranksArr.Count < (rare == null ? 5 : 4))
            {
                _handler.WriteLine(string.Format(Translate.Get("str2pattern.UnmatchedInput_fmt"), s));
                return null;
            }

            var regexInitiative = new Regex("[+-]");
            var initiative = regexInitiative.Matches(s).Cast<Match>().Select(x => x.Value).Aggregate(new bool?(), (acc, x) => x == "+");

            var customRanksOrder = "urdl".Select(c => _options.RanksOrder.IndexOf(c));
            var urdlArr = ranksArr.Select(ranks =>
            {
                var ranksNumber = ranks
                    .Select(c => Convert.ToInt32(c.ToString(), fromBase: 16))
                    .Select(x => x == 0 ? 10 : x);

                return customRanksOrder.Select(idx => ranksNumber.ElementAt(idx)).ToArray();
            });

            var idsArr = urdlArr.Select(urdl => CardTable.ListIdsByUrdl(urdl, fuzzyRanks)).ToList();
            var retryCount = 0;

            while (true)
            {
                if (idsArr.Any(x => x.Count == 0))
                {
                    var emptyNoArr = idsArr.Select((_, idx) => idx + 1).Where(no => idsArr[no - 1].Count == 0);
                    var emptyNoS = string.Join(", ", emptyNoArr.Select(no => string.Format("#{0}:{1}", no, ranksArr[no - 1])));
                    var errorMsg = string.Format(Translate.Get("str2pattern.EmptyIDs_fmt"), emptyNoS);

                    retryCount++;

                    if (fuzzyRanks || retryCount > 1)
                    {
                        _handler.WriteLine(errorMsg);
                        return null;
                    }

                    if (!silent)
                    {
                        _handler.WriteLine(errorMsg);
                        _handler.WriteLine(Translate.Get("str2pattern.read_as_fuzzy"));
                    }

                    idsArr = urdlArr
                        .Select((urdl, idx) => CardTable.ListIdsByUrdl(urdl, fuzzy: emptyNoArr.Contains(idx + 1)))
                        .ToList();

                    continue;
                }

                break;
            }

            var arrExceptUniq = idsArr.Select(ids =>
            {
                if (!fuzzyRanks)
                {
                    return idsArr.Count(x => x.SequenceEqual(ids)) > 1 ? ids : null;
                }
                else
                {
                    return ids.Count == 1 && idsArr.Count(x => x.SequenceEqual(ids)) > 1 ? ids : null;
                }
            }).ToList();

            if (arrExceptUniq.Where(x => x != null).Any())
            {
                var duplicatedNoArr = arrExceptUniq.Select((_, idx) => idx + 1).Where(no => arrExceptUniq[no - 1] != null);
                var duplicatedNoS = string.Join(", ", duplicatedNoArr.Select(no => string.Format("#{0}:{1}", no, ranksArr[no - 1])));
                var errorMsg = string.Format(Translate.Get("str2pattern.DuplicatedIDs_fmt"), duplicatedNoS);

                _handler.WriteLine(errorMsg);
                return null;
            }

            if (idsArr.Count == 4)
            {
                idsArr.Insert(0, new List<int>() { rare.Value });
            }

            return new Pattern()
            {
                Str = s,
                Deck = idsArr,
                Initiative = initiative
            };
        }

        Func<Pattern, bool, IEnumerable<ScanEntry>> OpeningScanner(uint state, Player player, TSearchType searchType, uint incr = 0)
        {
            var startIndex = 0U;
            var width = 0U;

            switch (searchType)
            {
                case TSearchType.First:
                    startIndex = _options.Base;
                    width = _options.Width;
                    break;
                case TSearchType.Counting:
                    startIndex = ReadArgs(_args, silent: true).count;
                    width = _options.CountingWidth;
                    break;
                case TSearchType.Recovery:
                    startIndex = _options.RecoveryWidth / 2;
                    state = (state + incr - startIndex) & 0xffff_ffff;
                    width = _options.RecoveryWidth;
                    break;
            }

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

            switch (_options.Order)
            {
                case Options.TOrder.Reverse:
                    order.Reverse();
                    break;
                case Options.TOrder.Ascending:
                    order.Sort();
                    break;
                case Options.TOrder.Descending:
                    order.Sort();
                    order.Reverse();
                    break;
            }

            var table = MakeOpeningTable((uint)order.Min(), (uint)order.Max(), state, player, searchType, incr);

            return (pattern, fuzzyOrder) =>
            {
                return order
                    .Select(idx =>
                    {
                        var dataArr = table.Where(x => x.Index == idx);

                        return dataArr.Select(data =>
                        {
                            if (OpeningMatch(pattern, data, fuzzyOrder))
                            {
                                return new ScanEntry()
                                {
                                    Diff = (int)idx - (int)startIndex,
                                    Index = (uint)idx,
                                    Data = data,
                                };
                            }

                            return null;
                        });
                    })
                    .SelectMany(x => x)
                    .Where(x => x != null);
            };
        }

        bool OpeningMatch(Pattern pattern, TableEntry data, bool fuzzyOrder)
        {
            var opening = data.Opening;

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

        IList<TableEntry> MakeOpeningTable(uint from, uint to, uint state, Player player, TSearchType searchType, uint incr)
        {
            var size = to + 1;
            IList<uint> rngStateArr;
            IList<int> offsetArr;

            if (searchType == TSearchType.First)
            {
                var rng = new CardRng(state);

                rngStateArr = new uint[size].Select(_ =>
                {
                    var stateCopy = rng.State;
                    rng.Next();
                    return stateCopy;
                }).ToList();

                var offsetArrSize = (int)(60f / _options.AutofireSpeed);

                offsetArr = new int[offsetArrSize].Select((_, i) =>
                {
                    return (int)_options.ForcedIncr + i;
                }).ToList();
            }
            else if (searchType == TSearchType.Counting)
            {
                var (firstState, _, count, _) = ReadArgs(_args, silent: true);
                var rng = new CardRng(firstState);
                var maxIdx = count + _options.CountingWidth;

                rngStateArr = new uint[maxIdx].Select(_ =>
                {
                    var stateCopy = rng.State;
                    rng.Next();
                    return stateCopy + incr;
                }).ToList();

                offsetArr = new int[_options.CountingFrameWidth].Select((_, i) =>
                {
                    return i - (int)_options.CountingFrameWidth / 2;
                }).ToList();
            }
            else
            {
                rngStateArr = new uint[size].Select((_, i) =>
                {
                    return (state + (uint)i) & 0xffff_ffff;
                }).ToList();

                offsetArr = new[] { 0 };
            }

            var table = new List<TableEntry>();

            for (var idx = 0; idx <= to; idx++)
            {
                if (!(idx >= from && idx <= to))
                {
                    continue;
                }

                foreach (var offset in offsetArr)
                {
                    var rngState = (rngStateArr[idx] + offset) & 0xffff_ffff;

                    table.Add(new TableEntry()
                    {
                        Index = idx,
                        Offset = offset,
                        Opening = OpeningSituation((uint)rngState, player),
                    });
                }
            }

            return table;
        }

        static Situation OpeningSituation(uint state, Player player, bool noRare = false)
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

            var pupuId = CardTable.FindIdByName("PuPu");

            while (deck.Count < DECK_MAX)
            {
                var lv = player.Levels[rng.Next() % player.Levels.Length];
                var row = rng.Next() % 11;
                var cardId = (lv - 1) * 11 + (int)row;

                if (cardId == pupuId || deck.Contains(cardId))
                {
                    continue;
                }

                deck.Add(cardId);
            }

            var initiative = (rng.Next() & 1) != 0;

            return new Situation()
            {
                Deck = deck,
                Initiative = initiative,
                FirstState = state,
                LastState = rng.State,
            };
        }

        void OutputSearchResults(IEnumerable<ScanEntry> r)
        {
            var nearestIndex = r.OrderBy(x => Math.Abs(x.Index)).First().Index;
            _handler.WriteLine("diff\tindex\toffset\tlast_state\tinitia\tdeck");

            foreach (var v in r)
            {
                var diff = v.Diff;
                var idx = v.Index;
                var data = v.Data;
                var nearest = idx == nearestIndex;
                var idxStr = string.Format(nearest ? "*{0:d3}*" : "{0:d3}", idx);
                var offset = data.Offset;
                var initiative = data.Opening.Initiative;
                var deck = data.Opening.Deck.Select(id =>
                {
                    var s = id.ToString();

                    if (_options.HighlightCards.Contains(id))
                    {
                        s = $"*{s}*";
                    }

                    if (_options.StrongHighlightCards.Contains(id))
                    {
                        s = $"**{s}**";
                    }

                    return s;
                });
                var deckS = "[" + string.Join(", ", deck) + "]";
                var state = data.Opening.LastState;
                var msg = string.Format("{0,3:+#;-#;#}\t{1}\t{2}\t{3:x8}\t{4}\t{5}", diff, idxStr, offset, state, initiative, deckS);
                _handler.WriteLine(msg);
            }
        }

        (uint firstState, uint state, uint count, TSearchType searchType) ReadArgs(string[] args, bool silent = false)
        {
            var s = args[0];
            var firstState = 0U;
            var searchType = TSearchType.First;
            var msg = "";

            firstState = Convert.ToUInt32(s, fromBase: 16) & 0xffff_ffff;
            searchType = TSearchType.Recovery;
            msg = string.Format(Translate.Get("read_argv.direct_rng_state_fmt"), firstState);

            if (searchType == TSearchType.First)
            {
                msg = string.Format(Translate.Get("read_argv.select_fmt"), msg);
                msg = string.Format("{0}: 0x{1:x8}", msg, firstState);
            }

            var state = firstState;
            var count = 0U;

            if (args.Length > 1)
            {
                count = uint.Parse(args[1]);
                var rng = new CardRng(firstState);

                for (var i = 0; i < count; i++)
                {
                    rng.Next();
                }

                msg += "\n" + string.Format(Translate.Get("read_argv.advanced_rng_fmt"), count, rng.State);

                state = rng.State;
                searchType = TSearchType.Counting;
            }

            if (!silent)
            {
                _handler.WriteLine(msg);
            }

            return (firstState, state, count, searchType);
        }

        string FuzzyToString(string fuzzy)
        {
            var r = new List<string>();

            if (fuzzy.Contains('r'))
            {
                r.Add(Translate.Get("fuzzy.ranks"));
            }

            if (fuzzy.Contains('o'))
            {
                r.Add(Translate.Get("fuzzy.order"));
            }

            if (r.Count == 0)
            {
                return Translate.Get("fuzzy.strict");
            }

            return string.Join(", ", r);
        }

        string PatternToString(Pattern pattern)
        {
            var deckNames = pattern.Deck.Select(ids =>
            {
                var names = ids.Select(id =>
                {
                    var s = CardTable.FindNameById(id);

                    if (_options.HighlightCards.Contains(id))
                    {
                        s = $"*{s}*";
                    }

                    if (_options.StrongHighlightCards.Contains(id))
                    {
                        s = $"**{s}**";
                    }

                    return s;
                });

                var namesS = string.Join("|", names);

                return ids.Count == 1 ? namesS : $"({namesS})";
            });

            var deckS = string.Join(", ", deckNames);

            string initiativeS;

            if (pattern.Initiative == null)
            {
                initiativeS = Translate.Get("initiative.any");
            }
            else if (pattern.Initiative == true)
            {
                initiativeS = Translate.Get("initiative.player");
            }
            else
            {
                initiativeS = Translate.Get("initiative.cpu");
            }

            return string.Format(Translate.Get("pattern2str_fmt"), initiativeS, deckS);
        }

        void ShowHelp()
        {
            _handler.WriteLine(Translate.Get("help.first"));
            _handler.WriteLine();
            _handler.WriteLine(Translate.Get("help.last"));
        }

        void ShowPatternHelp()
        {
            _handler.WriteLine(Translate.Get("help.pattern"));
        }

        string[] PromptArgs()
        {
            _handler.WriteLine(Translate.Get("prompt_args.first"));
            var first = Prompt();
            _handler.WriteLine(Translate.Get("prompt_args.second"));
            var second = Prompt();
            _handler.WriteLine();

            if (string.IsNullOrWhiteSpace(second))
            {
                return new string[] { first };
            }

            return new string[] { first, second };
        }

        string Prompt()
        {
            _handler.Write(_options.Prompt);
            return _handler.ReadLine();
        }

        enum TSearchType
        {
            First,
            Recovery,
            Counting,
        }

        class Pattern
        {
            public string Str { get; set; }
            public IList<IList<int>> Deck { get; set; }
            public bool? Initiative { get; set; }
        }

        class ScanEntry
        {
            public int Diff { get; set; }
            public uint Index { get; set; }
            public TableEntry Data { get; set; }
        }

        class TableEntry
        {
            public int Index { get; set; }
            public int Offset { get; set; }
            public Situation Opening { get; set; }
        }

        class Situation
        {
            public IList<int> Deck { get; set; }
            public bool Initiative { get; set; }
            public uint FirstState { get; set; }
            public uint LastState { get; set; }
        }
    }
}

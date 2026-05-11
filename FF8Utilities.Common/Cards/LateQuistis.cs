using CsvHelper;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace FF8Utilities.Common.Cards
{
    public class LateQuistis
    {
        public const string QuistisCardRNGResultFilename = "Q card Late - RNG result.csv";
        public const string QuistisCardFullGameFilename = "Q card Late - Full Game Scenario.csv";
        public const string QuistisCardHowToPlayFilename = "Q card Late - How to Play.csv";
        public const string QuistisCardOpponentDeckFilename = "Q card Late - Opponent Deck.csv";

        public static readonly string[] RequiredFiles = new[] { QuistisCardRNGResultFilename, QuistisCardFullGameFilename, QuistisCardHowToPlayFilename, QuistisCardOpponentDeckFilename };

        private string _baseFolder;
        private Dictionary<string, string> _csvContents;

        /// <summary>
        /// File-system based constructor for desktop/MAUI.
        /// </summary>
        public LateQuistis(string baseFolder)
        {
            _baseFolder = baseFolder;

            foreach (string filename in RequiredFiles)
            {
                if (!File.Exists(Path.Combine(baseFolder, filename)))
                {
                    throw new ArgumentException("Folder does not contain all CSV files");
                }
            }

#if DEBUG
            Stopwatch sw = new Stopwatch();
            sw.Start();
#endif
            LoadRNGResult();
            LoadOpponentDecks();
            LoadPlayPatterns();
            LoadGameScenarios();
#if DEBUG
            sw.Stop();
            Console.WriteLine($"LateQuistis Init Time: {sw.Elapsed.TotalSeconds:N2}s");
#endif
        }

        /// <summary>
        /// In-memory constructor for Blazor WASM (use <see cref="CreateAsync"/>).
        /// </summary>
        private LateQuistis(Dictionary<string, string> csvContents)
        {
            _csvContents = csvContents;

#if DEBUG
            Stopwatch sw = new Stopwatch();
            sw.Start();
#endif
            LoadRNGResult();
            LoadOpponentDecks();
            LoadPlayPatterns();
            LoadGameScenarios();
#if DEBUG
            sw.Stop();
            Console.WriteLine($"LateQuistis Init Time: {sw.Elapsed.TotalSeconds:N2}s");
#endif
        }

        /// <summary>
        /// Async factory for Blazor WebAssembly. Fetches CSV files via HttpClient.
        /// </summary>
        /// <param name="http">The HttpClient to use.</param>
        /// <param name="baseUrl">Base URL pointing to the folder containing the CSV files (e.g. "res/").</param>
        public static async Task<LateQuistis> CreateAsync(HttpClient http, string baseUrl)
        {
            var contents = new Dictionary<string, string>();
            foreach (string filename in RequiredFiles)
            {
                string url = $"{baseUrl.TrimEnd('/')}/{Uri.EscapeDataString(filename)}";
                contents[filename] = await http.GetStringAsync(url);
            }
            return new LateQuistis(contents);
        }

        private List<OpponentDeck> OpponentDecks { get; set; }
        private List<RNGResult> RNGResults { get; set; }
        private List<PlayPattern> PlayPatterns { get; set; }
        private List<GameScenario> GameScenarios { get; set; }

        private void LoadFile<T>(string relativeFile, Action<int, T> rowHandler) where T : class
        {
            TextReader textReader;

            if (_csvContents != null) // Web approach
            {
                textReader = new StringReader(_csvContents[relativeFile]);
            }
            else
            {
                textReader = new StreamReader(Path.Combine(_baseFolder, relativeFile));
            }

            using (textReader)
            {
                using (CsvReader csv = new CsvReader(textReader, new CultureInfo("en-US")))
                {
                    csv.Read();
                    csv.ReadHeader();
                    while (csv.Read())
                    {
                        try
                        {
                            var record = csv.GetRecord<T>();
                            rowHandler(csv.CurrentIndex, record);
                        }
                        catch (CsvHelper.TypeConversion.TypeConverterException)
                        {
                            // Invalid record
                        }
                    }
                }
            }            
        }

        private void LoadRNGResult()
        {
            RNGResults = new List<RNGResult>();
            LoadFile<RNGResult>(QuistisCardRNGResultFilename, (rowNo, result) =>
            {
                if (result.IsValid) RNGResults.Add(result);
            });
        }

        private void LoadOpponentDecks()
        {
            OpponentDecks = new List<OpponentDeck>();
            LoadFile<OpponentDeck>(QuistisCardOpponentDeckFilename, (rowNo, deck) =>
            {
                if (deck.IsValid) OpponentDecks.Add(deck);
            });
        }

        private void LoadPlayPatterns()
        {
            PlayPatterns = new List<PlayPattern>();
            LoadFile<PlayPattern>(QuistisCardHowToPlayFilename, (rowNo, pattern) =>
            {
                if (pattern.IsValid) PlayPatterns.Add(pattern);
            });
        }

        private void LoadGameScenarios()
        {
            GameScenarios = new List<GameScenario>();
            LoadFile<GameScenario>(QuistisCardFullGameFilename, (rowNo, scenario) =>
            {
                if (scenario.IsValid) GameScenarios.Add(scenario);
            });
        }

        public LateQuistisPattern GetPattern(int rngModifier, bool loadImages)
        {
            GameScenario scenario = GameScenarios.SingleOrDefault(t => t.RNGIndex == rngModifier);
            OpponentDeck deck = OpponentDecks.SingleOrDefault(t => t.RNGIndex == rngModifier);
            PlayPattern pattern = PlayPatterns.SingleOrDefault(t => t.RNGIndex == rngModifier);
            RNGResult result = RNGResults.SingleOrDefault(t => t.RNGIndex == rngModifier);

            return new LateQuistisPattern(scenario?.RNGHex, rngModifier, scenario, deck, pattern, result, loadImages);
        }
    }
}

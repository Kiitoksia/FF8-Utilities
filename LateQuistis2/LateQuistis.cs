using CsvHelper;
using LateQuistisManipulation.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LateQuistisManipulation
{
    public class LateQuistis
    {
        public const string QuistisCardRNGResultFilename = "Q card Late - RNG result.csv";
        public const string QuistisCardFullGameFilename = "Q card Late - Full Game Scenario.csv";
        public const string QuistisCardHowToPlayFilename = "Q card Late - How to Play.csv";
        public const string QuistisCardOpponentDeckFilename = "Q card Late - Opponent Deck.csv";

        public static readonly string[] RequiredFiles = new[] { QuistisCardRNGResultFilename, QuistisCardFullGameFilename, QuistisCardHowToPlayFilename, QuistisCardOpponentDeckFilename };

        private string _baseFolder;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="baseFolder">Should be the folder containing the 4 quistis CSV files</param>
        /// <exception cref="ArgumentException">Thrown if base folder does not contain the 4 expected files</exception>
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

            LoadRNGResult();
            LoadOpponentDecks();
            LoadPlayPatterns();
            LoadGameScenarios();
        }

        private List<OpponentDeck> OpponentDecks { get; set; }

        private List<RNGResult> RNGResults { get; set; }

        private List<PlayPattern> PlayPatterns { get; set; }

        private List<GameScenario> GameScenarios { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="relativeFile"></param>
        /// <param name="rowHandler">int = RowIndex, string[] rowFields</param>
        private void LoadFile<T>(string relativeFile, Action<int, T> rowHandler) where T : class, new()
        {
            using (StreamReader reader = new StreamReader(Path.Combine(_baseFolder, relativeFile)))
            {
                using (CsvReader csv = new CsvReader(reader, CultureInfo.CurrentCulture))
                {
                    csv.Read();
                    csv.ReadHeader();
                    while (csv.Read())
                    {
                        var record = csv.GetRecord<T>();
                        rowHandler(csv.CurrentIndex, record);
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

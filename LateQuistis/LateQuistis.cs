using LateQuistisManipulation.Models;
using System;
using System.Collections.Generic;
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
        private void LoadFile(string relativeFile, Action<int, string[]> rowHandler)
        {
            Microsoft.VisualBasic.FileIO.TextFieldParser parser = new Microsoft.VisualBasic.FileIO.TextFieldParser(Path.Combine(_baseFolder, relativeFile));
            parser.TextFieldType = Microsoft.VisualBasic.FileIO.FieldType.Delimited;
            parser.SetDelimiters(",");


            while (!parser.EndOfData)
            {
                if (parser.LineNumber == 1)
                {
                    // Header, ignore
                    parser.ReadLine();
                    continue;
                }

                rowHandler((int)parser.LineNumber, parser.ReadFields());
            }
        }


        private void LoadRNGResult()
        {
            RNGResults = new List<RNGResult>();
            LoadFile(QuistisCardRNGResultFilename, (rowNo, row) =>
            {
                if (rowNo == 1) return; // Header

                if (!int.TryParse(row[1], out int rngIndex))
                {
                    // Invalid row, ignore
                    return;
                }

                RNGResult result = new RNGResult(
                    row[0],
                    rngIndex,
                    row[2],
                    row[3],
                    row[4],
                    row[5],
                    row[6],
                    row[7],
                    row[8],
                    row[9],
                    row[10],
                    row[11],
                    row[12]);

                if (result.IsValid) RNGResults.Add(result);
            });        
        }

        private void LoadOpponentDecks()
        {
            OpponentDecks = new List<OpponentDeck>();
            LoadFile(QuistisCardOpponentDeckFilename, (rowNo, row) =>
            {
                if (rowNo == 1) return; // Header
                if (!int.TryParse(row[1], out int rngIndex))
                {
                    // Invalid row, ignore
                    return;
                }
                
                OpponentDeck deck = new OpponentDeck(
                    row[0],
                    rngIndex,
                    row[2],
                    row[3],
                    row[4],
                    row[5],
                    row[6],
                    row[7],
                    row[8],
                    row[9],
                    row[10],
                    row[11],
                    row[12]
                    );

                if (deck.IsValid) OpponentDecks.Add(deck);
            });
        }

        private void LoadPlayPatterns()
        {
            PlayPatterns = new List<PlayPattern>();
            LoadFile(QuistisCardHowToPlayFilename, (rowNo, row) =>
            {
                if (rowNo == 1) return; // Header
                if (!int.TryParse(row[1], out int rngIndex))
                {
                    // Invalid row, ignore
                    return;
                }

                PlayPattern pattern = new PlayPattern(
                    row[0],
                    rngIndex,
                    row[2],
                    row[3],
                    row[4],
                    row[5],
                    row[6],
                    row[7],
                    row[8],
                    row[9],
                    row[10],
                    row[11],
                    row[12]);

                if (pattern.IsValid) PlayPatterns.Add(pattern);
            });
        }

        private void LoadGameScenarios()
        {
            GameScenarios = new List<GameScenario>();
            LoadFile(QuistisCardFullGameFilename, (rowNo, row) =>
            {
                if (rowNo == 1) return; // Header
                if (!int.TryParse(row[1], out int rngIndex))
                {
                    // Invalid row, ignore
                    return;
                }

                GameScenario scenario = new GameScenario(
                   row[0],
                   rngIndex,
                   row[2],
                   row[3],
                   row[4],
                   row[5],
                   row[6],
                   row[7],
                   row[8],
                   row[9],
                   row[10],
                   row[11],
                   row[12]);

                if (scenario.IsValid) GameScenarios.Add(scenario);
            });
        }

        public LateQuistisPattern GetPattern(int rngModifier)
        {
            GameScenario scenario = GameScenarios.SingleOrDefault(t => t.RNGIndex == rngModifier);
            OpponentDeck deck = OpponentDecks.SingleOrDefault(t => t.RNGIndex == rngModifier);
            PlayPattern pattern = PlayPatterns.SingleOrDefault(t => t.RNGIndex == rngModifier);
            RNGResult result = RNGResults.SingleOrDefault(t => t.RNGIndex == rngModifier);

            return new LateQuistisPattern(scenario?.RNGHex, rngModifier, scenario, deck, pattern, result);
        }

    }
}

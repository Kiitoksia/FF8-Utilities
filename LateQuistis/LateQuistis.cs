using LateQuistis.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LateQuistis
{
    public class LateQuistis
    {
        public const string QuistisCardRNGResultFilename = "Q card Late - RNG result.csv";
        public const string QuistisCardFullGameFilename = "Q card Late - Full Game Scenario.csv";
        public const string QuistisCardHowToPlayFilename = "Q card Late - How to Play.csv";
        public const string QuistisCardOpponentDeckFilename = "Q card Late - Opponent Deck.csv";

        private string _baseFolder;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="baseFolder">Should be the folder containing the 4 quistis CSV files</param>
        public LateQuistis(string baseFolder)
        {
            _baseFolder = baseFolder;

            foreach (string filename in new[] { QuistisCardRNGResultFilename, QuistisCardFullGameFilename, QuistisCardHowToPlayFilename, QuistisCardOpponentDeckFilename })
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

                string[] row = parser.ReadFields();
                if (row == null) continue;
                if (!int.TryParse(row[1], out int rngIndex))
                {
                    // Invalid row, ignore
                }
                for (int i = 0; i < 9; i++)
                {
                    RNGResults.Add(new RNGResult(row[0], rngIndex, i + 1, row[i + 2]));
                }

            }
        }


        private void LoadRNGResult()
        {
            Microsoft.VisualBasic.FileIO.TextFieldParser parser = new Microsoft.VisualBasic.FileIO.TextFieldParser(Path.Combine(_baseFolder, QuistisCardRNGResultFilename));
            parser.TextFieldType = Microsoft.VisualBasic.FileIO.FieldType.Delimited;
            parser.SetDelimiters(",");

            RNGResults = new List<RNGResult>();
            LoadFile(QuistisCardRNGResultFilename, (rowNo, row) =>
            {
                if (rowNo == 1) return; // Header

                if (!int.TryParse(row[1], out int rngIndex))
                {
                    // Invalid row, ignore
                    return;
                }
                for (int i = 0; i < 9; i++)
                {
                    RNGResults.Add(new RNGResult(row[0], rngIndex, i + 1, row[i + 2]));
                }
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
        
    }
}

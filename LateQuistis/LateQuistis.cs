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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="baseFolder">Should be the folder containing the 4 quistis CSV files</param>
        public LateQuistis(string baseFolder)
        {
            foreach (string filename in new[] { QuistisCardRNGResultFilename, QuistisCardFullGameFilename, QuistisCardHowToPlayFilename, QuistisCardOpponentDeckFilename })
            {
                if (!File.Exists(Path.Combine(baseFolder, filename)))
                {
                    throw new ArgumentException("Folder does not contain all CSV files");
                }
            }


        }

        
    }
}

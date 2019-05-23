using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UltimeciaManip.Entities
{
    public class Lineup
    {
        public Lineup(string firstCharacter, string secondCharacter, string thirdCharacter, int count)
        {
            FirstCharacter = firstCharacter;
            SecondCharacter = secondCharacter;
            ThirdCharacter = thirdCharacter;
            Count = count;
        }

        public string FirstCharacter { get; }
        public string SecondCharacter { get; }
        public string ThirdCharacter { get; }
        public int Count { get; set; }
    }
}

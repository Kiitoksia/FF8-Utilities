using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UltimeciaManip.Entities;

namespace FF8Utilities.Models
{
    public class LineupModel : BaseModel
    {
        public LineupModel(Lineup lineup, bool fastest)
        {
            FirstCharacter = lineup.FirstCharacter;
            SecondCharacter = lineup.SecondCharacter;
            ThirdCharacter = lineup.ThirdCharacter;
            Count = lineup.Count;
            IsFastest = fastest;
        }

        public string FirstCharacter { get; }

        public string SecondCharacter { get; }

        public string ThirdCharacter { get; }

        public string Display => $"{FirstCharacter}\r\n{SecondCharacter}\r\n{ThirdCharacter}";

        public int Count { get; }
        public bool IsFastest { get; set; }
    }
}

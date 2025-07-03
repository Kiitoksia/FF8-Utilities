using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KaivelFins.Entities
{
    public class KaivelOption
    {
        internal KaivelOption(int hp, int drop, string manip, int skip, int rngStart, int rngEnd)
        {
            HP = hp;
            Drop = drop;
            Manip = manip;
            Skip = skip;
            RNGStart = rngStart;
            RNGEnd = rngEnd;
        }

        public int HP { get; }
        public int Drop { get; }
        public string Manip { get; }
        public int Skip { get; }
        public int RNGStart { get; }
        public int RNGEnd { get; }
    }
}

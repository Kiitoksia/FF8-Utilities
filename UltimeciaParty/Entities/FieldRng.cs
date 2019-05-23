using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UltimeciaParty.Entities
{
    public class FieldRng
    {
        private long _intitalSeed;

        public FieldRng()
        {

        }

        public long State = 0x0000_0001;

        public void GetNextState()
        {
            State = (State * 0x41c6_4e6d + 0x3039) & 0xffff_ffff;
        }


    }
}

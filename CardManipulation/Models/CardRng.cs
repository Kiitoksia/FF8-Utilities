using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardManipulation.Models
{
    public class CardRng
    {
        public CardRng(uint seed) 
        {
            State = seed; 
        }

        public int Next()
        {
            State = (uint)(((ulong)State * 0x10dcd + 1) & 0xffffffff);
            return (int)(State >> 17);
        }

        public uint State { get; private set; }

    }
}

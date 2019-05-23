using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZellCardManip.Entities
{
    [DebuggerDisplay("0x{" + nameof(RNGDisplay) + "}")]
    public class CardRng
    {
        private long _initalSeed;

        public CardRng(long? seed, SearchType searchType)
        {
            if (seed != null) State = seed.Value;
            _initalSeed = State;
        }

        private void Initialise()
        {

        }

        public long State = 0x0000_0001;
        public SearchType SearchType { get; set; }

        public void GetNextState()
        {
            State = (State * 0x10dcd + 1) & 0xffff_ffff;
        }

        private void Reset()
        {
            State = _initalSeed;
        }        

        public string RNGDisplay => State.ToString("X");

        public void StartScan(int increment = 0) { }
    }
}

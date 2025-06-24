using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LateQuistisManipulation.Models
{
    public class RNGResult
    {
        public RNGResult(string rngHex, int rngIndex, int frame, string result)
        {
            RNGHex = rngHex;
            Result = result;
            Frame = frame;
            RNGIndex = rngIndex;
        }

        public string RNGHex { get; }

        public int RNGIndex { get; }

        public int Frame { get; }

        public string Result { get; }
    }
}

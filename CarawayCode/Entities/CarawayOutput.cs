using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarawayCode.Entities
{
    public class CarawayOutput
    {
        public CarawayOutput(int index, string rNGState, int source, string code, int[] poles, string polesHex, string station, string escalator, string street, string bus, string input)
        {
            Index = index;
            RNGState = rNGState;
            Source = source;
            Code = code;
            Poles = poles;
            PolesHex = polesHex;
            Station = station;
            Escalator = escalator;
            Street = street;
            Bus = bus;
            Input = input;
        }

        public int Index { get; }
        public string RNGState { get; }
        public int Source { get; }
        public string Code { get; }

        public int[] Poles { get; }
        public string PolesHex { get; }
        public string Station { get; }
        public string Escalator { get; }
        public string Street { get; }
        public string Bus { get; }
        public string Input { get; }
    }
}

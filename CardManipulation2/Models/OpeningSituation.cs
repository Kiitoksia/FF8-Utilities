using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardManipulation.Models
{
    public class OpeningSituation
    {
        public List<int> Deck { get; set; }
        public bool Initiative { get; set; }
        public uint FirstState { get; set; }
        public uint LastState { get; set; }
    }
}

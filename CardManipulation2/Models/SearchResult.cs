using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardManipulation.Models
{
    public class SearchResult
    {
        public int Diff { get; set; }
        public uint Index { get; set; }
        public int Offset { get; set; }
        public uint LastState { get; set; }
        public bool Initiative { get; set; }
        public List<int> Deck { get; set; }
        public List<string> Cards { get; set; }
    }
}

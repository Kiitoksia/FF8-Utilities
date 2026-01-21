using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardManipulation.Models
{
    public class PatternParseResult
    {
        public string Raw { get; set; }
        public List<List<int>> Deck { get; set; }
        public bool? Initiative { get; set; }
        public string Error { get; set; }
    }
}

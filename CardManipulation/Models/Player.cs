using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardManipulation.Models
{
    public class PlayerProfile
    {
        public string Key { get; set; }
        public string Name { get; set; }
        public string NameEn { get; set; }
        public List<int> Rares { get; set; }
        public int RareLimit { get; set; }
        public List<int> Levels { get; set; }
    }
}

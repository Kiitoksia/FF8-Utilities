using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardManipulation.Models
{
    public class Card
    {
        public int Id { get; set; }
        public int[] Urdl { get; set; }
        public string Name { get; set; }
        public string NameEn { get; set; }
        public int Level { get; set; }
        public int Row { get; set; }
        public bool IsRare { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZellCardManip.Entities
{
    public class CardFormation
    {
        public CardFormation()
        {
            Cards = new List<Card>();
        }

        public int Index { get; set; }
        public long Offset { get; set; }
        public List<Card> Cards { get; set; }
    }
}

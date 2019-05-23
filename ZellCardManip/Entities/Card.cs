using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZellCardManip.Entities
{
    [DebuggerDisplay("{Name}")]
    public class Card
    {
        public Card(int id, int up, int right, int down, int left, int level, int row, string name, Element element, bool rare)
        {
            ID = id;
            Up = up;
            Left = left;
            Right = right;
            Down = down;
            Level = level;
            Row = row;
            Name = name;
            Element = element;
            Rare = rare;
        }

        public int ID { get; }
        public int Up { get; }
        public int Left { get; }
        public int Right { get; }
        public int Down { get; }
        public int Level { get; }
        public int Row { get; }
        public string Name { get; }
        public Element Element { get; }
        public bool Rare { get; }
    }
}

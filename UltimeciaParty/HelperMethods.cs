using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UltimeciaParty
{
    public static class HelperMethods
    {
        public static void ParseArguments(string input)
        {
            List<Direction> directions = input.Select(s =>
            {
                switch (s)
                {
                    case '2':
                        return Direction.Down;
                    case '4':
                        return Direction.Left;
                    case '6':
                        return Direction.Right;
                    case '8':
                        return Direction.Up;
                    default:
                        return Direction.Unknown;
                }                
            }).ToList();
        }
    }
}

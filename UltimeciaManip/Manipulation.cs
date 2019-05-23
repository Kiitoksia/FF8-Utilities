using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UltimeciaManip.Entities;

namespace UltimeciaManip
{
    public static class Manipulation
    {
        public static PartyFormation[] GetUltimeciaFormations(Direction[] directions, bool japanese = false)
        {
            PartyFormation[] possibleFormations = japanese ? Const.PartyFormationsJP : Const.PartyFormations;
            possibleFormations = possibleFormations.Where(p => p.IsMatch(directions)).ToArray();

            return possibleFormations;
        }

        public static Direction ToDirection(this char key)
        {
            switch (char.ToLower(key))
            {
                case '2':
                case 's':
                    return Direction.Down;
                case '4':
                case 'a':
                    return Direction.Left;
                case '6':
                case 'd':
                    return Direction.Right;
                case 'w':
                case '8':
                    return Direction.Up;
                default:
                    return Direction.Unknown;
            }
        }

        public static char ToDirectionCharacter(this Direction direction)
        {
            switch (direction)
            {
                case Direction.Up:
                    return '8';
                case Direction.Down:
                    return '2';
                case Direction.Left:
                    return '4';
                case Direction.Right:
                    return '6';
                default:
                    return '.';
            }
        }
    }
}

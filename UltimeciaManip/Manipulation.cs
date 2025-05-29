using FF8Utilities.Data;
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
        public static PartyFormation[] GetUltimeciaFormations(Direction[] directions, Platform platform, bool hardReset)
        {
            PartyFormation[] formations = null;
            switch (platform)
            {
                case Platform.PS2:
                    formations = Const.PartyFormationsNA;
                    break;
                case Platform.PS2JP:
                    formations = Const.PartyFormationsJP;
                    break;
                case Platform.PC:
                case Platform.PCLite:
                    formations = Const.PartyFormationsPC;
                    break;
            }

            int from = hardReset ? 0 : 1800;
            int to = hardReset ? 1999 : 3799;
            if (platform == Platform.PCLite && !hardReset)
            {
                from = 800;
                to = 2799;
            }

            IEnumerable<PartyFormation> queriedFormations = formations;
            if (from != -1) queriedFormations = queriedFormations.Where(t => t.Index >= from);
            if (to != -1) queriedFormations = queriedFormations.Where(t => t.Index <= to);
            queriedFormations = queriedFormations.Where(t => t.IsMatch(directions));
            
            return queriedFormations.ToArray();
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

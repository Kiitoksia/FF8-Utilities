using FF8Utilities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using UltimeciaManip.Entities;

namespace UltimeciaManip
{
    public static class Manipulation
    {
        public static PartyFormation[] GetUltimeciaFormations(Direction[] directions, Platform platform, UltimeciaManipLanguage language)
        {
            var options = new Models.FinalPartyManipOptions();
            switch (platform)
            {
                case Platform.PS2:
                case Platform.PS2JP:
                    switch (language)
                    {
                        case UltimeciaManipLanguage.English:
                            options.LastMapDuration = 22.7;
                            break;
                        case UltimeciaManipLanguage.Japanese:
                            options.LastMapDuration = 22;
                            break;
                        default: 
                            MessageBox.Show("Language not supported for this platform.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                            break;
                    }
                    break;
                case Platform.PC:
                case Platform.PCLite:
                    switch (language)
                    {
                        case UltimeciaManipLanguage.English:
                            options.LastMapDuration = 21.5;
                            break;
                        case UltimeciaManipLanguage.Japanese:
                            options.LastMapDuration = 21.2; // PC Remaster only
                            break;
                        case UltimeciaManipLanguage.French:
                            options.LastMapDuration = 22;
                            break;
                        default: throw new NotImplementedException();
                    }
                    break;
                default: throw new NotImplementedException();
            }

            UltiManip manip = new UltiManip(options);
            return manip.SearchLastParty(directions);
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

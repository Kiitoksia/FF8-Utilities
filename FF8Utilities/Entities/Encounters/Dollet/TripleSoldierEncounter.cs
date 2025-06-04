using FF8Utilities.Interfaces;
using FF8Utilities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Media3D;

namespace FF8Utilities.Entities.Encounters.Dollet
{
    public class TripleSoldierEncounter : BaseModel, IEncounter
    {
        private int _squallAttacks;
        private int _seiferAttacks;
        private int _zellAttacks;
        private int _soldierAttacks;
        private ThreePersonFanfareCamera? _camera;

        public TripleSoldierEncounter()
        {
            ClearCameraCommand = new Command(() => true, (s, e) => Camera = null);
        }

        public int SquallAttacks
        {
            get => _squallAttacks;
            set
            {
                if (value == _squallAttacks) return;
                _squallAttacks = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(RngAddition));
            }
        }

        public int SeiferAttacks
        {
            get => _seiferAttacks;
            set
            {
                if (value == _seiferAttacks) return;
                _seiferAttacks = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(RngAddition));
            }
        }

        public int ZellAttacks
        {
            get => _zellAttacks;
            set
            {
                if (value == _zellAttacks) return;
                _zellAttacks = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(RngAddition));
            }
        }

        public int SoldierAttacks
        {
            get => _soldierAttacks;
            set
            {
                if (value == _soldierAttacks) return;
                _soldierAttacks = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(RngAddition));
            }
        }

        public int Base => 22;
        public int RngAddition
        {
            get
            {
                int output = SquallAttacks * 2;
                output += SeiferAttacks * 2;
                output += ZellAttacks * 4;
                output += SoldierAttacks * 2;

                switch (Camera)
                {
                    case null:
                        break;
                    case ThreePersonFanfareCamera.OneToOne:
                        output += 3;
                        break;
                    case ThreePersonFanfareCamera.SingleCharacter:
                        output += 2;
                        break;
                    case ThreePersonFanfareCamera.ThreeCharacters:
                        output += 4;
                        break;
                    default:
                        throw new ArgumentOutOfRangeException(nameof(Camera), Camera, "Camera not recognised");
                }

                return Base + output;
            }
        }

        public ThreePersonFanfareCamera? Camera
        {
            get => _camera;
            set
            {
                if (value == _camera) return;
                _camera = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(RngAddition));
            }
        }


        public string Description => "Soldiers x3";

        public Command ClearCameraCommand { get; }
    }
}

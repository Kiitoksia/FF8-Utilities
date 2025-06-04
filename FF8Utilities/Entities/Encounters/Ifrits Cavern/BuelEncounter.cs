using FF8Utilities.Interfaces;
using FF8Utilities.Models;
using System;
using System.Windows.Media.Media3D;

namespace FF8Utilities.Entities.Encounters.Ifrits_Cavern
{
    public class BuelEncounter : BaseModel, IEncounter
    {
        private int _buelAttacks;
        private int _squallAttacks;
        private TwoPersonFanfareCamera? _camera;


        public BuelEncounter()
        {
            ClearCameraCommand = new Command(() => true, (s, e) => Camera = null);
        }

        public int BuelAttacks
        {
            get => _buelAttacks;
            set
            {
                if (value == _buelAttacks) return;
                _buelAttacks = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(RngAddition));
            }
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

        public TwoPersonFanfareCamera? Camera
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


        public int RngAddition
        {
            get
            {
                int output = SquallAttacks * 2;
                output += BuelAttacks * 5;
                switch (Camera)
                {
                    case null:
                        break;
                    case TwoPersonFanfareCamera.SingleCharacter:
                        output += 2;
                        break;
                    case TwoPersonFanfareCamera.TwoCharacters:
                        output += 3;
                        break;
                    default:
                        throw new ArgumentOutOfRangeException(nameof(output), Camera, "Camera type not recognised");
                }

                return Base + output;
            }
        }
        public string Description => "Buel";
        public int Base => 11;

        public Command ClearCameraCommand { get; }

    }
}

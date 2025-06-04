using System;
using System.ComponentModel;
using FF8Utilities.Interfaces;
using FF8Utilities.Models;

namespace FF8Utilities.Entities.Encounters.Ifrits_Cavern
{
    public class TwoBatsEncounter : BaseModel, IEncounter
    {
        private int _squallAttacks;
        private TwoPersonFanfareCamera? _camera;

        public TwoBatsEncounter()
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

        public string Description => "2x Bats";
        public int Base => 15;

        public Command ClearCameraCommand { get; }
    }
}

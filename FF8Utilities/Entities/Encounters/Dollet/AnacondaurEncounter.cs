using System;
using FF8Utilities.Interfaces;
using FF8Utilities.Models;

namespace FF8Utilities.Entities.Encounters.Dollet
{
    public class AnacondaurEncounter : BaseModel, IEncounter
    {
        private int _squallPhysicals;
        private int _seiferAttacks;
        private int _zellAttacks;
        private int _limits = 1;
        private int _rolls;
        private int _blind;
        private ThreePersonFanfareCamera? _camera;

        public AnacondaurEncounter()
        {

        }

        public int SquallPhysicals
        {
            get => _squallPhysicals;
            set
            {
                if (value == _squallPhysicals) return;
                _squallPhysicals = value;
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

        public int Limits
        {
            get => _limits;
            set
            {
                if (value == _limits) return;
                _limits = value;
                OnPropertyChanged();
            }
        }

        public int Rolls
        {
            get => _rolls;
            set
            {
                if (value == _rolls) return;
                _rolls = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(RngAddition));
            }
        }

        public int Blind
        {
            get => _blind;
            set
            {
                if (value == _blind) return;
                _blind = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(RngAddition));
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

        public int Base => 14;
        public int RngAddition
        {
            get
            {
                int output = SquallPhysicals * 2;
                output += SeiferAttacks * 2;
                output += ZellAttacks * 4;
                output += Rolls * 3;
                output += Limits;
                output += Blind;

                switch (Camera)
                {
                    case null:
                        break;
                    case ThreePersonFanfareCamera.SingleCharacter:
                        output += 2;
                        break;
                    case ThreePersonFanfareCamera.ThreeCharacters:
                        output += 4;
                        break;
                    case ThreePersonFanfareCamera.OneToOne:
                        output += 3;
                        break;
                    default:
                        throw new ArgumentOutOfRangeException(nameof(Camera), Camera, "Camera not recognised");
                }

                return Base + output;
            }
        }

        public string Description => "Anacondaur";
    }
}

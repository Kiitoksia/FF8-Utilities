using FF8Utilities.Interfaces;
using FF8Utilities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FF8Utilities.Entities.Encounters.Diablos
{
    public class DiablosEncounter : BaseModel, IEncounter
    {
        private int _squallAttacks;
        private int _zellAttacks;
        private int _gravija;
        private ThreePersonFanfareCamera? _camera;
        private int _limits = 1;

        public int Base => 13;

        public int RngAddition
        {
            get
            {
                int output = SquallAttacks * 2;
                output += ZellAttacks * 4;
                output += Gravija;
                output += Limits;

                switch (Camera)
                {
                    case null: 
                        break;
                    case ThreePersonFanfareCamera.SingleCharacter:
                        output += 2;
                        break;
                    case ThreePersonFanfareCamera.ThreeCharacters:
                        output += 3;
                        break;
                    case ThreePersonFanfareCamera.OneToOne:
                        output += 4;
                        break;
                    default:
                        throw new ArgumentOutOfRangeException(nameof(Camera), Camera, "Camera not recognised");
                }

                return Base + output;
            }
        }

        public string Description => "Diablos";

        public int SquallAttacks
        {
            get => _squallAttacks;
            set
            {
                if (_squallAttacks == value) return;
                _squallAttacks = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(RngAddition));
            }
        }
        public int ZellAttacks
        {
            get => _zellAttacks;
            set
            {
                if (_zellAttacks == value) return;
                _zellAttacks = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(RngAddition));
            }
        }
        public int Gravija
        {
            get => _gravija;
            set
            {
                if (_gravija == value) return;
                _gravija = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(RngAddition));
            }
        }

        public ThreePersonFanfareCamera? Camera
        {
            get => _camera;
            set
            {
                if (_camera == value) return;
                _camera = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(RngAddition));
            }
        }

        public int Limits
        {
            get => _limits;
            set
            {
                if (_limits == value) return;
                _limits = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(RngAddition));
            }
        }
    }
}

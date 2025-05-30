using FF8Utilities.Interfaces;
using FF8Utilities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FF8Utilities.Entities.Encounters.Diablos
{
    public class GranaldoEncounter : BaseModel, IEncounter
    {
        private int _limits = 1;
        private int _squallAttacks;
        private int _granaldoAttacks;
        private TwoPersonFanfareCamera? _camera;
        private int _shiva = 1;

        public int Base => 22;

        public int RngAddition
        {
            get
            {
                int output = SquallAttacks * 2;
                output += Limits;
                output += Shiva;
                output += GranaldoAttacks;

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
                        throw new ArgumentOutOfRangeException(nameof(Camera), Camera, "Camera not recognised");
                }

                return Base + output;
            }
        }

        public string Description => "Granaldo";

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

        public int Shiva
        {
            get => _shiva;
            set
            {
                if (_shiva == value) return;
                _shiva = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(RngAddition));
            }
        }

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
        public int GranaldoAttacks
        {
            get => _granaldoAttacks;
            set
            {
                if (_granaldoAttacks == value) return;
                _granaldoAttacks = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(RngAddition));
            }
        }
        public TwoPersonFanfareCamera? Camera
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
    }
}

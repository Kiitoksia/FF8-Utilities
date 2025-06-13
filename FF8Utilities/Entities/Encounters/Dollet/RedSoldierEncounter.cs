using FF8Utilities.Interfaces;
using FF8Utilities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FF8Utilities.Entities.Encounters.Dollet
{
    public class RedSoldierEncounter : BaseModel, IEncounter
    {
        private int _squallAttacks;
        private int _zellAttacks;
        private int _machineGuns;
        private int _arms;
        private ThreePersonFanfareCamera? _camera;

        public RedSoldierEncounter()
        {
            ClearCameraCommand = new Command(() => true, (s, e) => Camera = null);
        }



        public int Base => 13;

        public int RngAddition
        {
            get
            {
                int output = SquallAttacks * 2;
                output += ZellAttacks * 4;
                output += MachineGuns * 5;
                output += Arms * 4;

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

        public string Description => "Red Elite Soldier";

        public int SquallAttacks
        {
            get => _squallAttacks;
            set
            {
                if (_squallAttacks == value)
                {
                    return;
                }

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
                if (_zellAttacks == value)
                {
                    return;
                }

                _zellAttacks = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(RngAddition));
            }
        }

        public int MachineGuns
        {
            get => _machineGuns;
            set
            {
                if (_machineGuns == value)
                {
                    return;
                }

                _machineGuns = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(RngAddition));
            }
        }

        public int Arms
        {
            get => _arms;
            set
            {
                if (_arms == value)
                {
                    return;
                }

                _arms = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(RngAddition));
            }
        }

        public ThreePersonFanfareCamera? Camera
        {
            get => _camera;
            set
            {
                if (_camera == value)
                {
                    return;
                }

                _camera = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(RngAddition));
            }
        }

        public Command ClearCameraCommand { get; }
    }
}

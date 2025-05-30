using System;
using FF8Utilities.Interfaces;
using FF8Utilities.Models;

namespace FF8Utilities.Entities.Encounters.Dollet
{
    public class ElvoretEncounter : BaseModel, IEncounter
    {
        private int _squallAttacks;
        private int _zellAttacks;
        private int _limits = 4;
        private int _biggsMachineGuns;
        private int _biggsArms;
        private int _wedgeFires;
        private int _elvoretFireThunder;
        private int _elvoretStormBreath;
        private ElvoretFanfareCamera? _camera;

        public ElvoretEncounter()
        {

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
                OnPropertyChanged(nameof(RngAddition));
            }
        }

        public int BiggsMachineGuns
        {
            get => _biggsMachineGuns;
            set
            {
                if (value == _biggsMachineGuns) return;
                _biggsMachineGuns = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(RngAddition));
            }
        }

        public int BiggsArms
        {
            get => _biggsArms;
            set
            {
                if (value == _biggsArms) return;
                _biggsArms = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(RngAddition));
            }
        }

        public int WedgeFires
        {
            get => _wedgeFires;
            set
            {
                if (value == _wedgeFires) return;
                _wedgeFires = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(RngAddition));
            }
        }

        public int ElvoretFireThunder
        {
            get => _elvoretFireThunder;
            set
            {
                if (value == _elvoretFireThunder) return;
                _elvoretFireThunder = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(RngAddition));
            }
        }

        public int ElvoretStormBreath
        {
            get => _elvoretStormBreath;
            set
            {
                if (value == _elvoretStormBreath) return;
                _elvoretStormBreath = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(RngAddition));
            }
        }

        public ElvoretFanfareCamera? Camera
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

        public int Base => 16;
        public int RngAddition
        {
            get
            {
                int output = SquallAttacks * 2;
                output += ZellAttacks * 4;
                output += Limits;
                output += BiggsMachineGuns * 5;
                output += BiggsArms * 4;
                output += WedgeFires * 28;
                output += 3; // Elovret Appear
                output += ElvoretFireThunder * 12;
                output += ElvoretStormBreath;

                switch (Camera)
                {
                    case null:
                        break;
                    case ElvoretFanfareCamera.OneToOne:
                    case ElvoretFanfareCamera.CharacterDead:
                        output += 2;
                        break;
                    case ElvoretFanfareCamera.Other:
                        output += 3;
                        break;
                    default:
                        throw new ArgumentOutOfRangeException(nameof(Camera), Camera, "Camera not recognised");
                }

                return Base + output;
            }
        }
        public string Description => "Elvoret";

    }
}

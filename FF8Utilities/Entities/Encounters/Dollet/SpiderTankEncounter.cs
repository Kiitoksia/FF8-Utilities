using FF8Utilities.Interfaces;
using FF8Utilities.Models;

namespace FF8Utilities.Entities.Encounters.Dollet
{
    public class SpiderTankEncounter : BaseModel, IEncounter
    {
        private int _squallAttacks;
        private int _zellAttacks;
        private int _limits = 1;
        private int _rayBombs;
        private bool _extraEncounter;

        public SpiderTankEncounter()
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

        public int RayBombs
        {
            get => _rayBombs;
            set
            {
                if (value == _rayBombs) return;
                _rayBombs = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(RngAddition));
            }
        }

        public int Base => 13;
        public int RngAddition
        {
            get
            {
                int output = SquallAttacks * 2;
                output += ZellAttacks * 4;
                output += Limits;
                output += RayBombs;
                if (ExtraEncounter) output += Base;
                return Base + output;
            }
        }

        public bool ExtraEncounter
        { 
            get => _extraEncounter; 
            set 
            {
                _extraEncounter = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(RngAddition));
            }
            
        }

        public string Description => "Spider Tank";
    }
}

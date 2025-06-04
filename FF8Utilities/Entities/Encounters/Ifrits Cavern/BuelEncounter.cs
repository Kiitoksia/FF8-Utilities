using FF8Utilities.Interfaces;
using FF8Utilities.Models;

namespace FF8Utilities.Entities.Encounters.Ifrits_Cavern
{
    public class BuelEncounter : BaseModel, IEncounter
    {
        private int _buelAttacks;
        private int _squallAttacks;

        public BuelEncounter()
        {

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

        public int RngAddition => Base + BuelAttacks * 5 + SquallAttacks * 2;
        public string Description => "Buel";
        public int Base => 11;

    }
}

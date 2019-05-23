using FF8Utilities.Interfaces;
using FF8Utilities.Models;

namespace FF8Utilities.Entities.Encounters.Ifrits_Cavern
{
    public class IfritEncounter : BaseModel, IEncounter
    {
        private int _squallAttacks;
        private int _limits;
        private int _ifritPunches;

        public IfritEncounter()
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

        public int IfritPunches
        {
            get => _ifritPunches;
            set
            {
                if (value == _ifritPunches) return;
                _ifritPunches = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(RngAddition));
            }
        }


        public int RngAddition
        {
            get
            {
                int output = SquallAttacks * 2;
                output += Limits;
                output += IfritPunches * 2;
                output += 2; // Always add 2 for the camera
                return Base + output;
            }
        }

        public int Base => 10;

        public string Description => "Ifrit";
    }
}

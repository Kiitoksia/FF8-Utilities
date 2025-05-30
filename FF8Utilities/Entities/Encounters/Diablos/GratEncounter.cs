using FF8Utilities.Interfaces;
using FF8Utilities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FF8Utilities.Entities.Encounters.Diablos
{
    public class GratEncounter : BaseModel, IEncounter
    {
        private int _squallAttacks;
        private int _vampireBites;
        private int _sleepingGas;

        public int Base => 11;

        public int RngAddition
        {
            get
            {
                int output = SquallAttacks * 2;
                output += VampireBites * 33;
                output += SleepingGas;
                return Base + output;
            }
        }

        public string Description => "Grat";

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
        public int VampireBites
        {
            get => _vampireBites;
            set
            {
                if (_vampireBites == value) return;
                _vampireBites = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(RngAddition));
            }
        }

        public int SleepingGas
        {
            get => _sleepingGas;
            set
            {
                if (_sleepingGas == value) return;
                _sleepingGas = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(RngAddition));
            }
        }
    }
}

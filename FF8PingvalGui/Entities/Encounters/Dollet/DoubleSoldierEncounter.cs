﻿using FF8Utilities.Interfaces;
using FF8Utilities.Models;

namespace FF8Utilities.Entities.Encounters.Dollet
{
    public class DoubleSoldierEncounter : BaseModel, IEncounter
    {
        private int _squallAttacks;
        private int _seiferAttacks;
        private int _zellAttacks;
        private int _soldierAttacks;

        public DoubleSoldierEncounter()
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

        public int SoldierAttacks
        {
            get => _soldierAttacks;
            set
            {
                if (value == _soldierAttacks) return;
                _soldierAttacks = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(RngAddition));
            }
        }

        public int Base => 18;
        public int RngAddition
        {
            get
            {
                int output = SquallAttacks * 2;
                output += SeiferAttacks * 2;
                output += ZellAttacks * 4;
                output += SoldierAttacks * 2;
                return Base + output;
            }
        }
        public string Description => "Soldiers x2";
    }
}

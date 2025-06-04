using System;
using FF8Utilities.Interfaces;
using FF8Utilities.Models;

namespace FF8Utilities.Entities.Encounters
{
    public class WorldMapEncounter : BaseModel, IEncounter
    {
        private WorldMapFormation? _formation;
        private int _quantity;

        public WorldMapEncounter()
        {

        }

        public WorldMapFormation? Formation
        {
            get => _formation;
            set
            {
                if (value == _formation) return;
                _formation = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(RngAddition));
            }
        }

        public string FormationDisplay => Formation?.GetDescription();

        #region Implementation of IEncounter

        public int RngAddition
        {
            get
            {
                switch (Formation)
                {
                    case null:
                        return 0 * Quantity;
                    case WorldMapFormation.Caterchipillar:
                    case WorldMapFormation.TRex:
                        return 10 * Quantity;
                    case WorldMapFormation.BiteBug:
                    case WorldMapFormation.GlacialEye:
                        return 11 * Quantity;
                    case WorldMapFormation.BiteBugx2:
                        return 15 * Quantity;
                    case WorldMapFormation.BiteBugx3:
                        return 19 * Quantity;
                    case WorldMapFormation.CaterchipillarAnd2xBiteBug:
                        return 18 * Quantity;
                    default:
                        throw new ArgumentOutOfRangeException(nameof(RngAddition), Formation, "Formation not recognised");
                }
            }
        }


        /// <summary>
        /// Base is ignored in a world map encounter (Calculated from the formation)
        /// </summary>
        public int Base => 0;

        public int Quantity
        {
            get => _quantity;
            set
            {
                if (value == _quantity) return;
                _quantity = value;
                OnPropertyChanged();
            }
        }

        public string Description => "World Map";

        #endregion
    }
}

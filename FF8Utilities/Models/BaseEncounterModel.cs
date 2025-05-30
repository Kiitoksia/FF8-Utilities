using FF8Utilities.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FF8Utilities.Models
{
    public abstract class BaseEncounterModel : BaseModel
    {
        private Enum _fanfare;
        private int _rngAddition;
        private Type _fanfareType;

        public BaseEncounterModel(string description, int baseAddition, Type fanfareType = null)
        {
            Description = description;
            Base = baseAddition;
            Abilities = new BindingList<EncounterAbilityModel>();
            Abilities.ListChanged += (s, e) => CalculateAddition();
            _fanfareType = fanfareType;

        }

        public string Description { get; }

        public int Base { get; }

        public int RngAddition
        {
            get => _rngAddition; private set
            {
                if (_rngAddition == value)
                    return;
                _rngAddition = value;
                OnPropertyChanged();
            }
        }

        public BindingList<EncounterAbilityModel> Abilities { get; }

        public Command ClearCameraCommand { get; }

        public Enum Fanfare
        {
            get => _fanfare; set
            {
                if (_fanfare == value)
                    return;
                _fanfare = value;
                OnPropertyChanged();
            }
        }


        public void CalculateAddition()
        {
            int output = 0;
            foreach (EncounterAbilityModel ability in Abilities)
            {
                output += ability.Addition * ability.Count;
            }

            if (Fanfare != null)
            {
                if (Fanfare is TwoPersonFanfareCamera twoPersonCamera)
                {
                    switch (twoPersonCamera)
                    {
                        case TwoPersonFanfareCamera.SingleCharacter:
                            output += 2;
                            break;
                        case TwoPersonFanfareCamera.TwoCharacters:
                            output += 3;
                            break;
                        default:
                            throw new Exception("Camera type not recognised");
                    }
                }
                else if (Fanfare is ThreePersonFanfareCamera threePersonCamera)
                {
                    switch (threePersonCamera)
                    {

                    }
                }
            }

            RngAddition = output;
        }

    }
}

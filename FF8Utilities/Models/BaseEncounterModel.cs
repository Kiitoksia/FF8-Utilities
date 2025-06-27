using FF8Utilities.Entities;
using FF8Utilities.Extensions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Media3D;
using System.Xml.Linq;

namespace FF8Utilities.Models
{
    public abstract class BaseEncounterModel : BaseModel
    {
        private Enum _fanfare;
        private bool _isToggled;
        private bool _showFanfare;

        public BaseEncounterModel(string description, int baseAddition, Type fanfareType = null)
        {
            Description = description;
            Base = baseAddition;
            Abilities = new BindingList<EncounterAbilityModel>();
            Abilities.ListChanged += (s, e) => OnPropertyChanged(nameof(Output));

            _showFanfare = fanfareType != null;
            FanfareTypeList = new BindingList<EnumerationMember>();

            if (fanfareType != null)
            {
                FanfareTypeList.Add(new EnumerationMember { Value = null, Description = "None", IsSelected = true });
                foreach (Enum enumValue in Enum.GetValues(fanfareType))
                {
                    FanfareTypeList.Add(new EnumerationMember { Value = enumValue, Description = ((Enum)enumValue).GetDescription() });
                }
            }

            PlusOneToAllCommand = new Command(() => true, (s, e) =>
            {
                foreach (EncounterAbilityModel ability in Abilities)
                {
                    ability.Count++;
                }
            });
        }

      
        public string Description { get; }

        public int Base { get; }

        public int Output
        {
            get
            {
                int output = Base;
                foreach (EncounterAbilityModel ability in Abilities)
                {
                    output += ability.Output;
                }

                if (Fanfare != null)
                {
                    if (Fanfare is ThreePersonFanfareCamera threePersonCamera)
                    {
                        switch (threePersonCamera)
                        {
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
                                throw new ArgumentOutOfRangeException(nameof(Camera), Fanfare, "Camera not recognised");
                        }
                    }
                    else if (Fanfare is TwoPersonFanfareCamera twoPersonCamera)
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
                                throw new ArgumentOutOfRangeException(nameof(Camera), Fanfare, "Camera not recognised");
                        }
                    }
                    else if (Fanfare is ElvoretFanfareCamera elvoretCamera)
                    {
                        switch (elvoretCamera)
                        {
                            case ElvoretFanfareCamera.OneToOne:
                            case ElvoretFanfareCamera.CharacterDead:
                                output += 2;
                                break;
                            case ElvoretFanfareCamera.Other:
                                output += 3;
                                break;
                            default:
                                throw new ArgumentOutOfRangeException(nameof(Camera), Fanfare, "Camera not recognised");
                        }
                    }
                }

                output += CustomRNGAddition;                
                return output;
            }
        }

        protected virtual int CustomRNGAddition { get; }

        public BindingList<EncounterAbilityModel> Abilities { get; }

        public Command PlusOneToAllCommand { get; }

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




        public BindingList<EnumerationMember> FanfareTypeList { get; }

        public bool FanfareVisible => _showFanfare;

        public string ToggleOptionDescription { get; protected set; }

        public bool IsToggled
        {
            get => _isToggled;
            set
            {
                if (_isToggled == value)
                {
                    return;
                }

                _isToggled = value;
                OnPropertyChanged();
            }
        }

        public bool ShowToggleOption => !string.IsNullOrEmpty(ToggleOptionDescription);

        public bool ShowPlusOneToAllButton { get; protected set; }
    }
}

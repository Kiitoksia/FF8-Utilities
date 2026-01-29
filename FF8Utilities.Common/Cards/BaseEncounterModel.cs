using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Xml.Linq;

namespace FF8Utilities.Common.Cards
{
    public abstract class BaseEncounterModel : BaseModel
    {
        private Enum _fanfare;
        private bool _isToggled;
        private bool _usesFanfare;
        private string _notes;


        public BaseEncounterModel(string description, int baseAddition, Type fanfareType = null)
        {
            Description = description;
            Base = baseAddition;
            Abilities = new BindingList<EncounterAbilityModel>();
            Abilities.ListChanged += (s, e) =>
            {
                OnPropertyChanged(nameof(Output));
            };

            _usesFanfare = fanfareType != null;
            FanfareTypeList = new BindingList<EnumerationMember>();

            if (fanfareType != null)
            {
                FanfareTypeList.Add(new EnumerationMember { Value = null, Description = "None", IsSelected = true });
                foreach (Enum enumValue in Enum.GetValues(fanfareType))
                {
                    FanfareTypeList.Add(new EnumerationMember { Value = enumValue, Description = ((Enum)enumValue).GetDescription() });
                }
            }

            PlusOneToAllCommand = new RelayCommand(()=>
            {
                foreach (EncounterAbilityModel ability in Abilities)
                {
                    ability.Count++;
                }
            });
        }

        public void FromXml(XElement xml)
        {
            Notes = xml.Attribute(nameof(Notes))?.Value;
            if (bool.TryParse(xml.Attribute(nameof(IsToggled))?.Value ?? string.Empty, out bool isToggled))
            {
                IsToggled = isToggled;
            }
            foreach (XElement abilityXml in xml.Elements("Ability"))
            {
                string description = abilityXml.Attribute(nameof(EncounterAbilityModel.Description))?.Value;
                if (string.IsNullOrWhiteSpace(description)) continue;

                EncounterAbilityModel ability = Abilities.SingleOrDefault(t => t.Description == description);
                if (bool.TryParse(abilityXml.Attribute(nameof(EncounterAbilityModel.IsVisible))?.Value ?? string.Empty, out bool isVisible))
                {
                    ability.IsVisible = isVisible;
                }
                
                if (int.TryParse(abilityXml.Attribute(nameof(EncounterAbilityModel.Count))?.Value ?? string.Empty, out int count))
                {
                    ability.Count = count;
                }
            }
        }

        public XElement ToXml(string identifier)
        {
            XElement xml = new XElement(nameof(BaseEncounterModel));
            xml.Add(new XAttribute("Identifier", identifier));
            xml.Add(new XAttribute(nameof(Notes), Notes ?? string.Empty));
            xml.Add(new XAttribute(nameof(IsToggled), IsToggled));
            foreach (EncounterAbilityModel ability in Abilities)
            {
                XElement abilityXml = new XElement("Ability");
                abilityXml.Add(new XAttribute(nameof(EncounterAbilityModel.Description), ability.Description));
                abilityXml.Add(new XAttribute(nameof(EncounterAbilityModel.IsVisible), ability.IsVisible));
                abilityXml.Add(new XAttribute(nameof(EncounterAbilityModel.Count), ability.Count));
                xml.Add(abilityXml);
            }

            return xml;
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
                                throw new ArgumentOutOfRangeException(nameof(Fanfare), Fanfare, "Camera not recognised");
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
                                throw new ArgumentOutOfRangeException(nameof(Fanfare), Fanfare, "Camera not recognised");
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
                                throw new ArgumentOutOfRangeException(nameof(Fanfare), Fanfare, "Camera not recognised");
                        }
                    }
                }

                output += CustomRNGAddition;                
                return output;
            }
        }

        protected virtual int CustomRNGAddition { get; }

        public BindingList<EncounterAbilityModel> Abilities { get; }

        public ICommand PlusOneToAllCommand { get; }

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

        public bool FanfareVisible => _usesFanfare;

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

        public string Notes
        {
            get => _notes;
            set
            {
                if (_notes == value)
                {
                    return;
                }

                _notes = value;
                OnPropertyChanged();
            }
        }
    }
}

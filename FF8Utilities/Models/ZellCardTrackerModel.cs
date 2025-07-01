using FF8Utilities.Dialogs;
using FF8Utilities.Entities;
using FF8Utilities.Entities.Encounters;
using FF8Utilities.Entities.Encounters.Diablos;
using FF8Utilities.Entities.Encounters.Dollet;
using FF8Utilities.Entities.Encounters.Ifrits_Cavern;
using LateQuistisManipulation;
using LateQuistisManipulation.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Media;
using System.Xml.Linq;

namespace FF8Utilities.Models
{
    public class ZellCardTrackerModel : BaseModel
    {
        private BindingList<WorldMapEncounter> _worldMapEncounters;
        private TwoBatsEncounter _twoBatsEncounter;
        private IfritEncounter _ifritEncounter;
        private BuelEncounter _buelEncounter;
        private TwoBatsEncounter _secondBatsEncounter;
        private BindingList<FishFinsEncounter> _fishFinEncounters;
        private DoubleSoldierEncounter _firstDolletEncounter;
        private DoubleSoldierEncounter _secondDolletEncounter;
        private SingleSoldierEncounter _thirdDolletEncounter;
        private SingleSoldierEncounter _fourthDolletEncounter;
        private SingleSoldierEncounter _bridgeEncounter;
        private AnacondaurEncounter _anacondaurEncounter;
        private SingleSoldierEncounter _postAnacondaurEncounter;
        private ElvoretEncounter _elvoretEncounter;
        private SpiderTankEncounter _spiderTankEncounter;
        private bool _didGetRedSoldierEncounter;
        private IfritEncounterType _ifritsCavernEncounterType = IfritEncounterType.Buel;
        private bool _didGetSecondBridgeEncounter;
        private TripleSoldierEncounter secondBridgeEncounter;
        private RedSoldierEncounter _redSoldierEncounter;
        private int _focusedTabIndex;
        private LateQuistisPattern _currentPattern;            
        private LateQuistis _lateQuistisManip;
        private SolidColorBrush _quistisMashTextBackgroundBrush = new SolidColorBrush(Colors.Transparent);
        private bool _quistisCardObtained;
        private bool _designMode;

        private const string TrackingSettingsFilename = "TrackingSettings.xml";



        private bool _initialised;

        public ZellCardTrackerModel()
        {
            WorldMapEncounters = new BindingList<WorldMapEncounter>();
            WorldMapEncounters.ListChanged += (s, e) =>
            {
                OnPropertyChanged(nameof(WorldMapEncounters));
                OnPropertyChanged(nameof(LateQuistisOutput));
                OnPropertyChanged(nameof(Output));
            };

            foreach (WorldMapFormation formation in Enum.GetValues(typeof(WorldMapFormation)))
            {
                WorldMapEncounters.Add(new WorldMapEncounter { Formation = formation });
            }



            TwoBatsEncounter = new TwoBatsEncounter();
            TwoBatsEncounter.PropertyChanged += EncounterPropertyChanged;
            IfritEncounter = new IfritEncounter();
            IfritEncounter.PropertyChanged += EncounterPropertyChanged;
            BuelEncounter = new BuelEncounter();
            BuelEncounter.PropertyChanged += EncounterPropertyChanged;
            SecondBatsEncounter = new TwoBatsEncounter();
            SecondBatsEncounter.PropertyChanged += EncounterPropertyChanged;
            
            FishFinEncounters = new BindingList<FishFinsEncounter>();
            
            switch (SettingsModel.Instance.DefaultFishFinEncounters)
            {
                case DefaultFishFinEncounters.ThreeBattles:
                    FishFinEncounters.Add(new FishFinsEncounter());
                    FishFinEncounters.Add(new FishFinsEncounter());
                    FishFinEncounters.Add(new FishFinsEncounter());
                    break;
                case DefaultFishFinEncounters.QuetzManip:
                    FishFinEncounters.Add(new FishFinsEncounter { Limits = 1 });
                    FishFinEncounters.Add(new FishFinsEncounter { SingleFishKilled = true, Limits = 0 });
                    break;
                default: throw new NotImplementedException();
            }

            foreach (FishFinsEncounter f in FishFinEncounters)
            {
                f.PropertyChanged += (s, e) =>
                {
                    OnPropertyChanged(nameof(Output));
                };
            }

            FishFinEncounters.ListChanged += (s, e) =>
            {
                OnPropertyChanged(nameof(FishFinEncounters));
                OnPropertyChanged(nameof(Output));
            };
            FirstDolletEncounter = new DoubleSoldierEncounter(false);
            FirstDolletEncounter.PropertyChanged += EncounterPropertyChanged;
            SecondDolletEncounter = new DoubleSoldierEncounter(false);
            SecondDolletEncounter.PropertyChanged += EncounterPropertyChanged;
            ThirdDolletEncounter = new SingleSoldierEncounter(false);
            ThirdDolletEncounter.PropertyChanged += EncounterPropertyChanged;
            FourthDolletEncounter = new SingleSoldierEncounter(true);
            FourthDolletEncounter.PropertyChanged += EncounterPropertyChanged;
            BridgeEncounter = new SingleSoldierEncounter(true);
            BridgeEncounter.PropertyChanged += EncounterPropertyChanged;
            SecondBridgeEncounter = new TripleSoldierEncounter();
            SecondBridgeEncounter.PropertyChanged += EncounterPropertyChanged;
            AnacondaurEncounter = new AnacondaurEncounter();
            AnacondaurEncounter.PropertyChanged += EncounterPropertyChanged;
            PostAnacondaurEncounter = new SingleSoldierEncounter(true);
            PostAnacondaurEncounter.PropertyChanged += EncounterPropertyChanged;
            ElvoretEncounter = new ElvoretEncounter();
            ElvoretEncounter.PropertyChanged += EncounterPropertyChanged;
            SpiderTankEncounter = new SpiderTankEncounter();
            SpiderTankEncounter.PropertyChanged += EncounterPropertyChanged;

            RedSoldierEncounter = new RedSoldierEncounter(false);
            RedSoldierEncounter.PropertyChanged += EncounterPropertyChanged;

            AddNewEncounterCommand = new Command(() => true, AddNewEncounter);
            AddNewHalfEncounterCommand = new Command(() => true, AddNewHalfEncounter);
            RemoveFishFinEncounterCommand = new Command<FishFinsEncounter>(() => FishFinEncounters.Count > 0, RemoveFishFinEncounter);

            LaunchQuistisPatternsCommand = new Command(() => true, LaunchQuistisPatterns);
            LaunchZellCommand = new Command(() => true, LaunchZell);

            IfritsCavernEncounterType = SettingsModel.Instance.IfritEncounterType;
            DidGetSecondBridgeEncounter = SettingsModel.Instance.Get2ndBridgeEncounter;
            DidGetRedSoldierEncounter = SettingsModel.Instance.GetRedSoldierEncounter;

            PropertyChanged += (s, e) =>
            {
                if (e.PropertyName == nameof(Output))
                {
                    OnPropertyChanged(nameof(LateQuistisOutput));
                }
                else if (e.PropertyName == nameof(DesignMode))
                {
                    if (!DesignMode) SaveEncounterDetails();
                }
            };

            _lateQuistisManip = new LateQuistis(Const.PackagesFolder);
            _initialised = true;

            try
            {
                string settingsFile = Path.Combine(Const.PackagesFolder, TrackingSettingsFilename);
                if (File.Exists(settingsFile))
                {
                    string settingsFileString = File.ReadAllText(settingsFile);
                    XElement xml = XElement.Parse(settingsFileString);
                    FromXml(xml);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Could not load tracking settings, defaults have been set\r\n{ex.Message}", "Error", MessageBoxButton.OK);
            }
            
        }

        private void FromXml(XElement xml)
        {
            foreach (XElement encounterXml in xml.Elements(nameof(BaseEncounterModel)))
            {
                BaseEncounterModel encounter;
                string identifier = encounterXml.Attribute("Identifier")?.Value;

                switch (identifier)
                {
                    case nameof(TwoBatsEncounter): encounter = TwoBatsEncounter; break;
                    case nameof(IfritEncounter): encounter = IfritEncounter; break;
                    case nameof(BuelEncounter): encounter = BuelEncounter; break;
                    case nameof(SecondBatsEncounter): encounter = SecondBatsEncounter; break;
                    case nameof(ThirdDolletEncounter): encounter = ThirdDolletEncounter; break;
                    case nameof(FourthDolletEncounter): encounter = FourthDolletEncounter; break;
                    case nameof(BridgeEncounter): encounter = BridgeEncounter; break;
                    case nameof(SecondBridgeEncounter): encounter = SecondBridgeEncounter; break;
                    case nameof(AnacondaurEncounter): encounter = AnacondaurEncounter; break;
                    case nameof(PostAnacondaurEncounter): encounter = PostAnacondaurEncounter; break;
                    case nameof(ElvoretEncounter): encounter = ElvoretEncounter; break;
                    case nameof(SpiderTankEncounter): encounter = SpiderTankEncounter; break;
                    case nameof(RedSoldierEncounter): encounter = RedSoldierEncounter; break;
                    default: continue; // Cannot parse
                }

                encounter.FromXml(encounterXml);
            }
        }

        private void SaveEncounterDetails()
        {
            XElement xml = new XElement("CardTrackingSettings");
            xml.Add(TwoBatsEncounter.ToXml(nameof(TwoBatsEncounter)));
            xml.Add(IfritEncounter.ToXml(nameof(IfritEncounter)));
            xml.Add(BuelEncounter.ToXml(nameof(BuelEncounter)));
            xml.Add(SecondBatsEncounter.ToXml(nameof(SecondBatsEncounter)));
            xml.Add(FirstDolletEncounter.ToXml(nameof(FirstDolletEncounter)));
            xml.Add(SecondDolletEncounter.ToXml(nameof(SecondDolletEncounter)));
            xml.Add(ThirdDolletEncounter.ToXml(nameof(ThirdDolletEncounter)));
            xml.Add(FourthDolletEncounter.ToXml(nameof(FourthDolletEncounter)));
            xml.Add(BridgeEncounter.ToXml(nameof(BridgeEncounter)));
            xml.Add(SecondBridgeEncounter.ToXml(nameof(SecondBridgeEncounter)));
            xml.Add(AnacondaurEncounter.ToXml(nameof(AnacondaurEncounter)));
            xml.Add(PostAnacondaurEncounter.ToXml(nameof(PostAnacondaurEncounter)));
            xml.Add(ElvoretEncounter.ToXml(nameof(ElvoretEncounter)));
            xml.Add(SpiderTankEncounter.ToXml(nameof(SpiderTankEncounter)));
            xml.Add(RedSoldierEncounter.ToXml(nameof(RedSoldierEncounter)));

            File.WriteAllText(Path.Combine(Const.PackagesFolder, TrackingSettingsFilename), xml.ToString());
        }

        public ZellCardCalculatorWindow Window { get; set; }

        private void EncounterPropertyChanged(object sender, PropertyChangedEventArgs arg)
        {
            OnPropertyChanged(nameof(LateQuistisOutput));
            OnPropertyChanged(nameof(Output));            
        }

        private void RemoveFishFinEncounter(object sender, FishFinsEncounter enc)
        {
            FishFinEncounters.Remove(enc);
        }

        private void AddNewEncounter(object sender, EventArgs eventArgs)
        {
            FishFinEncounters.Add(new FishFinsEncounter());
        }

        private void AddNewHalfEncounter(object sender, EventArgs eventArgs)
        {
            FishFinEncounters.Add(new FishFinsEncounter { SingleFishKilled = true, Limits = 1 });
        }

        private void LaunchQuistisPatterns(object sender, EventArgs eventArgs)
        {
            QuistisCardPatternWindow window = new QuistisCardPatternWindow(Window, _lateQuistisManip.GetPattern(LateQuistisOutput, true));
            window.Owner = Window;
            MainModel.Instance.LaunchCardScript(false, LateQuistisOutput);
            window.ShowDialog();
            if (!string.IsNullOrEmpty(window.ResultHex))
            {
                MainModel.Instance.UseCustomQuistisPattern = true;
                MainModel.Instance.CustomQuistisPattern = window.ResultHex;
                MainModel.Instance.Pattern = QuistisPattern.LateQuistis;
                QuistisCardObtained = true;
            }
            else
            {
                MainModel.Instance.UseCustomQuistisPattern = false;
                MainModel.Instance.CustomQuistisPattern = null;
                MainModel.Instance.Pattern = QuistisPattern.Elastoid_JellyEye;
                QuistisCardObtained = false;
            }                        
        }

        private void LaunchZell(object sender, EventArgs eventArgs)
        {
            MainModel.Instance.LaunchCardScript(true, Output);
        }

        public BindingList<WorldMapEncounter> WorldMapEncounters
        {
            get => _worldMapEncounters;
            set
            {
                if (value == _worldMapEncounters) return;
                _worldMapEncounters = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(Output));
                OnPropertyChanged(nameof(LateQuistisOutput));
            }
        }

        #region Ifrits Cavern

        public TwoBatsEncounter TwoBatsEncounter
        {
            get => _twoBatsEncounter;
            set
            {
                if (value == _twoBatsEncounter) return;
                _twoBatsEncounter = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(Output));
                OnPropertyChanged(nameof(LateQuistisOutput));
            }
        }

        

        public IfritEncounter IfritEncounter
        {
            get => _ifritEncounter;
            set
            {
                if (Equals(value, _ifritEncounter)) return;
                _ifritEncounter = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(Output));
                OnPropertyChanged(nameof(LateQuistisOutput));
            }
        }

        public BuelEncounter BuelEncounter
        {
            get => _buelEncounter;
            set
            {
                if (Equals(value, _buelEncounter)) return;
                _buelEncounter = value;
                OnPropertyChanged();
            }
        }

        public TwoBatsEncounter SecondBatsEncounter
        {
            get => _secondBatsEncounter; set
            {
                if (_secondBatsEncounter == value)
                    return;
                _secondBatsEncounter = value;
                OnPropertyChanged();
            }
        }

        public BindingList<FishFinsEncounter> FishFinEncounters
        {
            get => _fishFinEncounters;
            set
            {
                if (Equals(value, _fishFinEncounters)) return;
                _fishFinEncounters = value;
                OnPropertyChanged();
            }
        }

        #endregion

        #region Dollet

        public DoubleSoldierEncounter FirstDolletEncounter
        {
            get => _firstDolletEncounter;
            set
            {
                if (Equals(value, _firstDolletEncounter)) return;
                _firstDolletEncounter = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(Output));
                OnPropertyChanged(nameof(LateQuistisOutput));
            }
        }

        public DoubleSoldierEncounter SecondDolletEncounter
        {
            get => _secondDolletEncounter;
            set
            {
                if (Equals(value, _secondDolletEncounter)) return;
                _secondDolletEncounter = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(Output));
                OnPropertyChanged(nameof(LateQuistisOutput));
            }
        }

        public SingleSoldierEncounter ThirdDolletEncounter
        {
            get => _thirdDolletEncounter;
            set
            {
                if (Equals(value, _thirdDolletEncounter)) return;
                _thirdDolletEncounter = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(Output));
            }
        }

        public SingleSoldierEncounter FourthDolletEncounter
        {
            get => _fourthDolletEncounter;
            set
            {
                if (Equals(value, _fourthDolletEncounter)) return;
                _fourthDolletEncounter = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(Output));
                OnPropertyChanged(nameof(LateQuistisOutput));
            }
        }

        public SingleSoldierEncounter BridgeEncounter
        {
            get => _bridgeEncounter;
            set
            {
                if (Equals(value, _bridgeEncounter)) return;
                _bridgeEncounter = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(Output));
                OnPropertyChanged(nameof(LateQuistisOutput));
            }
        }

        public TripleSoldierEncounter SecondBridgeEncounter
        { 
            get => secondBridgeEncounter; 
            set => secondBridgeEncounter = value; 
        }

        public AnacondaurEncounter AnacondaurEncounter
        {
            get => _anacondaurEncounter;
            set
            {
                if (Equals(value, _anacondaurEncounter)) return;
                _anacondaurEncounter = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(Output));
                OnPropertyChanged(nameof(LateQuistisOutput));
            }
        }

        public SingleSoldierEncounter PostAnacondaurEncounter
        {
            get => _postAnacondaurEncounter;
            set
            {
                if (Equals(value, _postAnacondaurEncounter)) return;
                _postAnacondaurEncounter = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(Output));
                OnPropertyChanged(nameof(LateQuistisOutput));
            }
        }

        public ElvoretEncounter ElvoretEncounter
        {
            get => _elvoretEncounter;
            set
            {
                if (Equals(value, _elvoretEncounter)) return;
                _elvoretEncounter = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(Output));
                OnPropertyChanged(nameof(LateQuistisOutput));
            }
        }

        public SpiderTankEncounter SpiderTankEncounter
        {
            get => _spiderTankEncounter;
            set
            {
                if (Equals(value, _spiderTankEncounter)) return;
                _spiderTankEncounter = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(Output));
                OnPropertyChanged(nameof(LateQuistisOutput));
            }
        }

        public RedSoldierEncounter RedSoldierEncounter
        {
            get => _redSoldierEncounter;
            set
            {
                if (_redSoldierEncounter == value)
                {
                    return;
                }

                _redSoldierEncounter = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(Output));
                OnPropertyChanged(nameof(LateQuistisOutput));
            }
        }


        #endregion



        public bool QuistisCardObtained
        {
            get => _quistisCardObtained;
            set
            {
                if (_quistisCardObtained == value)
                    return;
                _quistisCardObtained = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(Output));
            }
        }

        public int Output
        {
            get
            {
                int output = 0;

                if (!QuistisCardObtained) output += LateQuistisOutput;
              
                // Dollet
                output += FirstDolletEncounter.Output;
                output += SecondDolletEncounter.Output;
                output += ThirdDolletEncounter.Output;
                output += FourthDolletEncounter.Output;
                output += BridgeEncounter.Output;

                if (DidGetSecondBridgeEncounter)
                {
                    output += SecondBridgeEncounter.Output;
                }

                output += AnacondaurEncounter.Output;

                if (!DidGetSecondBridgeEncounter)
                {
                    output += PostAnacondaurEncounter.Output;
                }
                output += ElvoretEncounter.Output;
                output += SpiderTankEncounter.Output;

                if (DidGetRedSoldierEncounter) output += RedSoldierEncounter.Output;
                
                return output;
            }
        }

        

        public int LateQuistisOutput
        {
            get
            {

                int output = 0;

                // Ifrits Cavern
                output += TwoBatsEncounter.Output;
                output += 23; // 2x bat 2x bomb encounter (Tutorial)
                output += IfritEncounter.Output;

                switch (IfritsCavernEncounterType)
                {
                    case IfritEncounterType.Buel:
                        output += BuelEncounter.Output;
                        break;
                    case IfritEncounterType.RedBat:
                        output += SecondBatsEncounter.Output;
                        break;
                    default: throw new NotImplementedException();

                }
                output += 11; // Bomb encounter
                output += WorldMapEncounters.Sum(s => s.RngAddition);
                output += FishFinEncounters.Sum(s => s.RngAddition);

                if (_currentPattern != null && _currentPattern.RNGIndex != output)
                {
                    // Reload
                    _currentPattern = null;
                }

                if (_currentPattern == null)
                {
                    _currentPattern = _lateQuistisManip.GetPattern(output, false);
                    QuistisPatternMashDisplay = _currentPattern?.Deck?.InstantMash;
                    Match match = Regex.Match(QuistisPatternMashDisplay ?? string.Empty, @"(YES|NO).*?(\d+)", RegexOptions.IgnoreCase);
                    if (match.Success)
                    {
                        if (match.Groups[1].Value.Equals("YES", StringComparison.CurrentCultureIgnoreCase))
                        {
                            // Instant mash
                            QuistisMashTextBackgroundBrush = new SolidColorBrush(Colors.DarkRed);
                        }
                        else
                        {
                            int framesTillMash = int.Parse(match.Groups[2].Value);
                            if (framesTillMash < 85)
                            {
                                // Almost instant mash but not quite
                                QuistisMashTextBackgroundBrush = new SolidColorBrush(Colors.DarkOrange);
                            }
                            else
                            {
                                // Regular
                                QuistisMashTextBackgroundBrush = new SolidColorBrush(Colors.Transparent); // Standard
                            }
                        }
                    }
                    else
                    {
                        QuistisMashTextBackgroundBrush = new SolidColorBrush(Colors.Transparent); // Standard
                    }
                }


                return output;
            }
        }

        public Command AddNewEncounterCommand { get; }

        public Command AddNewHalfEncounterCommand { get; }

        public Command<FishFinsEncounter> RemoveFishFinEncounterCommand { get; }

        public Command LaunchQuistisPatternsCommand { get; }

        public Command LaunchZellCommand { get; }

        public bool DidGetRedSoldierEncounter
        {
            get => _didGetRedSoldierEncounter; set
            {
                if (_didGetRedSoldierEncounter == value)
                    return;
                _didGetRedSoldierEncounter = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(Output));
                if (_initialised)
                {
                    // Changed setting, save
                    SettingsModel.Instance.GetRedSoldierEncounter = value;
                    SettingsModel.Instance.Save();
                }
            }
        }

        public bool DidGetSecondBridgeEncounter 
        { 
            get => _didGetSecondBridgeEncounter; 
            set
            { 
                _didGetSecondBridgeEncounter = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(Output));
                if (_initialised)
                {
                    // Changed setting, save
                    SettingsModel.Instance.Get2ndBridgeEncounter = value;
                    SettingsModel.Instance.Save();
                }
            }
        }

        public bool Include2ndATMEncounter { get; set; }

        public IfritEncounterType IfritsCavernEncounterType 
        { 
            get => _ifritsCavernEncounterType; 
            set
            { 
                _ifritsCavernEncounterType = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(BuelEncounterVisible));
                OnPropertyChanged(nameof(Output));
                if (_initialised)
                {
                    // Changed setting, save
                    SettingsModel.Instance.IfritEncounterType = value;
                    SettingsModel.Instance.Save();
                }
            }
        }

        public bool BuelEncounterVisible => IfritsCavernEncounterType == IfritEncounterType.Buel;

        public int FocusedTabIndex
        {
            get => _focusedTabIndex;
            set
            {
                if (_focusedTabIndex == value)
                    return;
                _focusedTabIndex = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(ShowQuistisPatternButton));
                OnPropertyChanged(nameof(ShowZellButton));
            }
        }

        public bool ShowQuistisPatternButton => FocusedTabIndex == 0;


        private string _quistisPatternMashDisplay;

        public string QuistisPatternMashDisplay
        {
            get => _quistisPatternMashDisplay;
            private set
            {
                if (_quistisPatternMashDisplay == value)
                    return;
                _quistisPatternMashDisplay = value;
                OnPropertyChanged();
            }
        }

        public bool ShowZellButton => FocusedTabIndex == 3;

        public SolidColorBrush QuistisMashTextBackgroundBrush
        {
            get => _quistisMashTextBackgroundBrush;
            set
            {
                if (_quistisMashTextBackgroundBrush == value)
                    return;
                _quistisMashTextBackgroundBrush = value;
                OnPropertyChanged();
            }
        }

        public bool DesignMode
        {
            get => _designMode;
            set
            {
                if (_designMode == value)
                    return;
                _designMode = value;
                OnPropertyChanged();
            }
        }
    }
}

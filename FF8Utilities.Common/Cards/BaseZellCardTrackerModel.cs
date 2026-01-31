using CardManipulation;
using FF8Utilities.Common;
using FF8Utilities.Common.Cards.Encounters;
using FF8Utilities.Common.Cards.Encounters.Dollet;
using FF8Utilities.Common.Cards.Encounters.IfritsCavern;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Xml.Linq;

namespace FF8Utilities.Common.Cards
{
    public abstract class BaseZellCardTrackerModel : BaseModel
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
        private TripleSoldierEncounter secondBridgeEncounter;
        private RedSoldierEncounter _redSoldierEncounter;
        private int _focusedTabIndex;
        private LateQuistisPattern _currentPattern;            
        private bool _quistisCardObtained;
        private bool _designMode;
        private bool _zellCardSubmitted;
        private string _quistisPatternMashDisplay;
        private string zellPatternMashDisplay;
        private Color _zellMashTextBackgroundColor;
        private Color _quistisMashTextBackgroundColor;
        private string _quistisPatternResult;


        private const string TrackingSettingsFilename = "TrackingSettings.xml";

        private static CardManip _cardManip;
        private static LateQuistis _lateQuistisManip;


        private bool _initialised;

        public static CardManip CardManip
        {
            get
            {
                if (_cardManip == null) _cardManip = new CardManip();
                return _cardManip;
            }
        }

        public static LateQuistis LateQuistisManip
        {
            get
            {
                if (_lateQuistisManip == null) _lateQuistisManip = new LateQuistis(Const.PackagesFolder);
                return _lateQuistisManip;
            }
        }

        public BaseZellCardTrackerModel()
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
            
            FishFinEncounters = new BindingList<FishFinsEncounter>
            {
                // Default to 3 encounters
                new FishFinsEncounter(),
                new FishFinsEncounter(),
                new FishFinsEncounter()
            };
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
            FirstDolletEncounter = new DoubleSoldierEncounter(false, "[1st] 2X Soldier");
            FirstDolletEncounter.PropertyChanged += EncounterPropertyChanged;
            SecondDolletEncounter = new DoubleSoldierEncounter(false, "[2nd] 2X Soldier");
            SecondDolletEncounter.PropertyChanged += EncounterPropertyChanged;
            ThirdDolletEncounter = new SingleSoldierEncounter(false, "[3rd] Soldier");
            ThirdDolletEncounter.PropertyChanged += EncounterPropertyChanged;
            FourthDolletEncounter = new SingleSoldierEncounter(true, "[4th] Soldier");
            FourthDolletEncounter.PropertyChanged += EncounterPropertyChanged;
            BridgeEncounter = new SingleSoldierEncounter(true, "Bridge Soldier");
            BridgeEncounter.PropertyChanged += EncounterPropertyChanged;
            SecondBridgeEncounter = new TripleSoldierEncounter();
            SecondBridgeEncounter.PropertyChanged += EncounterPropertyChanged;
            AnacondaurEncounter = new AnacondaurEncounter();
            AnacondaurEncounter.PropertyChanged += EncounterPropertyChanged;
            PostAnacondaurEncounter = new SingleSoldierEncounter(true, "Mountain Soldier");
            PostAnacondaurEncounter.PropertyChanged += EncounterPropertyChanged;
            ElvoretEncounter = new ElvoretEncounter();
            ElvoretEncounter.PropertyChanged += EncounterPropertyChanged;
            SpiderTankEncounter = new SpiderTankEncounter();
            SpiderTankEncounter.PropertyChanged += EncounterPropertyChanged;

            RedSoldierEncounter = new RedSoldierEncounter(false);
            RedSoldierEncounter.PropertyChanged += EncounterPropertyChanged;

            AddNewEncounterCommand = new RelayCommand(AddNewEncounter);
            AddNewHalfEncounterCommand = new RelayCommand(AddNewHalfEncounter);
            RemoveFishFinEncounterCommand = new RelayCommand<FishFinsEncounter>(RemoveFishFinEncounter, (f) => FishFinEncounters.Count > 0);

            LaunchQuistisPatternsCommand = new RelayCommand(LaunchQuistis);
            LaunchZellCommand = new RelayCommand(LaunchZell);



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

            ZellCardManipModel = CreateCardManipModel(CardManip, 1, "zellmama", Output);
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
                ShowMessage($"Could not load tracking settings, defaults have been set\r\n{ex.Message}", "Error");
            }

            FishFinTabEncounters = new BindingList<BaseEncounterModel>
            {
                TwoBatsEncounter,
                IfritEncounter,
                BuelEncounter,
                SecondBatsEncounter,
            };

            DolletTabEncounters = new BindingList<BaseEncounterModel>
            {
                FirstDolletEncounter,
                SecondDolletEncounter,
                ThirdDolletEncounter,
                FourthDolletEncounter
            };

            AnacondaurTabEncounters = new BindingList<BaseEncounterModel>
            {
                BridgeEncounter,
                SecondBridgeEncounter,
                AnacondaurEncounter,
                PostAnacondaurEncounter
            };

            ElvoretTabEncounters = new BindingList<BaseEncounterModel>
            {
                ElvoretEncounter,
                SpiderTankEncounter,
                RedSoldierEncounter
            };
        }

        public BindingList<BaseEncounterModel> FishFinTabEncounters { get; }

        public BindingList<BaseEncounterModel> DolletTabEncounters { get; }

        public BindingList<BaseEncounterModel> AnacondaurTabEncounters { get; }

        public BindingList<BaseEncounterModel> ElvoretTabEncounters { get; }

        public abstract void ShowMessage(string message, string caption);


        public abstract BaseCardManipulationModel CreateCardManipModel(CardManip manip, uint state, string player, int? count);
        public BaseCardManipulationModel ZellCardManipModel { get; private set; }

        public bool ZellCardSubmitted
        {
            get => _zellCardSubmitted;
            private set
            {
                if (_zellCardSubmitted == value)
                {
                    return;
                }

                _zellCardSubmitted = value;
                OnPropertyChanged();
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

            XElement fishFinXml = xml.Element(nameof(FishFinEncounters));
            if (fishFinXml != null)
            {
                FishFinEncounters.Clear();
                foreach (XElement fishFin in fishFinXml.Elements(nameof(FishFinsEncounter)))
                {
                    FishFinsEncounter enc = new FishFinsEncounter();
                    enc.FromXml(fishFin);

                    enc.PropertyChanged += (s, e) =>
                    {
                        OnPropertyChanged(nameof(Output));
                    };

                    FishFinEncounters.Add(enc);
                }
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

            XElement fishFinXml = new XElement(nameof(FishFinEncounters));
            foreach (FishFinsEncounter encounter in FishFinEncounters)
            {
                fishFinXml.Add(encounter.ToXml());
            }

            xml.Add(fishFinXml);

            File.WriteAllText(Path.Combine(Const.PackagesFolder, TrackingSettingsFilename), xml.ToString());
        }


        private void EncounterPropertyChanged(object sender, PropertyChangedEventArgs arg)
        {
            OnPropertyChanged(nameof(LateQuistisOutput));
            OnPropertyChanged(nameof(Output));            
        }

        private void RemoveFishFinEncounter(FishFinsEncounter enc)
        {
            FishFinEncounters.Remove(enc);
        }

        private void AddNewEncounter()
        {
            FishFinEncounters.Add(new FishFinsEncounter());
        }

        private void AddNewHalfEncounter()
        {
            FishFinEncounters.Add(new FishFinsEncounter { SingleFishKilled = true, Limits = 1 });
        }

        private async void LaunchQuistis()
        {
            uint? result = await LaunchQuistisPatterns(LateQuistisManip.GetPattern(Output, true));
            QuistisCardResult = result;
            QuistisCardObtained = result != null;
            QuistisPatternResult = result != null ? result.Value.ToString("x8") : null;
        }

        /// <summary>
        /// Return the produced result if valid
        /// </summary>
        public abstract Task<uint?> LaunchQuistisPatterns(LateQuistisPattern pattern);

        public abstract void LaunchZellPatterns(string patternString, int? count);


        public abstract bool LegacyMode { get; }

        private void LaunchZell()
        {
            ZellCardSubmitted = true;

            

            string patternString = null;
            if (QuistisCardObtained)
            {
                patternString = QuistisPatternResult;
            }
            else
            {
                patternString = EarlyQuistisPattern.Result.ToString("x8");                                
            }

            LaunchZellPatterns(patternString, Output);
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

        private int _previouslyCalculatedOutput;

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

                if (_previouslyCalculatedOutput != output)
                {
                    _previouslyCalculatedOutput = output;
                    ZellCardManipModel?.Dispose();

                    uint state = 1;
                    if (QuistisCardObtained)
                    {
                        state = QuistisCardResult.Value;
                    }

                    ZellCardManipModel = CreateCardManipModel(CardManip, state, "zellmama", output);
                    ZellMashTextBackgroundColor = ZellCardManipModel.InstantMashBackgroundColor;
                    ZellPatternMashDisplay = ZellCardManipModel.FirstFrameAvailableFramesDisplay;
                }
                
                return output;
            }
        }

        public uint? QuistisCardResult { get; set; }
        

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
                    _currentPattern = LateQuistisManip.GetPattern(output, false);
                    QuistisPatternMashDisplay = _currentPattern?.Deck?.InstantMash;
                    Match match = Regex.Match(QuistisPatternMashDisplay ?? string.Empty, @"(YES|NO).*?(\d+)", RegexOptions.IgnoreCase);
                    if (match.Success)
                    {
                        if (match.Groups[1].Value.Equals("YES", StringComparison.CurrentCultureIgnoreCase))
                        {
                            // Instant mash
                            QuistisMashTextBackgroundColor = Color.DarkRed;
                        }
                        else
                        {
                            int framesTillMash = int.Parse(match.Groups[2].Value);
                            if (framesTillMash <= 85)
                            {
                                // Almost instant mash but not quite
                                QuistisMashTextBackgroundColor = Color.DarkOrange;
                            }
                            else
                            {
                                // Regular
                                QuistisMashTextBackgroundColor = Color.Transparent; // Standard
                            }
                        }
                    }
                    else
                    {
                        QuistisMashTextBackgroundColor = Color.Transparent; // Standard
                    }
                }


                return output;
            }
        }

        public RelayCommand AddNewEncounterCommand { get; }

        public RelayCommand AddNewHalfEncounterCommand { get; }

        public RelayCommand<FishFinsEncounter> RemoveFishFinEncounterCommand { get; }

        public RelayCommand LaunchQuistisPatternsCommand { get; }

        public RelayCommand LaunchZellCommand { get; }

        public abstract bool DidGetRedSoldierEncounter { get; set; }

        public abstract bool DidGetSecondBridgeEncounter { get; set; }

        public bool Include2ndATMEncounter { get; set; }

        public abstract IfritEncounterType IfritsCavernEncounterType { get; set; }

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

        public string ZellPatternMashDisplay
        {
            get => zellPatternMashDisplay;
            private set
            {
                if (zellPatternMashDisplay == value)
                {
                    return;
                }

                zellPatternMashDisplay = value;
                OnPropertyChanged();
            }
        }

        public bool ShowZellButton => FocusedTabIndex == 3;

        public Color QuistisMashTextBackgroundColor
        {
            get => _quistisMashTextBackgroundColor;
            set
            {
                if (_quistisMashTextBackgroundColor == value)
                    return;
                _quistisMashTextBackgroundColor = value;
                OnPropertyChanged();
            }
        }

        public Color ZellMashTextBackgroundColor
        {
            get => _zellMashTextBackgroundColor;
            private set
            {
                if (_zellMashTextBackgroundColor == value)
                {
                    return;
                }

                _zellMashTextBackgroundColor = value;
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

        public string QuistisPatternResult
        {
            get => _quistisPatternResult;
            set
            {
                if (_quistisPatternResult == value)
                    return;
                _quistisPatternResult = value;
                OnPropertyChanged();
            }
        }

        public EarlyQuistisPattern EarlyQuistisPattern { get; set; }
    }
}

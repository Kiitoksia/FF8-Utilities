using System;
using System.ComponentModel;
using System.Linq;
using FF8Utilities.Dialogs;
using FF8Utilities.Entities;
using FF8Utilities.Entities.Encounters;
using FF8Utilities.Entities.Encounters.Diablos;
using FF8Utilities.Entities.Encounters.Dollet;
using FF8Utilities.Entities.Encounters.Ifrits_Cavern;
using LateQuistisManipulation;
using LateQuistisManipulation.Models;

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
        private FishFinsEncounter _focusedFishFinEncounter;
        private bool _flyoutFishFinEncounterOpen;
        private DoubleGratEncounter _doubleGratEncounter;
        private GratEncounter _gratEncounter;
        private DiablosEncounter _diablosEncounter;
        private bool _includeDiablos = false;
        private GranaldoEncounter _granaldoEncounter;
        private bool _didGetRedSoldierEncounter;
        private IfritEncounterType _ifritsCavernEncounterType = IfritEncounterType.Buel;
        private bool _didGetSecondBridgeEncounter;
        private TripleSoldierEncounter secondBridgeEncounter;
        private RedSoldierEncounter _redSoldierEncounter;
        private int _focusedTabIndex;
        private LateQuistisPattern _currentPattern;            
        private LateQuistis _lateQuistisManip;



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
            FishFinEncounters = new BindingList<FishFinsEncounter>
            {
                new FishFinsEncounter(),
                new FishFinsEncounter(),
                new FishFinsEncounter()
            };
            FishFinEncounters.ListChanged += (s, e) =>
            {
                OnPropertyChanged(nameof(FishFinEncounters));
                OnPropertyChanged(nameof(Output));
            };
            FirstDolletEncounter = new DoubleSoldierEncounter();
            FirstDolletEncounter.PropertyChanged += EncounterPropertyChanged;
            SecondDolletEncounter = new DoubleSoldierEncounter();
            SecondDolletEncounter.PropertyChanged += EncounterPropertyChanged;
            ThirdDolletEncounter = new SingleSoldierEncounter();
            ThirdDolletEncounter.PropertyChanged += EncounterPropertyChanged;
            FourthDolletEncounter = new SingleSoldierEncounter();
            FourthDolletEncounter.PropertyChanged += EncounterPropertyChanged;
            BridgeEncounter = new SingleSoldierEncounter();
            BridgeEncounter.PropertyChanged += EncounterPropertyChanged;
            SecondBridgeEncounter = new TripleSoldierEncounter();
            SecondBridgeEncounter.PropertyChanged += EncounterPropertyChanged;
            AnacondaurEncounter = new AnacondaurEncounter();
            AnacondaurEncounter.PropertyChanged += EncounterPropertyChanged;
            PostAnacondaurEncounter = new SingleSoldierEncounter();
            PostAnacondaurEncounter.PropertyChanged += EncounterPropertyChanged;
            ElvoretEncounter = new ElvoretEncounter();
            ElvoretEncounter.PropertyChanged += EncounterPropertyChanged;
            SpiderTankEncounter = new SpiderTankEncounter();
            SpiderTankEncounter.PropertyChanged += EncounterPropertyChanged;

            RedSoldierEncounter = new RedSoldierEncounter();
            RedSoldierEncounter.PropertyChanged += EncounterPropertyChanged;

            DoubleGratEncounter = new DoubleGratEncounter();
            DoubleGratEncounter.PropertyChanged += EncounterPropertyChanged;
            GratEncounter = new GratEncounter();
            GratEncounter.PropertyChanged += EncounterPropertyChanged;
            GranaldoEncounter = new GranaldoEncounter();
            GranaldoEncounter.PropertyChanged += EncounterPropertyChanged;
            DiablosEncounter = new DiablosEncounter();
            DiablosEncounter.PropertyChanged += EncounterPropertyChanged;

            AddNewEncounterCommand = new Command(() => true, AddNewEncounter);
            AddNewHalfEncounterCommand = new Command(() => true, AddNewHalfEncounter);
            RemoveFishFinEncounterCommand = new Command(() => FocusedFishFinEncounter != null, RemoveFishFinEncounter);

            LaunchQuistisPatternsCommand = new Command(() => true, LaunchQuistisPatterns);
            LaunchZellCommand = new Command(() => true, LaunchZell);

            IfritsCavernEncounterType = SettingsModel.Instance.IfritEncounterType;
            IncludeDiablos = SettingsModel.Instance.ZellTrackToDiablos;
            DidGetSecondBridgeEncounter = SettingsModel.Instance.Get2ndBridgeEncounter;
            DidGetRedSoldierEncounter = SettingsModel.Instance.GetRedSoldierEncounter;

            _lateQuistisManip = new LateQuistis(Const.PackagesFolder);
            _initialised = true;
        }

        public ZellCardCalculatorWindow Window { get; set; }

        private void EncounterPropertyChanged(object sender, PropertyChangedEventArgs arg)
        {
            OnPropertyChanged(nameof(LateQuistisOutput));
            OnPropertyChanged(nameof(Output));            
        }

        private void RemoveFishFinEncounter(object sender, EventArgs eventArgs)
        {
            FishFinEncounters.Remove(FocusedFishFinEncounter);
            FocusedFishFinEncounter = null;
            FlyoutFishFinEncounterOpen = false;
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
                QuistisCardObtained = true;
            }
            else
            {
                MainModel.Instance.UseCustomQuistisPattern = false;
                MainModel.Instance.CustomQuistisPattern = null;
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

        public FishFinsEncounter FocusedFishFinEncounter
        {
            get => _focusedFishFinEncounter;
            set
            {
                if (Equals(value, _focusedFishFinEncounter)) return;
                _focusedFishFinEncounter = value;
                FlyoutFishFinEncounterOpen = value != null;
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

        #region Diablos

        public DoubleGratEncounter DoubleGratEncounter
        {
            get => _doubleGratEncounter;
            set
            {
                if (Equals(value, _doubleGratEncounter)) return;
                _doubleGratEncounter = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(Output));
            }
        }
        public GratEncounter GratEncounter
        {
            get => _gratEncounter;
            set
            {
                if (Equals(value, _gratEncounter)) return;
                _gratEncounter = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(Output));
            }
        }

        public GranaldoEncounter GranaldoEncounter
        {
            get => _granaldoEncounter;
            set
            {
                if (Equals(value, _granaldoEncounter)) return;
                _granaldoEncounter = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(Output));
            }
        }

        public DiablosEncounter DiablosEncounter
        {
            get => _diablosEncounter;
            set
            {
                if (Equals(value, _diablosEncounter)) return;
                _diablosEncounter = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(Output));
            }
        }

        private bool _quistisCardObtained;
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
                output += FirstDolletEncounter.RngAddition;
                output += SecondDolletEncounter.RngAddition;
                output += ThirdDolletEncounter.RngAddition;
                output += FourthDolletEncounter.RngAddition;
                output += BridgeEncounter.RngAddition;

                if (DidGetSecondBridgeEncounter)
                {
                    output += SecondBridgeEncounter.RngAddition;
                }

                output += AnacondaurEncounter.RngAddition;

                if (!DidGetSecondBridgeEncounter)
                {
                    output += PostAnacondaurEncounter.RngAddition;
                }
                output += ElvoretEncounter.RngAddition;
                output += SpiderTankEncounter.RngAddition;

                if (DidGetRedSoldierEncounter) output += RedSoldierEncounter.RngAddition;


                if (IncludeDiablos)
                {
                    output += DoubleGratEncounter.RngAddition;
                    output += GratEncounter.RngAddition;
                    output += GranaldoEncounter.RngAddition;
                    output += DiablosEncounter.RngAddition;
                }

                
                return output;
            }
        }

        

        public int LateQuistisOutput
        {
            get
            {

                int output = 0;

                // Ifrits Cavern
                output += TwoBatsEncounter.RngAddition;
                output += 23; // 2x bat 2x bomb encounter (Tutorial)
                output += IfritEncounter.RngAddition;

                switch (IfritsCavernEncounterType)
                {
                    case IfritEncounterType.Buel:
                        output += BuelEncounter.RngAddition;
                        break;
                    case IfritEncounterType.RedBat:
                        output += SecondBatsEncounter.RngAddition;
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
                    QuistisPatternMashDisplay = _currentPattern?.Deck.InstantMash;
                }


                return output;
            }
        }

        public Command AddNewEncounterCommand { get; }

        public Command AddNewHalfEncounterCommand { get; }

        public Command RemoveFishFinEncounterCommand { get; }

        public Command LaunchQuistisPatternsCommand { get; }

        public Command LaunchZellCommand { get; }

        public bool FlyoutFishFinEncounterOpen
        {
            get => _flyoutFishFinEncounterOpen;
            set
            {
                if (value == _flyoutFishFinEncounterOpen) return;
                _flyoutFishFinEncounterOpen = value;
                OnPropertyChanged();
            }
        }

        public bool IncludeDiablos
        {
            get => _includeDiablos;
            set
            {
                if (value == _includeDiablos) return;
                _includeDiablos = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(Output));
            }
        }

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
    }
}

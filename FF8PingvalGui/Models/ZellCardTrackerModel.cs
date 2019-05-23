using System;
using System.ComponentModel;
using System.Linq;
using FF8Utilities.Entities;
using FF8Utilities.Entities.Encounters;
using FF8Utilities.Entities.Encounters.Dollet;
using FF8Utilities.Entities.Encounters.Ifrits_Cavern;

namespace FF8Utilities.Models
{
    public class ZellCardTrackerModel : BaseModel
    {
        private BindingList<WorldMapEncounter> _worldMapEncounters;
        private TwoBatsEncounter _twoBatsEncounter;
        private IfritEncounter _ifritEncounter;
        private BuelEncounter _buelEncounter;
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

        public ZellCardTrackerModel()
        {
            WorldMapEncounters = new BindingList<WorldMapEncounter>();
            WorldMapEncounters.ListChanged += (s, e) =>
            {
                OnPropertyChanged(nameof(WorldMapEncounters));
                OnPropertyChanged(nameof(Output));
            };

            foreach (WorldMapFormation formation in Enum.GetValues(typeof(WorldMapFormation)))
            {
                WorldMapEncounters.Add(new WorldMapEncounter { Formation = formation });
            }

            TwoBatsEncounter = new TwoBatsEncounter();
            TwoBatsEncounter.PropertyChanged += (s, e) => OnPropertyChanged(nameof(Output));
            IfritEncounter = new IfritEncounter();
            IfritEncounter.PropertyChanged += (s, e) => OnPropertyChanged(nameof(Output));
            BuelEncounter = new BuelEncounter();
            BuelEncounter.PropertyChanged += (s, e) => OnPropertyChanged(nameof(Output));
            FishFinEncounters = new BindingList<FishFinsEncounter>();
            FishFinEncounters.Add(new FishFinsEncounter());
            FishFinEncounters.Add(new FishFinsEncounter());
            FishFinEncounters.Add(new FishFinsEncounter());
            FishFinEncounters.ListChanged += (s, e) =>
            {
                OnPropertyChanged(nameof(FishFinEncounters));
                OnPropertyChanged(nameof(Output));
            };
            FirstDolletEncounter = new DoubleSoldierEncounter();
            FirstDolletEncounter.PropertyChanged += (s, e) => OnPropertyChanged(nameof(Output));
            SecondDolletEncounter = new DoubleSoldierEncounter();
            SecondDolletEncounter.PropertyChanged += (s, e) => OnPropertyChanged(nameof(Output));
            ThirdDolletEncounter = new SingleSoldierEncounter();
            ThirdDolletEncounter.PropertyChanged += (s, e) => OnPropertyChanged(nameof(Output));
            FourthDolletEncounter = new SingleSoldierEncounter();
            FourthDolletEncounter.PropertyChanged += (s, e) => OnPropertyChanged(nameof(Output));
            BridgeEncounter = new SingleSoldierEncounter();
            BridgeEncounter.PropertyChanged += (s, e) => OnPropertyChanged(nameof(Output));
            AnacondaurEncounter = new AnacondaurEncounter();
            AnacondaurEncounter.PropertyChanged += (s, e) => OnPropertyChanged(nameof(Output));
            PostAnacondaurEncounter = new SingleSoldierEncounter();
            PostAnacondaurEncounter.PropertyChanged += (s, e) => OnPropertyChanged(nameof(Output));
            ElvoretEncounter = new ElvoretEncounter();
            ElvoretEncounter.PropertyChanged += (s, e) => OnPropertyChanged(nameof(Output));
            SpiderTankEncounter = new SpiderTankEncounter();
            SpiderTankEncounter.PropertyChanged += (s, e) => OnPropertyChanged(nameof(Output));

            AddNewEncounterCommand = new Command(() => true, AddNewEncounter);
            RemoveFishFinEncounterCommand = new Command(() => FocusedFishFinEncounter != null, RemoveFishFinEncounter);
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

        public BindingList<WorldMapEncounter> WorldMapEncounters
        {
            get => _worldMapEncounters;
            set
            {
                if (value == _worldMapEncounters) return;
                _worldMapEncounters = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(Output));
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
            }
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
            }
        }

        #endregion

        public int Output
        {
            get
            {
                int output = 0;

                // Ifrits Cavern
                output += TwoBatsEncounter.RngAddition;
                output += 23; // 2x bat 2x bomb encounter
                output += IfritEncounter.RngAddition;
                output += BuelEncounter.RngAddition;
                output += 11; // Bomb encounter
                output += WorldMapEncounters.Sum(s => s.RngAddition);
                output += FishFinEncounters.Sum(s => s.RngAddition);

                // Dollet
                output += FirstDolletEncounter.RngAddition;
                output += SecondDolletEncounter.RngAddition;
                output += ThirdDolletEncounter.RngAddition;
                output += FourthDolletEncounter.RngAddition;
                output += BridgeEncounter.RngAddition;
                output += AnacondaurEncounter.RngAddition;
                output += PostAnacondaurEncounter.RngAddition;
                output += ElvoretEncounter.RngAddition;
                output += SpiderTankEncounter.RngAddition;
                //return output + Const.BaseRng;
                return output;
            }
        }

        public Command AddNewEncounterCommand { get; }

        public Command RemoveFishFinEncounterCommand { get; }

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
    }
}

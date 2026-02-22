using CommunityToolkit.Maui.Alerts;
using FF8Utilities.Common;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using UltimeciaManip;
using Platform = FF8Utilities.Common.Platform;

namespace FF8Utilities.MAUI.Models
{
    public class UltimeciaManipulationModel : BaseModel
    {
        private bool _showResults;
        private bool _inlcudeRinoaParties;
        private bool _isCalculating;
        private Platform _gamePlatform;
        private UltimeciaManipLanguage _language;

        public UltimeciaManipulationModel()
        {
            Directions = new ObservableCollection<UltimeciaManipulationDirectionModel>();
            Directions.CollectionChanged += (s, e) =>
            {
                OnPropertyChanged(nameof(DirectionCount));
            };

            UpCommand = new AsyncCommand(async () => await AddDirection(Direction.Up));
            LeftCommand = new AsyncCommand(async () => await AddDirection(Direction.Left));
            DownCommand = new AsyncCommand(async () => await AddDirection(Direction.Down));
            RightCommand = new AsyncCommand(async() => await AddDirection(Direction.Right));
            UnknownCommand = new AsyncCommand(async () => await AddDirection(Direction.Unknown));
            RemoveCommand = new AsyncCommand(async () =>
            {
                if (Directions.Count > 0)
                {
                    Directions.RemoveAt(Directions.Count - 1);
                }
            });

            CopyToClipboardCommand = new AsyncCommand(async () =>
            {
                string output = string.Join(string.Empty, Directions.Select(t => t.Direction.ToDirectionCharacter('5')));
                await Clipboard.SetTextAsync(output);
                await MainThread.InvokeOnMainThreadAsync(() =>
                {
                    Toast.Make("Directions copied to clipboard").Show();
                });
            });

            ToggleResults = new Command(() => ShowResults = !ShowResults);

            _inlcudeRinoaParties = App.ShowRinoaParties;
            _gamePlatform = App.Platform;
            _language = App.GameLanguage;
            Results = new ObservableCollection<UltimeciaResultModel>();

            PropertyChanged += async (s, e) =>
            {
                if (e.PropertyName == nameof(IncludeRinoaParties) || e.PropertyName == nameof(GamePlatform) || e.PropertyName == nameof(Language))
                {
                    if (Results != null && Results.Count > 0)
                    {
                        // Re-calculate results
                        await CalculateOutput();
                    }
                }
            };
        }

        public int ResultsCount => Results.Count;

        public ObservableCollection<UltimeciaManipulationDirectionModel> Directions { get; }

        public int DirectionCount => Directions.Count;

        private async Task AddDirection(Direction direction)
        {
            if (Directions.Count >= 12)
            {
                // Remove from the start of the list to maintain 12 total
                Directions.RemoveAt(0);
            }
            Directions.Add(new UltimeciaManipulationDirectionModel(direction));
            
            MainThread.BeginInvokeOnMainThread(() => Vibration.Vibrate(Directions.Count >= 12 ? 500 : 100)); // Do a longer vibration on the last one to let the user know its finished (unfortunately android only)

            if (Directions.Count >= 12)
            {
                ShowResults = true;
                await CalculateOutput();
            }            
        }

        public ICommand UpCommand { get; }

        public ICommand LeftCommand { get; }

        public ICommand DownCommand { get; }

        public ICommand RightCommand { get; }

        public ICommand UnknownCommand { get; }

        public ICommand RemoveCommand { get; }

        public ICommand ToggleResults { get; }

        public ICommand CopyToClipboardCommand { get; }

        public bool ShowResults 
        { 
            get => _showResults; 
            set
            {
                if (_showResults == value) return;
                _showResults = value;
                OnPropertyChanged();
            }
        }

        public async Task CalculateOutput()
        {
            if (Directions.Count < 12) return;

            Results.Clear();

            try
            {
                IsCalculating = true;
                if (!Manipulation.GetSupportedLanguages(App.Platform).Contains(App.GameLanguage))
                {
                    await App.Current.Windows[0].Page.DisplayAlertAsync("Error", "Language not supported for this platform", "OK");
                    return;
                }

                PartyFormation[] formations = await Task.Run(() => Manipulation.GetUltimeciaFormations(Directions.Select(t => t.Direction).ToArray(), App.Platform, App.GameLanguage));

                foreach (PartyFormation formation in formations)
                {
                    Results.Add(new UltimeciaResultModel(formation, this));
                }
            }
            finally
            {
                IsCalculating = false;
                OnPropertyChanged(nameof(ResultsCount));
            }            
        }

        public bool IncludeRinoaParties 
        { 
            get => _inlcudeRinoaParties;
            set
            {
                if (_inlcudeRinoaParties == value) return;
                _inlcudeRinoaParties = value;
                if (value != App.ShowRinoaParties) App.ShowRinoaParties = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<UltimeciaResultModel> Results { get; }

        public bool IsCalculating 
        { 
            get => _isCalculating; 
            set
            {
                if (_isCalculating == value) return;
                _isCalculating = value;
                OnPropertyChanged();
            }
        }

        public Platform GamePlatform 
        { 
            get => _gamePlatform; 
            set
            {
                if (_gamePlatform == value) return;
                _gamePlatform = value;
                if (value != App.Platform) App.Platform = value;
                OnPropertyChanged();
            }
        }

        public UltimeciaManipLanguage Language 
        { 
            get => _language; 
            set
            {
                if (_language == value) return;
                _language = value;
                if (value != App.GameLanguage) App.GameLanguage = value;
                OnPropertyChanged();
            }
        }

        public IEnumerable<Platform> Platforms => Enum.GetValues<Platform>();
        public IEnumerable<UltimeciaManipLanguage> GameLanguages => Enum.GetValues<UltimeciaManipLanguage>();

    }

    public class UltimeciaManipulationDirectionModel
    {
        public UltimeciaManipulationDirectionModel(Direction direction)
        {
            Direction = direction;
            Glyph = direction.GetGlyph();
        }

        public Direction Direction { get; }

        public string Glyph { get; }        
    }    

    public class UltimeciaResultModel
    {
        public UltimeciaResultModel(PartyFormation formation, UltimeciaManipulationModel model)
        {
            RngState = formation.RngState;
            Index = formation.Index;
            MovementGlyphs = formation.Movements.Select(t => t.GetGlyph()).ToArray();
            Directions = formation.Movements.ToArray();
            Formations = new ObservableCollection<UltimeciaPartyFormationModel>();

            bool isFirst = true;
            foreach (TargetOffset offset in formation.TargetOffsetTbl.OrderBy(t => t.Offset))
            {
                if (!model.IncludeRinoaParties && offset.Party.Any(p => p == PartyMember.Rinoa)) continue;
                Formations.Add(new UltimeciaPartyFormationModel(offset, isFirst));
                isFirst = false;
            }
        }


        public string RngState { get; }

        public int Index { get; }

        public string[] MovementGlyphs { get; }

        public Direction[] Directions { get; }

        public ObservableCollection<UltimeciaPartyFormationModel> Formations { get; }
    }

    public class UltimeciaPartyFormationModel
    {
        public UltimeciaPartyFormationModel(TargetOffset offset, bool isFastest)
        {
            CharacterOne = offset.Party[0].ToString();
            CharacterTwo = offset.Party[1].ToString();
            CharacterThree = offset.Party[2].ToString();
            Offset = offset.Offset;
            IsFastestFormation = isFastest;
        }

        public string CharacterOne { get; }
        public string CharacterTwo { get; }
        public string CharacterThree { get; }

        public int Offset { get; }

        public bool IsFastestFormation { get; }
    }

}

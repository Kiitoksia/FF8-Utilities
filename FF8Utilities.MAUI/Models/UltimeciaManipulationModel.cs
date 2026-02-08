using FF8Utilities.Common;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using UltimeciaManip;

namespace FF8Utilities.MAUI.Models
{
    public class UltimeciaManipulationModel : BaseModel
    {
        private bool _showResults;
        private bool _inlcudeRinoaParties;
        private bool _isCalculating;

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

            ToggleResults = new Command(() => ShowResults = !ShowResults);

            _inlcudeRinoaParties = Preferences.Get(nameof(IncludeRinoaParties), false);
            Results = new ObservableCollection<UltimeciaResultModel>();
        }

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

            IsCalculating = true;
            PartyFormation[] formations = await Task.Run(() => Manipulation.GetUltimeciaFormations(Directions.Select(t => t.Direction).ToArray(), App.Platform, App.GameLanguage));
            

            Results.Clear();
            foreach (PartyFormation formation in formations)
            {
                Results.Add(new UltimeciaResultModel(formation, this));
            }
            IsCalculating = false;
        }

        public bool IncludeRinoaParties 
        { 
            get => _inlcudeRinoaParties;
            set
            {
                if (_inlcudeRinoaParties == value) return;
                _inlcudeRinoaParties = value;
                OnPropertyChanged();
                Preferences.Set(nameof(IncludeRinoaParties), value);
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
            MovementGlyphs = formation.Movements.Select(t => t.GetGlyph()).ToArray();

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

        public string[] MovementGlyphs { get; }

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

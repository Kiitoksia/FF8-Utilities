using System;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Timers;
using System.Windows.Controls;
using System.Windows.Input;
using CarawayCode.Entities;
using FF8Utilities.Data;
using FF8Utilities.Dialogs;
using FF8Utilities.Entities;
using MahApps.Metro.Controls.Dialogs;
using UltimeciaManip;
using UltimeciaManip.Entities;
using Manipulation = UltimeciaManip.Manipulation;

namespace FF8Utilities.Models
{
    public class MainModel : BaseModel
    {
        private QuistisPattern _pattern = QuistisPattern.Elastoid;
        private int? _rngPattern;
        private TextBox _textBox;
        private string _ultimeciaRng;
        private BindingList<CarawayCodeOutput> _carawayOutput;
        private bool _currentlyTalling;
        private BindingList<PoleModel> _poles;
        private Timer _tallyTimer;
        private MainWindow _window;
        private SettingsModel _settings;
        private bool _flyoutSettingsOpen;
        private bool _showNotes;
        private BindingList<CardNotesModel> _cardNotes;
        private BindingList<PartyFormationModel> _ultimeciaFormations;

        public MainWindow Window
        {
            get
            {
                return _window;
            }
            set
            {
                if (Equals(value, _window)) return;
                _window = value;
                if (value != null) ConfigureTally();
                OnPropertyChanged();
            }
        }

        public MainModel()
        {
            ZellLaunchCommand = new Command(() => true, ZellLaunch);
            UltimeciaLaunchCommand = new Command(() => UltimeciaRng?.Length == 12 && Settings.Platform != Platform.PC, UltimeciaLaunch);
            UltimeciaTimerCommand = new Command(() => Settings.Platform != Platform.PC, UltimeciaTimerLaunch);
            LaunchZellCalculatorCommand = new Command(() => true, LaunchZellCalculator);

            Poles = new BindingList<PoleModel>();
            for (int i = 1; i <= 6; i++)
            {
                Poles.Add(new PoleModel($"Series {i}"));
            }

            Poles.ListChanged += (s, e) =>
            {
                OnPropertyChanged(nameof(Poles));
                OnPropertyChanged(nameof(PolesAreValid));
            };

            SubmitPolesCommand = new Command(() => PolesAreValid, SubmitPoles);
            ResetPolesCommand = new Command(() => true, ResetPoles);
            PoleTallyCommand = new Command(() => !CurrentlyTalling, TallyCommand);
            ShowAboutCommand = new Command(() => true, ShowAbout);
            ShowSettingsCommand = new Command(() => true, (s, e) => FlyoutSettingsOpen = !FlyoutSettingsOpen);

            CardNotes = new BindingList<CardNotesModel>();
            Settings = new SettingsModel(this);
            PopulateCardNotes();
            UltimeciaFormations = new BindingList<PartyFormationModel>();
            UltimeciaFormations.ListChanged += (s, e) =>
            {
                OnPropertyChanged(nameof(UltimeciaFormations));
                OnPropertyChanged(nameof(NoFormationsFound));
            };

            UltimeciaTimer = new UltimeciaTimerModel();
        }


        private void ShowAbout(object sender, EventArgs eventArgs)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("FF8 Utilities is a program designed to collate all the manipulation used into one easy to use program that doesn't require Ruby or command shell knowledge");
            sb.AppendLine();
            sb.AppendLine("Credits:");
            sb.AppendLine("Kiitoksia: Author of the program");
            sb.AppendLine();
            sb.AppendLine("Pingval: The bundled Zell Card & Ultimecia Manipulation scripts");
            sb.AppendLine();
            sb.AppendLine("Beuj: Source code for Caraway Mansion Code pole tracking");
            sb.AppendLine();
            sb.AppendLine("Luzbelheim: The use of his excel sheet for Zell Tracking made this possible");
            sb.AppendLine();
            sb.AppendLine("Tojju: For his feedback and ideas");


            Window.ShowMessageAsync("About FF8 Utilities", sb.ToString());
        }

        private void ConfigureTally()
        {
            _tallyTimer = new Timer(Const.SeriesInterval);
            _tallyTimer.Elapsed += (s, e) =>
            {
                if (!CurrentlyTalling) return;
                // Timer has ticked, this means they have not input a key since the Series Interval.  We can now increment the Current Tallied Pole
                if (Poles.Last() == CurrentlyTalliedPole)
                {
                    // They are on the last pole, nothing for us to do
                    return;
                }

                if (CurrentlyTalliedPole.Count == null) CurrentlyTalliedPole.Count = 0;
                CurrentlyTalliedPole = Poles[Poles.IndexOf(CurrentlyTalliedPole) + 1];
            };

            Window.PreviewKeyDown += async (s, e) =>
            {
                if (!CurrentlyTalling) return;
                if (e.Key == Key.Enter)
                {
                    CurrentlyTalling = false;         
                    MessageDialogResult result = await Window.ShowMessageAsync("Pole Count", "Was the final sequence complete?", MessageDialogStyle.AffirmativeAndNegative, new MetroDialogSettings { AffirmativeButtonText = "Yes", NegativeButtonText = "No", DefaultButtonFocus = MessageDialogResult.Affirmative });

                    if (result == MessageDialogResult.Negative) CurrentlyTalliedPole.Count = null;

                    SubmitPolesCommand.Execute(null);
                    return;
                }
                _tallyTimer.Stop();
                _tallyTimer.Start();

                if (CurrentlyTalliedPole.Count == null) CurrentlyTalliedPole.Count = 0;
                CurrentlyTalliedPole.Count++;
            };
        }

        private async void TallyCommand(object sender, EventArgs eventArgs)
        {
            await Window.ShowMessageAsync("Confirm Pole Count Start", "Press enter once you transition into pole counting screen", MessageDialogStyle.Affirmative, new MetroDialogSettings { AffirmativeButtonText = "Start" });

            CurrentlyTalling = true;
            CurrentlyTalliedPole = Poles[0];
            _tallyTimer.Stop();
            _tallyTimer.Start();
        }

        private void ResetPoles(object sender, EventArgs eventArgs)
        {
            foreach (PoleModel pole in Poles)
            {
                pole.Count = null;
            }

            CarawayOutput = null;
            CurrentlyTalling = false;

        }

        private void SubmitPoles(object sender, EventArgs eventArgs)
        {            
            CarawayOutput = new BindingList<CarawayCodeOutput>(CarawayCode.CarawayCode.CalculateCode(HelperMethods.ConvertTo(Poles.ToList())));
        }

        private void LaunchZellCalculator(object sender, EventArgs eventArgs)
        {
            ZellCardCalculatorWindow calculatorWindow = new ZellCardCalculatorWindow();
            calculatorWindow.Owner = Window;
            calculatorWindow.Show();
        }

        private void UltimeciaTimerLaunch(object sender, EventArgs args)
        {
            Direction[] directions = UltimeciaRng.Select(s => s.ToDirection()).ToArray();
             
            if (Settings.Platform == Platform.PC) return;

            string path = Settings.Platform == Platform.PS2 ? "ultimeciaNA.exe" : "ultimeciaJP.exe";
            Process.Start(Path.Combine(Directory.GetCurrentDirectory(), "Scripts", path), UltimeciaRng.ToString());
        }


        private void UltimeciaLaunch(object sender, EventArgs eventArgs)
        {
            Direction[] directions = UltimeciaRng.Select(s => s.ToDirection()).ToArray();
            //Process.Start(Path.Combine(Directory.GetCurrentDirectory(), "Scripts/ultimecia.exe"), UltimeciaRng.ToString());
            PartyFormation[] formations = Manipulation.GetUltimeciaFormations(directions, Settings.Platform == Platform.PS2JP);
            UltimeciaFormations.Clear();
            foreach (PartyFormation formation in formations)
            {
                UltimeciaFormations.Add(new PartyFormationModel(formation));
            }
        }

        private void ZellLaunch(object sender, EventArgs eventArgs)
        {
            string script = Settings.Platform == Platform.PS2 || Settings.Platform == Platform.PS2JP ? "zell.exe" : "zellpc.exe";
            Process.Start(Path.Combine(Directory.GetCurrentDirectory(), $"Scripts/{script}"), $"{(int)Pattern} {RngPattern}".Trim());
        }

        public void InitialiseTextBox()
        {
            TextBox.PreviewKeyDown += (s, e) =>
            {
                if (e.Key == Key.Enter && UltimeciaLaunchCommand.CanExecute(null)) UltimeciaLaunchCommand.Execute(null);
            };

            TextBox.TextChanged += (s, e) =>
            {                
                if (Settings.AutoLaunchUltimeciaScript && UltimeciaRng?.Length == 12) UltimeciaLaunchCommand.Execute(null);
            };            
        }

        public Command ZellLaunchCommand { get; }
        public Command UltimeciaLaunchCommand { get; }
        public Command UltimeciaTimerCommand { get; }
        public Command LaunchZellCalculatorCommand { get; }

        public string UltimeciaRng
        {
            get => _ultimeciaRng;
            set
            {
                if (value == _ultimeciaRng) return;
                _ultimeciaRng = value;
                OnPropertyChanged();
            }
        }

        public QuistisPattern Pattern
        {
            get => _pattern;
            set
            {
                if (value == _pattern) return;
                _pattern = value;
                OnPropertyChanged();
                PopulateCardNotes();
            }
        }

        public int? RngPattern
        {
            get => _rngPattern;
            set
            {
                if (value == _rngPattern) return;
                _rngPattern = value;
                OnPropertyChanged();
            }
        }

        public TextBox TextBox
        {
            get => _textBox;
            set
            {
                _textBox = value;
                OnPropertyChanged();
                if (value != null) InitialiseTextBox();
            }
        }

        public BindingList<PoleModel> Poles
        {
            get
            {
                return _poles;
            }
            set
            {
                if (Equals(value, _poles)) return;
                _poles = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(PolesAreValid));
            }
        }

        private PoleModel CurrentlyTalliedPole { get; set; }

        /// <summary>
        /// Pole counts must be provided in a sequence, i.e. (2,0,12).  If they provide (2, null, 12), return false
        /// </summary>
        public bool PolesAreValid
        {
            get
            {
                for (int i = 0; i < Poles.Count - 1; i++)
                {                    
                    if (Poles[i].Count == null && Poles[i + 1].Count != null) return false;
                }

                return true;
            }
        }


        public Command SubmitPolesCommand { get; }

        public BindingList<CarawayCodeOutput> CarawayOutput
        {
            get
            {
                return _carawayOutput;
            }
            set
            {
                if (Equals(value, _carawayOutput)) return;
                _carawayOutput = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(NoSubscriptsDetected));
            }
        }

        public bool NoSubscriptsDetected => !CarawayOutput?.Any() ?? true;

        public Command ResetPolesCommand { get; }
        public Command PoleTallyCommand { get; }

        public bool CurrentlyTalling
        {
            get
            {
                return _currentlyTalling;
            }
            private set
            {
                if (value == _currentlyTalling) return;
                _currentlyTalling = value;
                OnPropertyChanged();
            }
        }

        public Command ShowAboutCommand { get; }

        public SettingsModel Settings
        {
            get
            {
                return _settings;
            }
            set
            {
                if (value == _settings) return;
                _settings = value;
                OnPropertyChanged();
            }
        }

        public Command ShowSettingsCommand { get; }

        public bool FlyoutSettingsOpen
        {
            get
            {
                return _flyoutSettingsOpen;
            }
            set
            {
                if (value == _flyoutSettingsOpen) return;
                _flyoutSettingsOpen = value;
                OnPropertyChanged();
            }
        }

        public string Version => $"Version {Assembly.GetEntryAssembly().GetName().Version}";

        public bool ShowNotes
        {
            get
            {
                return _showNotes;
            }
            set
            {
                if (value == _showNotes) return;
                _showNotes = value;
                OnPropertyChanged();
            }
        }

        public BindingList<CardNotesModel> CardNotes
        {
            get
            {
                return _cardNotes;
            }
            set
            {
                if (value == _cardNotes) return;
                _cardNotes = value;
                OnPropertyChanged();
            }
        }

        private void PopulateCardNotes()
        {
            CardNotes.Clear();
            switch (Pattern)
            {
                case QuistisPattern.Elastoid:
                    CardNotes.Add(new CardNotesModel(Card.Gayla, CardPosition.TopCentre));
                    CardNotes.Add(new CardNotesModel(Card.Caterchipillar, CardPosition.CentreRight));
                    CardNotes.Add(new CardNotesModel(Card.Funguar, CardPosition.BottomRight));
                    CardNotes.Add(new CardNotesModel(Card.Fastitocalon, CardPosition.TopLeft));
                    break;
                case QuistisPattern.Malboro:
                    CardNotes.Add(new CardNotesModel(Card.Funguar, CardPosition.CentreRight));
                    CardNotes.Add(new CardNotesModel(Card.Gayla, CardPosition.BottomRight));
                    CardNotes.Add(new CardNotesModel(Card.Fastitocalon, CardPosition.BottomCentre));
                    CardNotes.Add(new CardNotesModel(Card.Geezard, CardPosition.TopCentre));
                    break;
                case QuistisPattern.BiggsWedge:
                    CardNotes.Add(new CardNotesModel(Card.Funguar, CardPosition.TopRight));
                    CardNotes.Add(new CardNotesModel(Card.Fastitocalon, CardPosition.Centre));
                    CardNotes.Add(new CardNotesModel(Card.Gayla, CardPosition.BottomRight));
                    CardNotes.Add(new CardNotesModel(Card.Caterchipillar, CardPosition.CentreLeft));
                    break;

            }
        }

        public BindingList<PartyFormationModel> UltimeciaFormations
        {
            get => _ultimeciaFormations;
            set
            {
                if (Equals(value, _ultimeciaFormations)) return;
                _ultimeciaFormations = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(NoFormationsFound));
            }
        }

        public bool NoFormationsFound => UltimeciaFormations.Count == 0;

        public UltimeciaTimerModel UltimeciaTimer { get; }

    }
}

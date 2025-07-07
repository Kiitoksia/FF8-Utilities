using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using CarawayCode.Entities;
using CardManipulation;
using FF8Utilities.Common;
using FF8Utilities.Dialogs;
using FF8Utilities.Entities;
using LateQuistisManipulation;
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using UltimeciaManip;
using UltimeciaManip.Entities;
using Manipulation = UltimeciaManip.Manipulation;
using Timer = System.Timers.Timer;

namespace FF8Utilities.Models
{
    public class MainModel : BaseModel
    {

        private const int WM_KEYDOWN = 0x0100;

        private BindingList<CarawayCodeOutput> _carawayOutput;
        private BindingList<CardNotesModel> _cardNotes;
        private bool _currentlyTalling;
        private bool _includeRinoaParties;
        private QuistisPattern _pattern = QuistisPattern.Elastoid_JellyEye;
        private BindingList<PoleModel> _poles;
        private int? _rngPattern;
        private SettingsModel _settings;
        private bool _showNotes;
        private Timer _tallyTimer;
        private TextBox _ultimeciaTextBox;
        private BindingList<PartyFormationModel> _ultimeciaFormations;
        private string _ultimeciaRng;
        private MainWindow _window;
        private string _zellOutput = string.Empty;
        private bool _zellTrackToDiablos;
        private Process _zellProcess;
        private string _zellCountdownText;
        private List<FishPatternModel> _fishPatterns;
        private string _fishFinManipPattern = new string(' ', 16);
        private TimeSpan zellCountdownTimer;
        private bool _fishPatternsPopulating;
        private bool _updateAvailable;
        private bool _hideUnlikelyCarawayResults = true;
        private bool _csrUpdateAvailable;
        private bool _useCustomQuistisPattern;
        private string _customQuistisPattern;
        private bool _showCarawayNPCMovement;
        private CardManipulationModel _zellCardManip;



        private PoleModel CurrentlyTalliedPole { get; set; }

        public MainModel()
        {
            ZellLaunchCommand = new Command(() => true, ZellLaunch);
            ZellCountdownCommand = new Command(() =>
            {
                try
                {
                    return _zellProcess != null && _zellProcess.Handle != IntPtr.Zero && !_zellProcess.HasExited && !_countdownRunning;
                }
                catch (Exception)
                {
                    return false;
                }
            }, ZellCountdownLaunch);
            UltimeciaLaunchCommand = new Command(() => UltimeciaRng?.Length == 12, UltimeciaLaunch);
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
            UpdateAvailableCommand = new Command(() => UpdateAvailable, DownloadUpdate);
            ShowSettingsCommand = new Command(() => true, (s, e) => LaunchSettings(false));

            CardNotes = new BindingList<CardNotesModel>();
            Settings = new SettingsModel(this);
            ShowCarawayNPCMovement = Settings.ShowCarawayNPCMovement;
            PopulateCardNotes();
            UltimeciaFormations = new BindingList<PartyFormationModel>();
            UltimeciaFormations.ListChanged += (s, e) =>
            {
                OnPropertyChanged(nameof(UltimeciaFormations));
                OnPropertyChanged(nameof(NoFormationsFound));
            };


            UltimeciaTimer = new UltimeciaTimerModel();
            ZellCountdownText = "Start Countdown";

            UnpackZell();
            UnpackUpdater();

            LoadFishPatterns();
            _ = CheckForUpdates();          


            foreach (string quistisFile in LateQuistis.RequiredFiles)
            {
                if (!File.Exists(Path.Combine(Const.PackagesFolder, quistisFile)))
                {
                    // Download missing Quistis files quietly
                    _ = Settings.DownloadLateQuistis(false);
                    break;
                }
            }           
            
            Instance = this;
            CardManipulation = new CardManip();

            PropertyChanged += (s, e) =>
            {
                if (e.PropertyName == nameof(Pattern))
                {
                    if (Pattern == QuistisPattern.LateQuistis && string.IsNullOrWhiteSpace(CustomQuistisPattern))
                    {
                        // Don't let them select this
                        Window.BeginInvoke(() =>
                        {
                            Pattern = QuistisPattern.Elastoid_JellyEye;
                            Window.ShowMessageAsync("Error", "Use tracker to set late quistis pattern");
                        });
                    }
                }
            };

        }


        public CardManip CardManipulation { get; }

        public static MainModel Instance { get; private set; }

        /// <summary>
        /// Bundling the .exe in a regular download causes Windows to flag it as from web and is blocked
        /// Instead bundle the .zip inside of Resources and extract on first load
        /// </summary>
        private void UnpackZell()
        {
            string scriptsPath = Path.Combine(AppContext.BaseDirectory, "Scripts");
            if (!Directory.Exists(scriptsPath)) Directory.CreateDirectory(scriptsPath);

            bool extract = Settings.IsFirstLaunchAfterUpdate;

            using (MemoryStream compressedFileStream = new MemoryStream(Properties.Resources.zell))
            {
                using (ZipArchive zip = new ZipArchive(compressedFileStream, ZipArchiveMode.Read, true))
                {
                    foreach (ZipArchiveEntry entry in zip.Entries)
                    {
                        string newFilePath = Path.Combine(scriptsPath, entry.FullName);
                        if (!extract && File.Exists(newFilePath)) continue;

                        entry.ExtractToFile(newFilePath, true);
                    }
                }
            }
        }

        private void UnpackUpdater()
        {
            if (!Directory.Exists(Const.PackagesFolder)) Directory.CreateDirectory(Const.PackagesFolder);

            bool extract = Settings.IsFirstLaunchAfterUpdate;


            // Check if our updater is new
            using (MemoryStream compressedFileStream = new MemoryStream(Properties.Resources.Updater))
            {
                using (ZipArchive zip = new ZipArchive(compressedFileStream, ZipArchiveMode.Read, true))
                {
                    foreach (ZipArchiveEntry entry in zip.Entries)
                    {
                        string newFilePath = Path.Combine(Const.PackagesFolder, entry.FullName);
                        if (!extract && File.Exists(newFilePath)) continue;
                        entry.ExtractToFile(newFilePath, true);
                    }
                }
            }
        }

        private void LoadFishPatterns()
        {
            if (DesignerProperties.GetIsInDesignMode(new DependencyObject())) return; // In design mode, dont bother loading
            string jsonFilePath = Path.Combine(Directory.GetCurrentDirectory(), "Scripts\\fins.json");
            if (!File.Exists(jsonFilePath))
            {
                FishFinManipEnabled = false;
                MessageBox.Show("No Fish Fins json found, Fish Fin Manip disabled");
                return;
            }
            
            FishFinManipEnabled = true;

            string json = File.ReadAllText(jsonFilePath);
            dynamic jObj = JsonConvert.DeserializeObject(json);

            AllFishPatterns = new List<FishPatternModel>();
            foreach (var pattern in jObj)
            {
                AllFishPatterns.Add(new FishPatternModel(pattern));
            }
        }

        private async Task CheckForUpdates()
        {
            HttpClient client = new HttpClient();
            try
            {
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.UserAgent.TryParseAdd("request");
                string jsonString = await client.GetStringAsync("https://api.github.com/repos/kiitoksia/FF8-Utilities/releases/latest");
                JObject json = JObject.Parse(jsonString);

                Version parsedVersion = new Version(json.Value<string>("tag_name"));

                Version currentVersion = typeof(MainModel).Assembly.GetName().Version;

                if (parsedVersion > currentVersion)
                {
                    UpdateAvailable = true;
                }
            }
            catch (Exception)
            {
                // Can't connect to the internet or something else happened.  Ignore
            }

            if (!string.IsNullOrWhiteSpace(Settings.GameInstallationFolder))
            {
                // Check for CSR updates
                try
                {
                    CSRUpdateAvailable = await Settings.IsCSRUpdateAvailable();
                }
                catch (Exception)
                {
                    // Can't connect to the internet or something else happened.  Ignore
                }
            }
        }

        public bool CSRUpdateAvailable
        {
            get => _csrUpdateAvailable;
            set
            {
                if (_csrUpdateAvailable == value)
                    return;
                _csrUpdateAvailable = value;
                OnPropertyChanged();
            }
        }

        public bool FishFinManipEnabled { get; private set; } = true;


        public bool UpdateAvailable
        {
            get => _updateAvailable; private set
            {
                if (_updateAvailable == value)
                    return;
                _updateAvailable = value;
                OnPropertyChanged();
            }
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

        private void LaunchZellCalculator(object sender, EventArgs eventArgs)
        {
            ZellCardCalculatorWindow calculatorWindow = new ZellCardCalculatorWindow();
            calculatorWindow.Owner = Window;
            calculatorWindow.Show();
        }

        private void PopulateCardNotes()
        {
            CardNotes.Clear();
            switch (Pattern)
            {
                case QuistisPattern.Elastoid_JellyEye:
                    CardNotes.Add(new CardNotesModel(Card.Gayla, CardPosition.TopCentre));
                    CardNotes.Add(new CardNotesModel(Card.Caterchipillar, CardPosition.CentreRight));
                    CardNotes.Add(new CardNotesModel(Card.Funguar, CardPosition.BottomRight));
                    CardNotes.Add(new CardNotesModel(Card.Fastitocalon, CardPosition.TopLeft));
                    break;
                case QuistisPattern.Malboro_Snek:
                    CardNotes.Add(new CardNotesModel(Card.Funguar, CardPosition.CentreRight));
                    CardNotes.Add(new CardNotesModel(Card.Gayla, CardPosition.BottomRight));
                    CardNotes.Add(new CardNotesModel(Card.Fastitocalon, CardPosition.BottomCentre));
                    CardNotes.Add(new CardNotesModel(Card.Geezard, CardPosition.TopCentre));
                    break;
                case QuistisPattern.BiggsWedge_JellyEye:
                    CardNotes.Add(new CardNotesModel(Card.Funguar, CardPosition.TopRight));
                    CardNotes.Add(new CardNotesModel(Card.Fastitocalon, CardPosition.Centre));
                    CardNotes.Add(new CardNotesModel(Card.Gayla, CardPosition.BottomRight));
                    CardNotes.Add(new CardNotesModel(Card.Caterchipillar, CardPosition.CentreLeft));
                    break;
                case QuistisPattern.Elastoid_Grendel:
                    CardNotes.Add(new CardNotesModel(Card.Caterchipillar, CardPosition.TopRight));
                    CardNotes.Add(new CardNotesModel(Card.Funguar, CardPosition.CentreRight));
                    CardNotes.Add(new CardNotesModel(Card.Gayla, CardPosition.BottomRight));
                    CardNotes.Add(new CardNotesModel(Card.Fastitocalon, CardPosition.TopLeft));
                    CardNotes.Add(new CardNotesModel(Card.Geezard, CardPosition.BottomLeft));
                    break;
                case QuistisPattern.Malboro_GrandMantis:
                case QuistisPattern.GrandMantis_Elastoid:
                case QuistisPattern.Snek_GIM:
                    break;
                case QuistisPattern.GlacialEye_GrandMantis:
                    CardNotes.Add(new CardNotesModel(Card.Gayla, CardPosition.CentreLeft));
                    CardNotes.Add(new CardNotesModel(Card.Geezard, CardPosition.Centre));
                    CardNotes.Add(new CardNotesModel(Card.Caterchipillar, CardPosition.BottomRight));
                    CardNotes.Add(new CardNotesModel(Card.Fastitocalon, CardPosition.TopCentre));
                    break;
                case QuistisPattern.JellyEye_BiggsWedge:
                    CardNotes.Add(new CardNotesModel(Card.Funguar, CardPosition.Centre));
                    CardNotes.Add(new CardNotesModel(Card.Gayla, CardPosition.BottomCentre));
                    CardNotes.Add(new CardNotesModel(Card.Fastitocalon, CardPosition.BottomLeft));
                    CardNotes.Add(new CardNotesModel(Card.Geezard, CardPosition.TopCentre));
                    break;
                case QuistisPattern.Chimera_Thrustaevis:
                    CardNotes.Add(new CardNotesModel(Card.Funguar, CardPosition.BottomCentre));
                    CardNotes.Add(new CardNotesModel(Card.Gayla, CardPosition.CentreRight));
                    CardNotes.Add(new CardNotesModel(Card.Caterchipillar, CardPosition.TopRight));
                    CardNotes.Add(new CardNotesModel(Card.Geezard, CardPosition.CentreLeft));
                    CardNotes.Add(new CardNotesModel(Card.Fastitocalon, CardPosition.BottomLeft));
                    break;
            }
        }


        [DllImport("user32.dll", SetLastError = true)]
        private static extern bool PostMessage(IntPtr hWnd, [MarshalAs(UnmanagedType.U4)] uint Msg, int wParam, int lParam);

        private void ResetPoles(object sender, EventArgs eventArgs)
        {
            foreach (PoleModel pole in Poles)
            {
                pole.Count = null;
            }

            CarawayOutput = null;
            CurrentlyTalling = false;

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
            sb.AppendLine();
            sb.AppendLine("fhelwanger: For his C# port of pingvals Zell Card Manip <3");
            sb.AppendLine();
            sb.AppendLine("awesomeWaves: For the additional Quistis Card frame information and CSR help");


            Window.ShowMessageAsync("About FF8 Utilities", sb.ToString());
        }

        private void SubmitPoles(object sender, EventArgs eventArgs)
        {
            CarawayOutput = new BindingList<CarawayCodeOutput>(CarawayCode.CarawayCode.CalculateCode(HelperMethods.ConvertTo(Poles.ToList()), HideUnlikelyCarawayResults));
            if (HideUnlikelyCarawayResults && CarawayOutput.Count == 0)
            {
                // Nothing found, toggle back the unlikely results if possible
                CarawayCodeOutput[] unlikelyResults = CarawayCode.CarawayCode.CalculateCode(HelperMethods.ConvertTo(Poles.ToList()), false);
                if (unlikelyResults.Length > 0)
                {
                    // Found an unlikely one, show this instead
                    CarawayOutput = new BindingList<CarawayCodeOutput>(unlikelyResults);
                }
            }
        }

        private async void TallyCommand(object sender, EventArgs eventArgs)
        {
            await Window.ShowMessageAsync("Confirm Pole Count Start", "Press enter once you transition into pole counting screen", MessageDialogStyle.Affirmative, new MetroDialogSettings { AffirmativeButtonText = "Start" });

            CurrentlyTalling = true;
            CurrentlyTalliedPole = Poles[0];
            _tallyTimer.Stop();
            _tallyTimer.Start();
        }


        private async void DownloadUpdate(object sender, EventArgs eventArgs)
        {
            ProgressDialogController progress = await Window.ShowProgressAsync("Updating", "Automatically updating, please wait");

            HttpClient client = new HttpClient();
            try
            {
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.UserAgent.TryParseAdd("request");
                string jsonString = await client.GetStringAsync("https://api.github.com/repos/kiitoksia/FF8-Utilities/releases/latest");
                JObject json = JObject.Parse(jsonString);

                JArray assets = (JArray)json["assets"];
                JToken downloadAsset = assets[0];
                string downloadUrl = downloadAsset["browser_download_url"]?.ToString();
                
                byte[] fileBytes = await client.GetByteArrayAsync(downloadUrl);

                string filePath = Path.GetTempFileName();
                File.WriteAllBytes(filePath, fileBytes);

                Process updateProcess = new Process();
                updateProcess.StartInfo.Arguments = $"\"{AppContext.BaseDirectory.TrimEnd('\\')}\" \"{filePath}\"";
                updateProcess.StartInfo.FileName = Path.Combine(Const.PackagesFolder, "FF8Utilities.Updater.exe");
                updateProcess.Start();
                Environment.Exit(0);
            }
            catch (Exception)
            {
                await Window.ShowMessageAsync("Error", "Could not manually update, please manually update by clicking OK", MessageDialogStyle.Affirmative);
                Process.Start("https://github.com/Kiitoksia/FF8-Utilities/releases/latest");
            }
        }

        private void UltimeciaLaunch(object sender, EventArgs eventArgs)
        {
            Direction[] directions = UltimeciaRng.Select(s => s.ToDirection()).ToArray();
            //Process.Start(Path.Combine(Directory.GetCurrentDirectory(), "Scripts/ultimecia.exe"), UltimeciaRng.ToString());
            PartyFormation[] formations = Manipulation.GetUltimeciaFormations(directions, Settings.Platform, UltimeciaHardReset);
            UltimeciaFormations.Clear();

            foreach (PartyFormation formation in formations)
            {
                UltimeciaFormations.Add(new PartyFormationModel(formation, IncludeRinoaParties));
            }

            OnPropertyChanged(nameof(UltimeciaFormations));
        }

        private bool _countdownRunning = false;

        private async void ZellCountdownLaunch(object sender, EventArgs eventArgs)
        {
            if (_zellProcess == null || _zellProcess.HasExited || _countdownRunning) return;
            _countdownRunning = true;
            DateTime now = DateTime.Now;
            DateTime timeToWaitTill = now.AddSeconds(Settings.ZellCountdownTimer);

            while (DateTime.Now < timeToWaitTill)
            {
                await Task.Delay(5);
                
                TimeSpan span = DateTime.Now - now;
                double timeLeft = Settings.ZellCountdownTimer - span.TotalSeconds;
                ZellCountdownText = $"{timeLeft.ToString("##0.00")}";
            }
            
            PostMessage(_zellProcess.MainWindowHandle, WM_KEYDOWN, 0x0D , 0);
            ZellCountdownText = "Launch Countdown";
            _zellProcess = null;
            _countdownRunning = false;
        }



        private CardManipulationModel StartCardManip(uint state, bool isZell, int delayFrames, int? rngModifier)
        {
            return new CardManipulationModel(CardManipulation, state, isZell ? "zellmama" : "fc01", delayFrames, rngModifier);          
        }

        public CardManipulationModel ZellCardManip
        {
            get => _zellCardManip;
            private set
            {
                if (_zellCardManip == value)
                    return;
                _zellCardManip = value;
                OnPropertyChanged();
            }
        }


        public void LaunchCardScript(bool isZell, int? rngModifier)
        {
            int delayFrames;

            switch (Settings.Platform)
            {
                case Platform.PS2:
                case Platform.PS2JP:
                    delayFrames = 285;
                    break;
                case Platform.PC:
                case Platform.PCLite:
                    delayFrames = 69; // nice
                    break;
                default: throw new ArgumentOutOfRangeException("Contact Kiitoksia because this should not have happened");
            }

            if (Settings.CustomZellDelayFrame != null) delayFrames = Settings.CustomZellDelayFrame.Value;

            string patternString = null;
            if (UseCustomQuistisPattern)
            {
                patternString = CustomQuistisPattern;
            }
            else
            {
                switch (Pattern)
                {
                    case QuistisPattern.Elastoid_JellyEye:
                        patternString = "1";
                        break;
                    case QuistisPattern.Malboro_Snek:
                        patternString = "2";
                        break;
                    case QuistisPattern.BiggsWedge_JellyEye:
                        patternString = "3";
                        break;
                    case QuistisPattern.Elastoid_Grendel:
                        patternString = "0x65c6be07";
                        break;
                    case QuistisPattern.Malboro_GrandMantis:
                    case QuistisPattern.GrandMantis_Elastoid:
                    case QuistisPattern.Snek_GIM:
                        //Unwinnable
                        MessageBox.Show("This is unwinnable and thus you can't continue manip.  If you somehow won, please let us know!");
                        return;
                    case QuistisPattern.GlacialEye_GrandMantis:
                        patternString = "0x832b19d2";
                        break;
                    case QuistisPattern.JellyEye_BiggsWedge:
                        patternString = "0xad8f1b2f";
                        break;
                    case QuistisPattern.Chimera_Thrustaevis:
                        patternString = "0xf99a05ef";
                        break;
                    default: throw new NotImplementedException();
                }
            }

            if (!isZell) patternString = "0x00000001";
            
            string jsonFilePath = Path.Combine(AppContext.BaseDirectory, "Scripts", "settings.json");
            string jsonSettings = File.ReadAllText(jsonFilePath);
            dynamic jObj = JsonConvert.DeserializeObject(jsonSettings);
            jObj["DelayFrame"] = delayFrames;
            jObj["player"] = isZell ? "zellmama" : "fc01"; // Quistis

            jsonSettings = JsonConvert.SerializeObject(jObj);
            File.WriteAllText(jsonFilePath, jsonSettings);

            string arguments = $"{patternString} {rngModifier}".Trim();

            if (Settings.LegacyCardMode)
            {
                _zellProcess = new Process();
                _zellProcess.StartInfo.Arguments = arguments;
                _zellProcess.StartInfo.FileName = Path.Combine(Directory.GetCurrentDirectory(), $"Scripts/ff8-card-manip.exe");
                _zellProcess.StartInfo.WorkingDirectory = Path.Combine(Directory.GetCurrentDirectory(), "Scripts");
                _zellProcess.Exited += (s, e) =>
                {
                    _zellProcess = null;
                };
                _zellProcess.Disposed += (s, e) =>
                {
                    _zellProcess = null;
                };

                try
                {
                    _zellProcess.Start();
                }
                catch (Exception)
                {
                    Window.Invoke(() =>
                    {
                        Window.ShowMessageAsync("Permissions error", "There was a problem starting the zell application.  To unblock" +
                       "\r\n1) Navigate to scripts folder" +
                       "\r\n2) Find zell.exe, right click > properties" +
                       "\r\n3) Check the \"unblock\" box and OK" +
                       "\r\n4) Submit again");
                    });

                }
            }
            else
            {
                ZellCardManip = StartCardManip(Convert.ToUInt32(patternString, 16), isZell, delayFrames, rngModifier);
            }
        }

        private void ZellLaunch(object sender, EventArgs eventArgs)
        {
            LaunchCardScript(true, RngPattern);
        }

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

        public bool IncludeRinoaParties
        {
            get => _includeRinoaParties;
            set
            {
                if (value == _includeRinoaParties) return;
                _includeRinoaParties = value;
                OnPropertyChanged();
                if (UltimeciaFormations != null && UltimeciaFormations.Count > 0) UltimeciaLaunch(this, EventArgs.Empty);
            }
        }

        private bool ultimeciaHardReset;
        public bool UltimeciaHardReset
        {
            get => ultimeciaHardReset; set
            {
                if (ultimeciaHardReset == value)
                    return;
                ultimeciaHardReset = value;
                OnPropertyChanged();
            }
        }
        public Command LaunchZellCalculatorCommand { get; }

        public bool NoFormationsFound => UltimeciaFormations.Count == 0;

        public bool NoSubscriptsDetected => !CarawayOutput?.Any() ?? true;

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
        public Command PoleTallyCommand { get; }

        public Command ResetPolesCommand { get; }

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

        public Command ShowAboutCommand { get; }
        public Command UpdateAvailableCommand { get; }

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

        public Command ShowSettingsCommand { get; }


        public Command SubmitPolesCommand { get; }

        public TextBox UltimeciaTextBox
        {
            get => _ultimeciaTextBox;
            set
            {
                _ultimeciaTextBox = value;
                OnPropertyChanged();
                if (value != null) InitialiseUltimeciaTextBox();
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
        public Command UltimeciaLaunchCommand { get; }

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

        public UltimeciaTimerModel UltimeciaTimer { get; }

        public string Version => $"v{Assembly.GetEntryAssembly().GetName().Version}";

        private void LaunchSettings(bool showFirstLaunch)
        {
            SettingsWindow settingsWindow = new SettingsWindow(Settings);
            settingsWindow.Owner = Window;
            if (showFirstLaunch)
            {
                settingsWindow.Loaded += (s, e) =>
                {
                    settingsWindow.Invoke(() =>
                    {
                        settingsWindow.ShowMessageAsync("First launch", "Please enter your settings\r\nIf you have CSR already installed, please reverify files for correct functionality");
                    });
                };
            }
            
            Window.BeginInvoke(() =>
            {
                settingsWindow.ShowDialog();
            });
        }

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
                if (value != null)
                {
                    ConfigureTally();
                    if (Settings.IsFirstLaunch)
                    {
                        LaunchSettings(true);
                    }
                }
                
                OnPropertyChanged();
            }
        }
        public TimeSpan ZellCountdownTimer
        {
            get => zellCountdownTimer; set
            {
                if (zellCountdownTimer == value)
                    return;
                zellCountdownTimer = value;
                OnPropertyChanged();
            }
        }

        public Command ZellLaunchCommand { get; }
        public Command ZellCountdownCommand { get; }

        public string ZellOutput
        {
            get => _zellOutput;
            set
            {
                if (value == _zellOutput) return;
                _zellOutput = value;
                OnPropertyChanged();
            }
        }

        public bool ZellTrackToDiablos
        {
            get => _zellTrackToDiablos;
            set
            {
                if (value == _zellTrackToDiablos) return;
                _zellTrackToDiablos = value;
                OnPropertyChanged();
            }
        }

        public string ZellCountdownText
        {
            get => _zellCountdownText; set
            {
                if (_zellCountdownText == value)
                    return;
                _zellCountdownText = value;
                OnPropertyChanged();
            }
        }

        public bool UseCustomQuistisPattern
        {
            get => _useCustomQuistisPattern;
            set
            {
                if (_useCustomQuistisPattern == value)
                    return;
                _useCustomQuistisPattern = value;
                OnPropertyChanged();
            }
        }

        public string CustomQuistisPattern
        {
            get => _customQuistisPattern;
            set
            {
                if (_customQuistisPattern == value)
                    return;
                _customQuistisPattern = value;
                OnPropertyChanged();
            }
        }


        #region Fish Fin Manip

        public List<FishPatternModel> FishPatterns
        {
            get => _fishPatterns; set
            {
                if (_fishPatterns == value)
                    return;
                _fishPatterns = value;
                OnPropertyChanged();
            }
        }

        private List<FishPatternModel> AllFishPatterns { get; set; }

        public string FishFinManipPattern
        {
            get => _fishFinManipPattern; set
            {
                if (_fishFinManipPattern == value)
                    return;
                _fishFinManipPattern = value;
                OnPropertyChanged();
                FilterFishPatterns();
            }
        }

        //public TextBox UltimeciaTextBox
        //{
        //    get => _ultimeciaTextBox;
        //    set
        //    {
        //        _ultimeciaTextBox = value;
        //        OnPropertyChanged();
        //        if (value != null) InitialiseUltimeciaTextBox();
        //    }
        //}

        public bool FishPatternsPopulating
        {
            get => _fishPatternsPopulating; set
            {
                if (_fishPatternsPopulating == value)
                    return;
                _fishPatternsPopulating = value;
                OnPropertyChanged();
            }
        }

        public bool HideUnlikelyCarawayResults 
        { 
            get => _hideUnlikelyCarawayResults; 
            set
            { 
                if (_hideUnlikelyCarawayResults == value) return;
                _hideUnlikelyCarawayResults = value;
                OnPropertyChanged();
                if (PolesAreValid)
                {
                    SubmitPoles(this, EventArgs.Empty);
                }
            }
        }

        public bool ShowCarawayNPCMovement
        {
            get => _showCarawayNPCMovement;
            set
            {
                if (_showCarawayNPCMovement == value)
                    return;
                _showCarawayNPCMovement = value;
                OnPropertyChanged();
                if (Settings != null && Settings.ShowCarawayNPCMovement != value)
                {
                    Settings.ShowCarawayNPCMovement = value;
                    Settings.Save();
                }
            }
        }


        private Timer _filterTimer;

        private void FilterFishPatterns()
        {
            if (_filterTimer == null || !_filterTimer.Enabled)
            {
                _filterTimer = new Timer(180);
                _filterTimer.AutoReset = false;
                _filterTimer.Elapsed += (s, e) =>
                {
                    string pattern = FishFinManipPattern?.Trim()?.Replace(" ", string.Empty);
                    if (!string.IsNullOrWhiteSpace(pattern))
                    {                       
                        FishPatterns = AllFishPatterns.Where(t => t.SearchablePattern.StartsWith(pattern)).ToList();
                    }
                    else
                    {
                        FishPatterns = null;
                    }

                    FishPatternsPopulating = false;
                };
                _filterTimer.Start();
            }
            else
            {
                _filterTimer.Stop();
                _filterTimer.Start();
            }

           
            FishPatternsPopulating = true;         
        }

        #endregion

        public void InitialiseUltimeciaTextBox()
        {
            UltimeciaTextBox.PreviewKeyDown += (s, e) =>
            {
                if (e.Key == Key.Enter && UltimeciaLaunchCommand.CanExecute(null)) UltimeciaLaunchCommand.Execute(null);
            };

            UltimeciaTextBox.TextChanged += (s, e) =>
            {
                if (UltimeciaRng?.Length == 12) UltimeciaLaunchCommand.Execute(null);
            };
        }        
    }


}

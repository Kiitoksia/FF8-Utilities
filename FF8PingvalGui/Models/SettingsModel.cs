using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FF8Utilities.Data;
using FF8Utilities.Entities;
using MahApps.Metro.Controls.Dialogs;
using System.Windows.Forms;
using System.IO.Compression;
using FF8Utilities.Properties;
using MahApps.Metro.Controls;

namespace FF8Utilities.Models
{
    public class SettingsModel : BaseModel
    {
        private bool _autoLaunchUltimeciaScript = true;
        private bool _globalHotkeysEnabled;
        private readonly MainModel _mainWindowModel;
        private Platform _platform = Platform.PS2;
        private CSRLanguage _csrLanguage;

        private int? _customZellDelayFrame;
        private int _zellCountdownTimer = 3;
        private string _gameInstallationFolder;


        public SettingsModel(MainModel model)
        {
            AutoLaunchUltimeciaScript = DataManager.Current.CurrentSettings.AutoLaunchUltimecia;
            Platform = DataManager.Current.CurrentSettings.Platform;
            AutoLaunchUltimeciaScript = DataManager.Current.CurrentSettings.AutoLaunchUltimecia;
            CustomZellDelayFrame = DataManager.Current.CurrentSettings.CustomZellDelayFrame;
            ZellCountdownTimer = DataManager.Current.CurrentSettings.ZellCountdownTimer;
            GameInstallationFolder = DataManager.Current.CurrentSettings.GameInstallationFolder;
            SaveSettingsCommand = new Command(() => true, SaveSettings);

            InstallCSRCommand = new Command(() => true, InstallCSR);
            GameInstallFolderSelectionCommand = new Command(() => true, ShowGameInstallSelection);
            _mainWindowModel = model;
            DriveManager = new DriveManager(_mainWindowModel, this);
        }

        private void ShowGameInstallSelection(object sender, EventArgs args)
        {
            // No WPF equivelant of FolderBrowserDialog...WinForms wins again
            using (FolderBrowserDialog dialog = new FolderBrowserDialog())
            {
                dialog.Description = "Select game folder";
                if (!string.IsNullOrWhiteSpace(GameInstallationFolder)) dialog.SelectedPath = GameInstallationFolder;
                else dialog.SelectedPath = AppContext.BaseDirectory;

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    GameInstallationFolder = dialog.SelectedPath;
                }
            }
        }

        private void CheckInstalledGameLanguage()
        {
            if (!string.IsNullOrWhiteSpace(GameInstallationFolder))
            {
                // Check which language is installed
                if (Directory.Exists(Path.Combine(GameInstallationFolder, "Data", "lang-en"))) CSRLanguage = CSRLanguage.English;
                else if (Directory.Exists(Path.Combine(GameInstallationFolder, "Data", "lang-fr"))) CSRLanguage = CSRLanguage.French;
            }
        }

        private async void InstallCSR(object sender, EventArgs args)
        {
            CheckInstalledGameLanguage();
            DriveManager.CheckAndSetCurrentCSRVersion();



            string languageFolder;
            switch (CSRLanguage)
            {
                case CSRLanguage.English: languageFolder = "lang-en"; break;
                case CSRLanguage.French: languageFolder = "lang-fr"; break;
                default: throw new NotImplementedException();
            }


            string dataFolderPath = Path.Combine(GameInstallationFolder ?? string.Empty, "Data", languageFolder);
            if (!Directory.Exists(dataFolderPath))
            {
                await _mainWindowModel.Window.ShowMessageAsync("Error", "Could not find game install folder");
                return;
            }

            // Backup the field files into their own zip if not already backed up
            string backupFilePath = Path.Combine(dataFolderPath, "field_backup.zip");
            if (!File.Exists(backupFilePath))
            {
                using (ZipArchive zip = ZipFile.Open(Path.Combine(dataFolderPath, "field_backup.zip"), ZipArchiveMode.Create))
                {
                    zip.CreateEntryFromFile(Path.Combine(dataFolderPath, "field.fi"), "field.fi");
                    zip.CreateEntryFromFile(Path.Combine(dataFolderPath, "field.fl"), "field.fl");
                    zip.CreateEntryFromFile(Path.Combine(dataFolderPath, "field.fs"), "field.fs");
                }
            }

            // Check we have a CSR downloaded
            bool downloadCsr = false;

            if (DriveManager.CurrentCSRVersion == null)
            {
                // Must download
                downloadCsr = true;
            }
            else
            {
                // Check if there is a new version
                bool newVersionAvailable = await DriveManager.IsNewCSRVersionAvailable();
                if (newVersionAvailable)
                {
                    MessageDialogResult result = await _mainWindowModel.Window.ShowMessageAsync("New CSR available", "Download new version?", MessageDialogStyle.AffirmativeAndNegative);
                    downloadCsr = result == MessageDialogResult.Affirmative;
                }
            }

            if (downloadCsr)
            {
                CSRCheckResult downloadResult = await DownloadCSR();

                if (downloadResult == CSRCheckResult.Error)
                {
                    _mainWindowModel.Window.Invoke(() =>
                    {
                        _mainWindowModel.Window.ShowMessageAsync("Error", "There was an error downloading CSR, try again later or manually install");
                    });
                    return;
                }
            }

            // Overwrite

            using (ZipArchive zip = ZipFile.OpenRead(Path.Combine(Const.PackagesFolder, $"CSR-{CSRLanguage}_v{DriveManager.CurrentCSRVersion}.zip")))
            {
                foreach (ZipArchiveEntry entry in zip.Entries)
                {
                    string newFilePath = Path.Combine(dataFolderPath, entry.FullName);
                    entry.ExtractToFile(newFilePath, true);
                }
            }
        }

        private async Task<CSRCheckResult> DownloadCSR()
        {
            ProgressDialogController downloadController = await _mainWindowModel.Window.ShowProgressAsync("Downloading CSR files", "This may take awhile").ConfigureAwait(true);
            Progress<decimal> progress = new Progress<decimal>(prog =>
            {
                if (prog >= 1) return;
                downloadController.SetProgress((double)prog);
            });
            
            CSRCheckResult downloadResult = await DriveManager.DownloadCSR(progress).ConfigureAwait(false);
            await downloadController.CloseAsync().ConfigureAwait(false);

            DriveManager.CheckAndSetCurrentCSRVersion();            
            return downloadResult;
        }

        private void SaveSettings(object sender, EventArgs eventArgs)
        {
            DataManager.Current.CurrentSettings.AutoLaunchUltimecia = AutoLaunchUltimeciaScript;
            DataManager.Current.CurrentSettings.Platform = Platform;
            DataManager.Current.CurrentSettings.GlobalHotkeys = false;
            DataManager.Current.CurrentSettings.CustomZellDelayFrame = CustomZellDelayFrame;
            DataManager.Current.CurrentSettings.ZellCountdownTimer = ZellCountdownTimer;
            DataManager.Current.CurrentSettings.GameInstallationFolder = GameInstallationFolder;
            DataManager.Current.Save();
            _mainWindowModel.FlyoutSettingsOpen = false;
        }

        public bool AutoLaunchUltimeciaScript
        {
            get
            {
                return _autoLaunchUltimeciaScript;
            }
            set
            {
                if (value == _autoLaunchUltimeciaScript) return;
                _autoLaunchUltimeciaScript = value;
                OnPropertyChanged();
            }
        }
        public bool GlobalHotkeysEnabled
        {
            get
            {
                return _globalHotkeysEnabled;
            }
            set
            {
                if (_globalHotkeysEnabled == value)
                    return;
                _globalHotkeysEnabled = value;
                OnPropertyChanged();
            }
        }

        public Platform Platform
        {
            get
            {
                return _platform;
            }
            set
            {
                if (value == _platform) return;
                _platform = value;
                OnPropertyChanged();
            }
        }

        public int? CustomZellDelayFrame
        {
            get => _customZellDelayFrame; set
            {
                if (_customZellDelayFrame == value)
                    return;
                _customZellDelayFrame = value;
                OnPropertyChanged();
            }
        }

        public int ZellCountdownTimer
        {
            get => _zellCountdownTimer; set
            {
                if (_zellCountdownTimer == value)
                    return;
                _zellCountdownTimer = value;
                OnPropertyChanged();
            }
        }

        public CSRLanguage CSRLanguage
        {
            get => _csrLanguage;
            set
            {
                if (_csrLanguage == value)
                    return;
                _csrLanguage = value;
                OnPropertyChanged();
            }
        }

        public string GameInstallationFolder 
        { 
            get => _gameInstallationFolder;
            set 
            { 
                if (_gameInstallationFolder == value) return;
                _gameInstallationFolder = value; 
                OnPropertyChanged();
            }
        }


        public Command SaveSettingsCommand { get; }

        public Command InstallCSRCommand { get; }

        public Command UninstallCSRCommand { get; }

        public Command GameInstallFolderSelectionCommand { get; set; }


        private DriveManager DriveManager { get; }

    }
}

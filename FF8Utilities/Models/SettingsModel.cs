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
            UninstallCSRCommand = new Command(() => true, UninstallCSR);
            InstallPSXMusicFilesCommand = new Command(() => true, InstallPSXMusic);
            UninstallPSXMusicFilesCommand = new Command(() => true, UninstallPSXMusic);
            GameInstallFolderSelectionCommand = new Command(() => true, ShowGameInstallSelection);
            InstallPracticeModCommand = new Command(() => true, InstallPracticeMod);
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
                    // Sanitise folder to ensure its the root

                    string filePath = dialog.SelectedPath;
                    while (true)
                    {
                        if (string.IsNullOrWhiteSpace(filePath))
                        {
                            // Invalid path
                            break;
                        }
                        if (Path.GetFileName(filePath) == "FINAL FANTASY VIII")
                        {
                            // In root, break out
                            break;
                        }

                        // Go into parent
                        filePath = Path.GetDirectoryName(filePath);
                    }

                    if (string.IsNullOrWhiteSpace(filePath))
                    {
                        _mainWindowModel.Window.Invoke(() =>
                        {
                            _mainWindowModel.Window.ShowMessageAsync("Error", "Could not verify FF8 folder, ensure correct path");
                        });
                    }
                    else
                    {
                        GameInstallationFolder = filePath;
                    }
                }
            }
        }

        private void CheckInstalledGameLanguage()
        {
            if (!string.IsNullOrWhiteSpace(GameInstallationFolder))
            {
                // Check which language is installed
                if (File.Exists(Path.Combine(GameInstallationFolder, "FF8_EN.exe"))) CSRLanguage = CSRLanguage.English;
                else if (File.Exists(Path.Combine(GameInstallationFolder, "FF8_FR.exe"))) CSRLanguage = CSRLanguage.French;
            }
        }

        private async void InstallCSR(object sender, EventArgs args)
        {
            CheckInstalledGameLanguage();
            DriveManager.CheckAndSetCurrentCSRVersion();

            await InstallCSR(false);
        }

        private async void UninstallCSR(object sender, EventArgs args)
        {
            CheckInstalledGameLanguage();

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

            string backupFilePath = Path.Combine(dataFolderPath, "field_backup.zip");
            if (!File.Exists(backupFilePath))
            {
                await _mainWindowModel.Window.ShowMessageAsync("Error", "No backup could be found.  Manually restore using Steam (Right click > Properties > Installed Files > Verify Integrity)");
                return;
            }

            try
            {
                using (ZipArchive zip = ZipFile.OpenRead(backupFilePath))
                {
                    foreach (ZipArchiveEntry entry in zip.Entries)
                    {
                        string newFilePath = Path.Combine(dataFolderPath, entry.FullName);
                        entry.ExtractToFile(newFilePath, true);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Could not overwrite files, ensure file access\r\n{ex.Message}", "Error");
                return;
            }
            

            _mainWindowModel.Window.Invoke(() =>
            {
                _mainWindowModel.Window.ShowMessageAsync("Success", "CSR succesfully un-installed");
            });
        }

        private async Task<DownloadResult> DownloadCSR()
        {
            ProgressDialogController downloadController = await _mainWindowModel.Window.ShowProgressAsync("Downloading CSR files", "This may take a while...").ConfigureAwait(true);
            Progress<decimal> progress = new Progress<decimal>(prog =>
            {
                if (prog >= 1) return;
                downloadController.SetProgress((double)prog);
                downloadController.SetMessage($"{(prog * 100):N2}% complete...");
            });
            
            DownloadResult downloadResult = await DriveManager.DownloadCSR(progress).ConfigureAwait(false);
            await downloadController.CloseAsync().ConfigureAwait(false);

            DriveManager.CheckAndSetCurrentCSRVersion();            
            return downloadResult;
        }

        private async Task<DownloadResult> DownloadPracticeMod()
        {
            ProgressDialogController downloadController = await _mainWindowModel.Window.ShowProgressAsync("Downloading Practice Mod files", "This may take a while...").ConfigureAwait(true);
            Progress<decimal> progress = new Progress<decimal>(prog =>
            {
                if (prog >= 1) return;
                downloadController.SetProgress((double)prog);
                downloadController.SetMessage($"{(prog * 100):N2}% complete...");
            });

            DownloadResult downloadResult = await DriveManager.DownloadPracticeMod(progress).ConfigureAwait(false);
            await downloadController.CloseAsync().ConfigureAwait(false);

            DriveManager.CheckAndSetCurrentCSRVersion();
            return downloadResult;
        }

        private async void InstallPracticeMod(object sender, EventArgs args)
        {
            await InstallCSR(true);            
        }

        private async Task InstallCSR(bool isPracticeMod)
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

            if (isPracticeMod && CSRLanguage != CSRLanguage.French) 
            {
                _mainWindowModel.Window.Invoke(() =>
                {
                    _mainWindowModel.Window.ShowMessageAsync("Error", "Practice mod only available on French game language");
                });
                return;
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
                try
                {
                    using (ZipArchive zip = ZipFile.Open(Path.Combine(dataFolderPath, "field_backup.zip"), ZipArchiveMode.Create))
                    {
                        zip.CreateEntryFromFile(Path.Combine(dataFolderPath, "field.fi"), "field.fi");
                        zip.CreateEntryFromFile(Path.Combine(dataFolderPath, "field.fl"), "field.fl");
                        zip.CreateEntryFromFile(Path.Combine(dataFolderPath, "field.fs"), "field.fs");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Could not create backup, ensure file access\r\n{ex.Message}", "Error");
                    return;
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
                bool newVersionAvailable = isPracticeMod ? await DriveManager.IsNewPracticeModVersionAvailable() : await DriveManager.IsNewCSRVersionAvailable();
                if (newVersionAvailable)
                {
                    MessageDialogResult result = await _mainWindowModel.Window.ShowMessageAsync(isPracticeMod ? "New Practice Mod available" : "New CSR available", "Download new version?", MessageDialogStyle.AffirmativeAndNegative);
                    downloadCsr = result == MessageDialogResult.Affirmative;
                }
            }

            if (downloadCsr)
            {
                DownloadResult downloadResult = isPracticeMod ? await DownloadPracticeMod() : await DownloadCSR();

                if (downloadResult == DownloadResult.Error)
                {
                    _mainWindowModel.Window.Invoke(() =>
                    {
                        _mainWindowModel.Window.ShowMessageAsync("Error", "There was an error downloading, try again later or manually install");
                    });
                    return;
                }
            }

            // Overwrite
            try
            {
                string baseFilename = isPracticeMod ? "prac" : $"CSR-{CSRLanguage}";
                Version version = isPracticeMod ? DriveManager.CurrentPracticeVersion :  DriveManager.CurrentCSRVersion;
                using (ZipArchive zip = ZipFile.OpenRead(Path.Combine(Const.PackagesFolder, $"{baseFilename}_v{version}.zip")))
                {
                    foreach (ZipArchiveEntry entry in zip.Entries)
                    {
                        string newFilePath = Path.Combine(dataFolderPath, entry.FullName);
                        entry.ExtractToFile(newFilePath, true);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Could not install, ensure file access\r\n{ex.Message}", "Error");
                return;
            }

            _mainWindowModel.Window.Invoke(() =>
            {
                _mainWindowModel.Window.ShowMessageAsync("Success", "Succesfully installed");
            });
        }

        private async void InstallPSXMusic(object sender, EventArgs args)
        {
            string musicFolderPath = Path.Combine(GameInstallationFolder ?? string.Empty, "Data", "Music", "dmusic");
            if (!Directory.Exists(musicFolderPath))
            {
                await _mainWindowModel.Window.ShowMessageAsync("Error", "Could not find game install folder");
                return;
            }

            // Backup the music files into their own zip if not already backed up
            string backupFilePath = Path.Combine(musicFolderPath, "music_backup.zip");
            if (!File.Exists(backupFilePath))
            {
                try
                {
                    using (ZipArchive zip = ZipFile.Open(Path.Combine(musicFolderPath, "music_backup.zip"), ZipArchiveMode.Create))
                    {
                        foreach (string filePath in Directory.GetFiles(musicFolderPath))
                        {
                            string ext = Path.GetExtension(filePath);
                            if (!new[] { ".sgt", ".dls" }.Contains(Path.GetExtension(filePath)))
                            {
                                continue; // Irrelevant file, ignore
                            }

                            zip.CreateEntryFromFile(filePath, Path.GetFileName(filePath));
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Could not create backup, ensure file access\r\n{ex.Message}", "Error");
                    return;
                }
            }

            string musicFilePath = Path.Combine(Const.PackagesFolder, "ff8dm.zip");
            if (!File.Exists(musicFilePath))
            {
                // Need to download
                DownloadResult downloadResult = await DownloadPSXMusic();

                if (downloadResult == DownloadResult.Error)
                {
                    _mainWindowModel.Window.Invoke(() =>
                    {
                        _mainWindowModel.Window.ShowMessageAsync("Error", "There was an error downloading Music Files, try again later or manually install");
                    });
                    return;
                }
            }

            try
            {
                using (ZipArchive zip = ZipFile.OpenRead(musicFilePath))
                {
                    foreach (ZipArchiveEntry entry in zip.Entries)
                    {
                        string newFilePath = Path.Combine(musicFolderPath, entry.FullName);
                        entry.ExtractToFile(newFilePath, true);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Could not install PSX Music Files, ensure file access\r\n{ex.Message}", "Error");
                return;
            }

            _mainWindowModel.Window.Invoke(() =>
            {
                _mainWindowModel.Window.ShowMessageAsync("Success", "PSX Music files succesfully installed");
            });
        }

        private async void UninstallPSXMusic(object sender, EventArgs args)
        {
            string musicFolderPath = Path.Combine(GameInstallationFolder ?? string.Empty, "Data", "Music", "dmusic");
            if (!Directory.Exists(musicFolderPath))
            {
                await _mainWindowModel.Window.ShowMessageAsync("Error", "Could not find game install folder");
                return;
            }

            string backupFilePath = Path.Combine(musicFolderPath, "music_backup.zip");
            if (!File.Exists(backupFilePath))
            {
                await _mainWindowModel.Window.ShowMessageAsync("Error", "No backup could be found.  Manually restore using Steam (Right click > Properties > Installed Files > Verify Integrity)");
                return;
            }

            using (ZipArchive zip = ZipFile.OpenRead(backupFilePath))
            {
                foreach (ZipArchiveEntry entry in zip.Entries)
                {
                    string newFilePath = Path.Combine(musicFolderPath, entry.FullName);
                    entry.ExtractToFile(newFilePath, true);
                }
            }

            _mainWindowModel.Window.Invoke(() =>
            {
                _mainWindowModel.Window.ShowMessageAsync("Success", "PSX Music Files succesfully un-installed");
            });
        }

        private async Task<DownloadResult> DownloadPSXMusic()
        {
            ProgressDialogController downloadController = await _mainWindowModel.Window.ShowProgressAsync("Downloading PSX Music files", "This may take awhile...").ConfigureAwait(true);
            Progress<decimal> progress = new Progress<decimal>(prog =>
            {
                if (prog >= 1) return;
                downloadController.SetProgress((double)prog);
                downloadController.SetMessage($"{(prog * 100):N2}% complete...");
            });

            DownloadResult downloadResult = await DriveManager.DownloadMusic(progress).ConfigureAwait(false);
            await downloadController.CloseAsync().ConfigureAwait(false);

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

        public Command InstallPSXMusicFilesCommand { get; }

        public Command UninstallPSXMusicFilesCommand { get; }

        public Command GameInstallFolderSelectionCommand { get; }

        public Command InstallPracticeModCommand { get; }


        private DriveManager DriveManager { get; }

    }
}

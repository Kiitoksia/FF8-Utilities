using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FF8Utilities.Common;
using FF8Utilities.Entities;
using MahApps.Metro.Controls.Dialogs;
using System.Windows.Forms;
using System.IO.Compression;
using FF8Utilities.Properties;
using MahApps.Metro.Controls;
using System.Xml.Linq;
using System.Security.Cryptography;

namespace FF8Utilities.Models
{
    public class SettingsModel : BaseModel
    {
        private readonly MainModel _mainWindowModel;
        private Platform _platform = Platform.PS2;
        private CSRLanguage _csrLanguage;

        private int? _customZellDelayFrame;
        private int _zellCountdownTimer = 3;
        private string _gameInstallationFolder;

        private string SettingsPath => Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "FF8-Utilities", Const.SettingsFile);
        private const string CSREnglishChecksum = "64-B8-0D-20-B4-29-2B-51-BC-1E-E5-87-32-06-9A-51";
        private const string CSRFrenchChecksum = "4C-52-10-5D-54-5E-2D-96-B2-52-81-83-A3-57-60-39";

        public SettingsModel(MainModel model)
        {
            Populate();
            SaveSettingsCommand = new Command(() => true, SaveSettings);

            InstallCSRCommand = new Command(() => true, InstallCSR);
            UninstallCSRCommand = new Command(() => true, UninstallCSR);
            UpdateCSRCommand = new Command(() => true, UpdateCSR);
            InstallPSXMusicFilesCommand = new Command(() => true, InstallPSXMusic);
            UninstallPSXMusicFilesCommand = new Command(() => true, UninstallPSXMusic);
            GameInstallFolderSelectionCommand = new Command(() => true, ShowGameInstallSelection);
            InstallPracticeModCommand = new Command(() => true, InstallPracticeMod);
            DownloadLateQuistisFiles = new Command(() => true, DownloadLateQuistis);
            _mainWindowModel = model;
            DriveManager = new DriveManager(_mainWindowModel, this);
            Instance = this;
        }


        public static SettingsModel Instance { get; private set; }


        private async void DownloadLateQuistis(object sender, EventArgs args)
        {
            await DownloadLateQuistis(true);
        }

        public async Task DownloadLateQuistis(bool notify)
        {
            DownloadResult result = await DriveManager.DownloadLateQuistisCSRFiles();
            if (notify)
            {
                _mainWindowModel.Window.Invoke(() =>
                {
                    _mainWindowModel.Window.ShowMessageAsync("Result", result == DownloadResult.Downloaded ? "Files succesfully downloaded" : "Error downloading");
                });
            }            
        }


        private void Populate()
        {
            XElement xml = null;
            if (File.Exists(SettingsPath)) xml = XElement.Load(SettingsPath);
            else IsFirstLaunch = true;

            XElement platformNode = xml?.Element(nameof(Platform));

            if (platformNode != null)
            {
                if (platformNode.Value == "BadPort") platformNode.Value = "PC";
                if (Enum.TryParse(platformNode.Value, out Platform platform)) Platform = platform;
            }

            XElement zellTrackToDiablos = xml?.Element(nameof(ZellTrackToDiablos));

            if (zellTrackToDiablos != null)
            {
                if (bool.TryParse(zellTrackToDiablos.Value, out bool zellTrack)) ZellTrackToDiablos = zellTrack;
            }

            XElement ifritEncounter = xml?.Element(nameof(IfritEncounterType));
            if (ifritEncounter != null)
            {
                if (Enum.TryParse(ifritEncounter.Value, out IfritEncounterType ifritEncounterType)) IfritEncounterType = ifritEncounterType;
            }

            XElement get2ndBridgeEncounter = xml?.Element(nameof(Get2ndBridgeEncounter));
            if (get2ndBridgeEncounter != null)
            {
                if (bool.TryParse(get2ndBridgeEncounter.Value, out bool bridgeEncounter)) Get2ndBridgeEncounter = bridgeEncounter;
            }

            XElement getRedSoldierEncounter = xml?.Element(nameof(GetRedSoldierEncounter));
            if (getRedSoldierEncounter != null)
            {
                if (bool.TryParse(getRedSoldierEncounter.Value, out bool bridgeEncounter)) GetRedSoldierEncounter = bridgeEncounter;
            }


            XElement customZellDelayFrameXml = xml?.Element(nameof(CustomZellDelayFrame));
            if (customZellDelayFrameXml != null)
            {
                if (int.TryParse(customZellDelayFrameXml.Value, out int frames)) CustomZellDelayFrame = frames;
            }

            XElement zellCountdownTimerXml = xml?.Element(nameof(ZellCountdownTimer));
            if (zellCountdownTimerXml != null)
            {
                if (int.TryParse(zellCountdownTimerXml.Value, out int timer)) ZellCountdownTimer = timer;
            }

            XElement gameInstallFolder = xml?.Element(nameof(GameInstallationFolder));
            GameInstallationFolder = gameInstallFolder?.Value;

        }

        public XElement CopyTo(ref XElement xml)
        {
            XElement rootNode = xml?.Element("Settings");
            if (rootNode == null)
            {
                rootNode = new XElement("Settings");
                xml = rootNode;
            }

            XElement platformNode = xml.Element(nameof(Platform));
            if (platformNode == null)
            {
                platformNode = new XElement(nameof(Platform));
                rootNode.Add(platformNode);
            }

            platformNode.Value = Platform.ToString();

            XElement zellTrackingNode = xml.Element(nameof(ZellTrackToDiablos));
            if (zellTrackingNode == null)
            {
                zellTrackingNode = new XElement(nameof(ZellTrackToDiablos));
                rootNode.Add(zellTrackingNode);
            }

            zellTrackingNode.Value = ZellTrackToDiablos.ToString();

            XElement ifritEncounterNode = xml.Element(nameof(IfritEncounterType));
            if (ifritEncounterNode == null)
            {
                ifritEncounterNode = new XElement(nameof(IfritEncounterType));
                rootNode.Add(ifritEncounterNode);
            }

            ifritEncounterNode.Value = IfritEncounterType.ToString();

            XElement secondBridgeEncounterNode = xml.Element(nameof(Get2ndBridgeEncounter));
            if (secondBridgeEncounterNode == null)
            {
                secondBridgeEncounterNode = new XElement(nameof(Get2ndBridgeEncounter));
                rootNode.Add(secondBridgeEncounterNode);
            }

            secondBridgeEncounterNode.Value = Get2ndBridgeEncounter.ToString();

            XElement redSoldierEncounterNode = xml.Element(nameof(GetRedSoldierEncounter));
            if (redSoldierEncounterNode == null)
            {
                redSoldierEncounterNode = new XElement(nameof(GetRedSoldierEncounter));
                rootNode.Add(redSoldierEncounterNode);
            }

            redSoldierEncounterNode.Value = GetRedSoldierEncounter.ToString();

            XElement customZellDelayFrames = xml.Element(nameof(CustomZellDelayFrame));
            if (customZellDelayFrames == null)
            {
                customZellDelayFrames = new XElement(nameof(CustomZellDelayFrame));
                rootNode.Add(customZellDelayFrames);
            }


            customZellDelayFrames.Value = CustomZellDelayFrame?.ToString() ?? string.Empty;

            XElement zellCountdownTimer = xml.Element(nameof(ZellCountdownTimer));
            if (zellCountdownTimer == null)
            {
                zellCountdownTimer = new XElement(nameof(ZellCountdownTimer));
                rootNode.Add(zellCountdownTimer);
            }

            zellCountdownTimer.Value = ZellCountdownTimer.ToString();

            XElement gameInstallFolder = xml.Element(nameof(GameInstallationFolder));
            if (gameInstallFolder == null)
            {
                gameInstallFolder = new XElement(nameof(GameInstallationFolder));
                rootNode.Add(gameInstallFolder);
            }

            gameInstallFolder.Value = GameInstallationFolder ?? string.Empty;

            return xml;
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

        private async void UpdateCSR(object sender, EventArgs args)
        {
            CheckInstalledGameLanguage();
            DriveManager.CheckAndSetCurrentCSRVersion();

            await InstallCSR(false, true);
        }

        private async void InstallCSR(object sender, EventArgs args)
        {
            CheckInstalledGameLanguage();
            DriveManager.CheckAndSetCurrentCSRVersion();

            await InstallCSR(false, false);
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
            await InstallCSR(true, false);            
        }

        private async Task InstallCSR(bool isPracticeMod, bool forceUpdate)
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

            bool warnNoBackupPossible = false;
            // Backup the field files into their own zip if not already backed up
            string backupFilePath = Path.Combine(dataFolderPath, "field_backup.zip");
            if (!File.Exists(backupFilePath))
            {
                using (var md5 = MD5.Create())
                {
                    using (Stream stream = File.OpenRead(Path.Combine(dataFolderPath, "field.fs")))
                    {
                        byte[] hash = md5.ComputeHash(stream);
                        string hashString = BitConverter.ToString(hash);
                        if (CSRLanguage == CSRLanguage.English && hashString != CSREnglishChecksum) warnNoBackupPossible = true;
                        else if (CSRLanguage == CSRLanguage.French && hashString != CSRFrenchChecksum) warnNoBackupPossible = true;
                    }
                }
                try
                {
                    if (!warnNoBackupPossible)
                    {
                        using (ZipArchive zip = ZipFile.Open(Path.Combine(dataFolderPath, "field_backup.zip"), ZipArchiveMode.Create))
                        {
                            zip.CreateEntryFromFile(Path.Combine(dataFolderPath, "field.fi"), "field.fi");
                            zip.CreateEntryFromFile(Path.Combine(dataFolderPath, "field.fl"), "field.fl");
                            zip.CreateEntryFromFile(Path.Combine(dataFolderPath, "field.fs"), "field.fs");
                        }
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
                if (forceUpdate) downloadCsr = true;
                else if (newVersionAvailable)
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

                _mainWindowModel.CSRUpdateAvailable = false;
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
                string successMessage = "Succesfully installed";
                if (warnNoBackupPossible)
                {
                    successMessage += "\r\nNOTE: CSR was previously manually installed.  Utilities cannot uninstall CSR (must be done in steam instead)";
                }
                _mainWindowModel.Window.ShowMessageAsync("Success", successMessage);
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
            Save();
        }

        public void Save()
        {
            XElement xml = null;
            CopyTo(ref xml);
            if (!Directory.Exists(Path.GetDirectoryName(SettingsPath))) Directory.CreateDirectory(Path.GetDirectoryName(SettingsPath));
            xml.Save(SettingsPath);
            _mainWindowModel.FlyoutSettingsOpen = false;
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


        public Command UpdateCSRCommand { get; }

        public Command SaveSettingsCommand { get; }

        public Command InstallCSRCommand { get; }

        public Command UninstallCSRCommand { get; }

        public Command InstallPSXMusicFilesCommand { get; }

        public Command UninstallPSXMusicFilesCommand { get; }

        public Command GameInstallFolderSelectionCommand { get; }

        public Command InstallPracticeModCommand { get; }

        public Command DownloadLateQuistisFiles { get; }


        public DriveManager DriveManager { get; }

        public bool IsFirstLaunch { get; private set; }

        public bool ZellTrackToDiablos { get; set; }

        public IfritEncounterType IfritEncounterType { get; set; }

        public bool Get2ndBridgeEncounter { get; set; }

        public bool GetRedSoldierEncounter { get; set; }

        public Task<bool> IsCSRUpdateAvailable()
        {
            CheckInstalledGameLanguage();
            return DriveManager.IsNewCSRVersionAvailable();
        }

    }
}

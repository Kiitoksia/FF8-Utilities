﻿using System;
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
using UltimeciaManip;

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
                // Convert obsolete values
                if (platformNode.Value == "BadPort") platformNode.Value = "PC";
                if (platformNode.Value == "PS2JP") platformNode.Value = "PS2";
                if (platformNode.Value == "PCLite") platformNode.Value = "PC";

                if (Enum.TryParse(platformNode.Value, out Platform platform)) Platform = platform;
            }

            TryGetXmlValue<IfritEncounterType>(xml, nameof(IfritEncounterType), t => IfritEncounterType = t);
            TryGetXmlValue<bool>(xml, nameof(Get2ndBridgeEncounter), t => Get2ndBridgeEncounter = t);
            TryGetXmlValue<bool>(xml, nameof(GetRedSoldierEncounter), t => GetRedSoldierEncounter = t);
            TryGetXmlValue<int>(xml, nameof(CustomZellDelayFrame), t => CustomZellDelayFrame = t);
            TryGetXmlValue<int>(xml, nameof(ZellCountdownTimer), t => ZellCountdownTimer = t);
            TryGetXmlValue<string>(xml, nameof(GameInstallationFolder), t => GameInstallationFolder = t);
            TryGetXmlValue<QuistisPatternsOrderBy>(xml, nameof(QuistisPatternsOrderBy), t => QuistisPatternsOrderBy = t);
            TryGetXmlValue<bool>(xml, nameof(ShowCarawayNPCMovement), t => ShowCarawayNPCMovement = t);
            TryGetXmlValue<BeepSound>(xml, nameof(BeepSound), t => BeepSound = t);
            TryGetXmlValue<int>(xml, nameof(BeepInterval), t => BeepInterval = t);
            TryGetXmlValue<int>(xml, nameof(BeepCount), t => BeepCount = t);
            TryGetXmlValue<bool>(xml, nameof(LegacyCardMode), t => LegacyCardMode = t);
            TryGetXmlValue<int>(xml, nameof(BeepOffsetFrames), t => BeepOffsetFrames = t);
            TryGetXmlValue<UpdateBranch>(xml, nameof(UpdateBranch), t => UpdateBranch = t);
            TryGetXmlValue<UltimeciaManipLanguage>(xml, nameof(UltimeciaManipLanguage), t => UltimeciaManipLanguage = t);



            XElement lastLaunchedVersion = xml?.Element("LastLaunchedVersion");
            if (lastLaunchedVersion != null)
            {
                if (Version.TryParse(lastLaunchedVersion.Value, out Version oldVersion))
                {
                    Version currentVersion = typeof(MainModel).Assembly.GetName().Version;
                    if (oldVersion < currentVersion)
                    {
                        IsFirstLaunchAfterUpdate = true;
                    }
                }
            }
            else
            {
                IsFirstLaunchAfterUpdate = true;
            }

        }

        public XElement CopyTo()
        {
            XElement xml = new XElement("Settings");
            xml.Add(new XElement(nameof(Platform), Platform.ToString()));
            xml.Add(new XElement(nameof(IfritEncounterType), IfritEncounterType.ToString()));
            xml.Add(new XElement(nameof(Get2ndBridgeEncounter), Get2ndBridgeEncounter.ToString()));
            xml.Add(new XElement(nameof(GetRedSoldierEncounter), GetRedSoldierEncounter.ToString()));
            xml.Add(new XElement(nameof(CustomZellDelayFrame), CustomZellDelayFrame?.ToString() ?? string.Empty));
            xml.Add(new XElement(nameof(ZellCountdownTimer), ZellCountdownTimer.ToString()));
            xml.Add(new XElement(nameof(GameInstallationFolder), GameInstallationFolder ?? string.Empty));
            xml.Add(new XElement(nameof(QuistisPatternsOrderBy), QuistisPatternsOrderBy.ToString()));
            xml.Add(new XElement(nameof(ShowCarawayNPCMovement), ShowCarawayNPCMovement.ToString()));
            xml.Add(new XElement(nameof(BeepSound), BeepSound.ToString()));
            xml.Add(new XElement(nameof(BeepInterval), BeepInterval));
            xml.Add(new XElement(nameof(BeepCount), BeepCount));
            xml.Add(new XElement(nameof(LegacyCardMode), LegacyCardMode.ToString()));
            xml.Add(new XElement(nameof(BeepOffsetFrames), BeepOffsetFrames.ToString()));
            xml.Add(new XElement(nameof(UpdateBranch), UpdateBranch.ToString()));
            xml.Add(new XElement(nameof(UltimeciaManipLanguage), UltimeciaManipLanguage.ToString()));
            Version currentVersion = typeof(MainModel).Assembly.GetName().Version;
            xml.Add(new XElement("LastLaunchedVersion", currentVersion.ToString()));

            return xml;
        }

        private void TryGetXmlValue<T>(XElement xml, string propertyName, Action<T> valueFound)
        {
            XElement propertyXml = xml?.Element(propertyName);
            if (propertyXml == null) return;
            object value = null;
            if (typeof(T) == typeof(int))
            {
                if (int.TryParse(propertyXml.Value, out int intValue)) value = intValue;
            }
            else if (typeof(T) == typeof(bool))
            {
                if (bool.TryParse(propertyXml.Value, out bool boolValue)) value = boolValue;
            }
            else if (typeof(T) == typeof(string))
            {
                value = propertyXml.Value;
            }
            else if (typeof(T).IsEnum)
            {
                try
                {
                    T enumValue = (T)Enum.Parse(typeof(T), propertyXml.Value);
                    valueFound(enumValue);
                }
                catch
                {
                    // Parsing fails, ignore which naturally will return the default
                }
            }
            
            if (value == null) return;
            valueFound((T)Convert.ChangeType(value, typeof(T)));
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
                if (prog < 0.01m || prog >= 1m) return; // Invalid percentage
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
            int totalDelay = BeepInterval * (BeepCount - 1);
            if (totalDelay > 1500)
            {
                _mainWindowModel.Window.Invoke(() =>
                {
                    _mainWindowModel.Window.ShowMessageAsync("Error", "Beep Interval/Count must be under 1.5s total");
                });
                return;
            }

            Save();
        }

        public void Save()
        {
            XElement xml = CopyTo();
            if (!Directory.Exists(Path.GetDirectoryName(SettingsPath))) Directory.CreateDirectory(Path.GetDirectoryName(SettingsPath));
            xml.Save(SettingsPath);
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
                OnPropertyChanged(nameof(PlatformDisplay));
            }
        }

        public string PlatformDisplay => Platform.GetDescription();

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

        public bool IsFirstLaunchAfterUpdate { get; private set; }

        public IfritEncounterType IfritEncounterType { get; set; }

        public bool Get2ndBridgeEncounter { get; set; }

        public bool GetRedSoldierEncounter { get; set; }

        public QuistisPatternsOrderBy QuistisPatternsOrderBy { get; set; } = QuistisPatternsOrderBy.Frame;

        public bool ShowCarawayNPCMovement { get; set; }

        public BeepSound BeepSound { get; set; } = BeepSound.Ping1;

        public int BeepInterval { get; set; } = 400;

        public int BeepCount { get; set; } = 4;

        public int BeepOffsetFrames { get; set; }

        public bool LegacyCardMode { get; set; }

        public UpdateBranch UpdateBranch { get; set; } = UpdateBranch.Stable;

        public UltimeciaManipLanguage UltimeciaManipLanguage { get; set; } = UltimeciaManipLanguage.English;

        public Task<bool> IsCSRUpdateAvailable()
        {
            CheckInstalledGameLanguage();
            return DriveManager.IsNewCSRVersionAvailable();
        }


        public int GetZellDelayFrame()
        {
            if (CustomZellDelayFrame.HasValue) return CustomZellDelayFrame.Value;

            switch (Platform)
            {
                case Platform.PS2:
                    return 285;
                case Platform.PC:
                    return 69; // nice
                default: throw new ArgumentOutOfRangeException("Contact Kiitoksia because this should not have happened");
            }
        }
    }
}

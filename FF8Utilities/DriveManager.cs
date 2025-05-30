using Google.Apis.Auth.OAuth2;
using Google.Apis.Download;
using Google.Apis.Drive.v3;
using Google.Apis.Services;
using Google.Apis.Util.Store;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Google.Apis.Drive.v3.Data;
using File = Google.Apis.Drive.v3.Data.File;
using System.Text.RegularExpressions;
using System.Runtime;
using FF8Utilities.Models;
using FF8Utilities.Data;
using FF8Utilities.Properties;

namespace FF8Utilities
{
    public class DriveManager
    {
        private const string CSREnglishFolder = "1R0e4INF4fEgIYKb3o568yGEj1AUtAQwT";
        private const string CSRFrenchFolder = "1Y9l6Iuu3prrRT-VJq--XnTb2HYQa8ttW";
        private const string PSXMidiFolder = "1giHGMoAOjkjkS_DVFCLKnl5wT9j9p_Yx";

        private static DriveService DriveService;

        private MainModel Model;
        private SettingsModel Settings;

        public DriveManager(MainModel model, SettingsModel settings)
        {
            Model = model;
            Settings = settings;
        }

        public Version CurrentCSRVersion { get; private set; }

        public void CheckAndSetCurrentCSRVersion()
        {
            string csr;
            switch (Settings.CSRLanguage)
            {
                case CSRLanguage.English: csr = Const.CSREnglishFile; break;
                case CSRLanguage.French: csr = Const.CSRFrenchFile; break;
                default: throw new NotImplementedException();
            }

            // The CSR will start with this but will end in vX.X.zip, use this to determine the version
            if (!Directory.Exists(Const.PackagesFolder)) return; // Never downloaded
            string[] csrFiles = Directory.GetFiles(Const.PackagesFolder, $"{csr}_v*.zip");

            foreach (string csrFile in csrFiles)
            {
                Match match = Regex.Match(Path.GetFileName(csrFile), @"^.+v(.+)\.zip$");
                if (match.Success)
                {
                    string versionNumber = match.Groups[1].Value;
                    if (System.Version.TryParse(versionNumber, out Version version))
                    {
                        // Valid version
                        if (CurrentCSRVersion == null) CurrentCSRVersion = version;
                        else if (CurrentCSRVersion < version) CurrentCSRVersion = version;
                    }
                }
            }
        }

        public async Task<DriveService> GetDriveService()
        {
            if (DriveService == null)
            {
                // Not exactly a secret

                GoogleCredential credential = await GoogleCredential.FromFileAsync(Path.Combine(AppContext.BaseDirectory, "client_secret.json"), CancellationToken.None).ConfigureAwait(false);
                    credential = credential.CreateScoped(DriveService.Scope.DriveReadonly);

                    DriveService = new DriveService(new BaseClientService.Initializer() { HttpClientInitializer = credential, ApplicationName = "FF8 Utilities" });
            }  
               
            return DriveService;
        }

        private async Task<File> GetLatestCSRFile()
        {
            DriveService service = await GetDriveService().ConfigureAwait(false);
            FilesResource.ListRequest request = service.Files.List();

            string drivePath;
            switch (Settings.CSRLanguage)
            {
                case CSRLanguage.English:
                    drivePath = CSREnglishFolder;
                    break;
                case CSRLanguage.French:
                    drivePath = CSRFrenchFolder;
                    break;
                default: throw new NotImplementedException();
            }

            request.Q = $"'{drivePath}' in parents and trashed = false";
            request.Fields = "files(id, name, size)";
            request.PageSize = 1; // Should only ever be one file per folder

            FileList result = await request.ExecuteAsync().ConfigureAwait(false);
            return result.Files.FirstOrDefault();
        }

        /// <summary>
        /// Returns null if version could not be parsed
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        private Version GetFileVersion(File file)
        {
            Match match = Regex.Match(Path.GetFileName(file.Name), @"^.+_v?(.+)\.zip$");
            if (match.Success)
            {
                if (Version.TryParse(match.Groups[1].Value, out Version version))
                {
                    return version;
                }
            }

            return null;
        }

        public async Task<bool> IsNewCSRVersionAvailable()
        {
            File file = await GetLatestCSRFile();
            if (file == null) return false;

            Version newVersion = GetFileVersion(file);
            if (newVersion == null) return false;
            return newVersion > CurrentCSRVersion;
        }

        public async Task<DownloadResult> DownloadCSR(IProgress<decimal> progressMethod)
        {            
            File file = await GetLatestCSRFile();
            if (file == null) return DownloadResult.Error;
            Version newVersion = GetFileVersion(file);

            DriveService service = await GetDriveService().ConfigureAwait(false);

            FilesResource.GetRequest downloadRequest = service.Files.Get(file.Id);
            downloadRequest.MediaDownloader.ProgressChanged += progress =>
            {
                switch (progress.Status)
                {
                    case DownloadStatus.Downloading:
                        decimal percentage = (decimal)((float)progress.BytesDownloaded / file.Size.Value);
                        progressMethod.Report(percentage);
                        break;
                    case DownloadStatus.Completed:
                        progressMethod.Report(100m);
                        break;
                    case DownloadStatus.Failed:
                        progressMethod.Report(-1m);
                        break;
                }
            };

            using (MemoryStream ms = new MemoryStream())
            {
                IDownloadProgress downloadResult = await downloadRequest.DownloadAsync(ms).ConfigureAwait(false);
                if (downloadResult.Status == DownloadStatus.Completed)
                {
                    // Succesfully downloaded, save to folder

                    if (!Directory.Exists(Const.PackagesFolder)) Directory.CreateDirectory(Const.PackagesFolder);

                    string csrFilename;
                    switch (Settings.CSRLanguage)
                    {
                        case CSRLanguage.English:
                            csrFilename = Const.CSREnglishFile;
                            break;
                        case CSRLanguage.French:
                            csrFilename = Const.CSRFrenchFile;
                            break;
                        default: throw new NotImplementedException();
                    }

                    using (FileStream fs = new FileStream(Path.Combine(Const.PackagesFolder, $"{csrFilename}_v{newVersion.ToString()}.zip"), FileMode.Create, FileAccess.Write))
                    {
                        ms.Position = 0;
                        await ms.CopyToAsync(fs).ConfigureAwait(false);
                        CheckAndSetCurrentCSRVersion();
                    }
                }
            }
                
            return DownloadResult.Downloaded;
        }

        public async Task<DownloadResult> DownloadMusic(IProgress<decimal> progressMethod)
        {
            DriveService service = await GetDriveService().ConfigureAwait(false);
            FilesResource.ListRequest request = service.Files.List();


            request.Q = $"'{PSXMidiFolder}' in parents and trashed = false and name = 'ff8dm.zip'";
            request.Fields = "files(id, name, size)";
            request.PageSize = 1; // Should only ever be one file per folder

            FileList result = await request.ExecuteAsync().ConfigureAwait(false);
            File file = result.Files.FirstOrDefault();
            if (file == null)
            {
                return DownloadResult.Error;
            }

            FilesResource.GetRequest downloadRequest = service.Files.Get(file.Id);
            downloadRequest.MediaDownloader.ProgressChanged += progress =>
            {
                switch (progress.Status)
                {
                    case DownloadStatus.Downloading:
                        decimal percentage = (decimal)((float)progress.BytesDownloaded / file.Size.Value);
                        progressMethod.Report(percentage);
                        break;
                    case DownloadStatus.Completed:
                        progressMethod.Report(100m);
                        break;
                    case DownloadStatus.Failed:
                        progressMethod.Report(-1m);
                        break;
                }
            };

            using (MemoryStream ms = new MemoryStream())
            {
                IDownloadProgress downloadResult = await downloadRequest.DownloadAsync(ms).ConfigureAwait(false);
                if (downloadResult.Status == DownloadStatus.Completed)
                {
                    // Succesfully downloaded, save to folder
                    if (!Directory.Exists(Const.PackagesFolder)) Directory.CreateDirectory(Const.PackagesFolder);

                    using (FileStream fs = new FileStream(Path.Combine(Const.PackagesFolder, "ff8dm.zip"), FileMode.Create, FileAccess.Write))
                    {
                        ms.Position = 0;
                        await ms.CopyToAsync(fs).ConfigureAwait(false);
                    }
                }
            }

            return DownloadResult.Downloaded;
        }
    }
}

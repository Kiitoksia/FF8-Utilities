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

        private static DriveService DriveService;

        private MainModel Model;

        public DriveManager(MainModel model)
        {
            Model = model;
            CheckAndSetCurrentCSRVersion();
        }

        public Version CurrentCSRVersion { get; private set; }

        private void CheckAndSetCurrentCSRVersion()
        {
            string csr;
            switch (Model.Settings.CSRLanguage)
            {
                case CSRLanguage.English: csr = Const.CSREnglishFile; break;
                case CSRLanguage.French: csr = Const.CSRFrenchFile; break;
                default: throw new NotImplementedException();
            }

            // The CSR will start with this but will end in vX.X.zip, use this to determine the version
            if (!Directory.Exists(Const.PackagesFolder)) return; // Never downloaded
            string[] csrFiles = Directory.GetFiles(Path.Combine(Const.PackagesFolder), $"{csr}_v*.zip");

            foreach (string csrFile in csrFiles)
            {
                Match match = Regex.Match(Path.GetFileName(csrFile), "^.+v(.+)\\.zip$");
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

        public async Task<CSRCheckResult> DownloadCSR(CSRLanguage version, IProgress<decimal> progressMethod)
        {
            DriveService service = await GetDriveService().ConfigureAwait(false);
            FilesResource.ListRequest request = service.Files.List();

            string drivePath;
            string csrFilename;
            switch (version)
            {
                case CSRLanguage.English: 
                    drivePath = CSREnglishFolder; 
                    csrFilename = Const.CSREnglishFile;
                    break;
                case CSRLanguage.French: 
                    drivePath = CSRFrenchFolder; 
                    csrFilename = Const.CSRFrenchFile;
                    break;
                default: throw new NotImplementedException();
            }

            request.Q = $"'{drivePath}' in parents and trashed = false";
            request.OrderBy = "modifiedTime desc";
            request.Fields = "files(id, name, modifiedTime, size)";
            request.PageSize = 1; // Should only ever be one file per folder

            FileList result = await request.ExecuteAsync().ConfigureAwait(false);
            File file = result.Files.FirstOrDefault();

            Version newVersion = CurrentCSRVersion;

            if (file != null)
            {
                // Get the version number
                Match match = Regex.Match(Path.GetFileName(file.Name), "^.+v(.+)\\.zip$");
                if (match.Success)
                {
                    if (Version.TryParse(match.Groups[1].Value, out newVersion))
                    {
                        if (newVersion <= CurrentCSRVersion)
                        {
                            // Already up to date
                            return CSRCheckResult.UpToDate;
                        }
                    }
                }
                else
                {
                    return CSRCheckResult.Error;
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
                        
                        using (FileStream fs = new FileStream(Path.Combine(Const.PackagesFolder, $"{csrFilename}_v{newVersion.ToString()}.zip"), FileMode.Create, FileAccess.Write))
                        {
                            ms.Position = 0;
                            await ms.CopyToAsync(fs).ConfigureAwait(false);
                            CheckAndSetCurrentCSRVersion();
                        }
                    }
                }
                
                return CSRCheckResult.Downloaded;
            }

            return CSRCheckResult.Error;
        }
    }
}

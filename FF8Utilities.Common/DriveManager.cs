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

namespace FF8Utilities.Common
{
    public abstract class BaseDriveManager
    {
        private const string CSREnglishFolder = "1R0e4INF4fEgIYKb3o568yGEj1AUtAQwT";
        private const string CSRFrenchFolder = "1Y9l6Iuu3prrRT-VJq--XnTb2HYQa8ttW";
        private const string PSXMidiFolder = "1giHGMoAOjkjkS_DVFCLKnl5wT9j9p_Yx";
        private const string FrenchPracticeFolder = "1SsgQvURp3B7-VQ3VdP-T5d0uWgtnu5hj";
        private const string LateQuistisCSVFolder = "1G54gySh762w-skt6qLwj7wy0_X2M8O_d";

        private static DriveService DriveService;


        public BaseDriveManager()
        {
            
        }

        public Version CurrentCSRVersion { get; private set; }

        public Version CurrentPracticeVersion { get; private set; }

        public abstract CSRLanguage Language { get; }

        /// <summary>
        /// Handle if there is any additional tasks that must be handled before drive service can function
        /// </summary>
        public abstract Task Initialise { get; }

        public void CheckAndSetCurrentCSRVersion()
        {
            string csr;
            switch (Language)
            {
                case CSRLanguage.English: csr = Const.CSREnglishFile; break;
                case CSRLanguage.French: csr = Const.CSRFrenchFile; break;
                default: throw new NotImplementedException();
            }

            // The CSR will start with this but will end in vX.X.zip, use this to determine the version
            if (!Directory.Exists(Const.PackagesFolder)) return; // Never downloaded
            string[] csrFiles = Directory.GetFiles(Const.PackagesFolder, $"{csr}_v*.zip");

            CurrentCSRVersion = GetLatestVersion(csrFiles);

            string[] pracModFiles = Directory.GetFiles(Const.PackagesFolder, "prac_v*.zip");
            CurrentPracticeVersion = GetLatestVersion(pracModFiles);
        }

        private Version GetLatestVersion(string[] files)
        {
            Version latestVersion = null;
            foreach (string file in files)
            {
                Match match = Regex.Match(Path.GetFileName(file), @"^.+v(.+)\.zip$");
                if (match.Success)
                {
                    string versionNumber = match.Groups[1].Value;
                    if (System.Version.TryParse(versionNumber, out Version version))
                    {
                        // Valid version
                        if (latestVersion == null) latestVersion = version;
                        else if (latestVersion < version) latestVersion = version;
                    }
                }
            }

            return latestVersion;
        }

        public async Task<DriveService> GetDriveService()
        {
            if (DriveService == null)
            {
                await Initialise;
                // Not exactly a secret
                GoogleCredential credential = await CredentialFactory.FromFileAsync(Path.Combine(AppContext.BaseDirectory, "client_secret.json"), JsonCredentialParameters.ServiceAccountCredentialType, CancellationToken.None).ConfigureAwait(false);
                credential = credential.CreateScoped(DriveService.Scope.DriveReadonly);

                DriveService = new DriveService(new BaseClientService.Initializer() { HttpClientInitializer = credential, ApplicationName = "FF8 Utilities" });
            }  
               
            return DriveService;
        }

        private Task<File> GetLatestCSRFile()
        {
            string drivePath;
            switch (Language)
            {
                case CSRLanguage.English:
                    drivePath = CSREnglishFolder;
                    break;
                case CSRLanguage.French:
                    drivePath = CSRFrenchFolder;
                    break;
                default: throw new NotImplementedException();
            }

            return GetFile(drivePath);
        }

        private async Task<File> GetFile(string folderId)
        {
            DriveService service = await GetDriveService().ConfigureAwait(false);
            FilesResource.ListRequest request = service.Files.List();

            request.Q = $"'{folderId}' in parents and trashed = false and fileExtension=\"zip\"";
            request.Fields = "files(id, name, size, fileExtension)";
            request.PageSize = 1; // Should only ever be one file per folder

            FileList result = await request.ExecuteAsync().ConfigureAwait(false);
            return result.Files.FirstOrDefault();
        }

        private async Task<File> GetLatestPracticeFile()
        {
            if (Language != CSRLanguage.French)
            {
                // Unsupported currently, just return nothing
                return null;
            }

            return await GetFile(FrenchPracticeFolder).ConfigureAwait(false);
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
            CheckAndSetCurrentCSRVersion();
            File file = await GetLatestCSRFile();
            if (file == null) return false;

            Version newVersion = GetFileVersion(file);
            if (newVersion == null) return false;
            return CurrentCSRVersion == null || newVersion > CurrentCSRVersion;
        }

        public async Task<bool> IsNewPracticeModVersionAvailable()
        {
            File file = await GetLatestPracticeFile();
            if (file == null) return false;
            Version newVersion = GetFileVersion(file);
            if (newVersion == null) return false;
            return CurrentPracticeVersion == null || newVersion > CurrentPracticeVersion;
        }

        public async Task<DownloadResult> DownloadFile(File file, IProgress<decimal> progressMethod, string baseFileName, bool includeVersionInFilename = true)
        {
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
                        progressMethod?.Report(percentage);
                        break;
                    case DownloadStatus.Completed:
                        progressMethod?.Report(100m);
                        break;
                    case DownloadStatus.Failed:
                        progressMethod?.Report(-1m);
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

                    string filename = baseFileName;

                    if (includeVersionInFilename) filename += $"_v{newVersion.ToString()}";

                    using (FileStream fs = new FileStream(Path.Combine(Const.PackagesFolder, $"{filename}.{file.FileExtension}"), FileMode.Create, FileAccess.Write))
                    {
                        ms.Position = 0;
                        await ms.CopyToAsync(fs).ConfigureAwait(false);
                        CheckAndSetCurrentCSRVersion();
                    }
                }
            }

            return DownloadResult.Downloaded;
        }

        public async Task<DownloadResult> DownloadCSR(IProgress<decimal> progressMethod)
        {            
            File file = await GetLatestCSRFile();
            if (file == null) return DownloadResult.Error;

            string csrFilename;
            switch (Language)
            {
                case CSRLanguage.English:
                    csrFilename = Const.CSREnglishFile;
                    break;
                case CSRLanguage.French:
                    csrFilename = Const.CSRFrenchFile;
                    break;
                default: throw new NotImplementedException();
            }

            return await DownloadFile(file, progressMethod, csrFilename);
        }

        public async Task<DownloadResult> DownloadPracticeMod(IProgress<decimal> progressMethod)
        {
            File file = await GetLatestPracticeFile();
            if (file == null) return DownloadResult.Error;

            return await DownloadFile(file, progressMethod, "prac");
        }

        public async Task<DownloadResult> DownloadMusic(IProgress<decimal> progressMethod)
        {
            File file = await GetFile(PSXMidiFolder).ConfigureAwait(false);
            if (file == null) return DownloadResult.Error;

            return await DownloadFile(file, progressMethod, "ff8dm", false);
        }

        public async Task<DownloadResult> DownloadLateQuistisCSRFiles()
        {

            try
            {
                DriveService service = await GetDriveService().ConfigureAwait(false);
                FilesResource.ListRequest request = service.Files.List();

                request.Q = $"'{LateQuistisCSVFolder}' in parents and trashed = false";
                request.Fields = "files(id, name, size, fileExtension)";

                FileList result = await request.ExecuteAsync().ConfigureAwait(false);

                List<DownloadResult> results = new List<DownloadResult>();
                foreach (File file in result.Files)
                {
                    results.Add(await DownloadFile(file, null, Path.GetFileNameWithoutExtension(file.Name), false));
                }

                return results.Contains(DownloadResult.Error) ? DownloadResult.Error : DownloadResult.Downloaded;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
            
        }
    }
}

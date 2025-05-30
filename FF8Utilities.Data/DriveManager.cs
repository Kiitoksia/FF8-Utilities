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

namespace FF8Utilities.Data
{
    public static class DriveManager
    {
        private const string CSREnglishFolder = "1R0e4INF4fEgIYKb3o568yGEj1AUtAQwT";
        private const string CSRFrenchFolder = "1Y9l6Iuu3prrRT-VJq--XnTb2HYQa8ttW";

        private static DriveService DriveService;

        public static async Task<DriveService> GetDriveService()
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

        public static async Task DownloadCSR(CSRLanguage version, IProgress<decimal> progressMethod)
        {
            DriveService service = await GetDriveService().ConfigureAwait(false);
            FilesResource.ListRequest request = service.Files.List();

            string csr;
            switch (version)
            {
                case CSRLanguage.English: csr = CSREnglishFolder; break;
                case CSRLanguage.French: csr = CSRFrenchFolder; break;
                default: throw new NotImplementedException();
            }

            request.Q = $"'{csr}' in parents and trashed = false";
            request.OrderBy = "modifiedTime desc";
            request.Fields = "files(id, name, modifiedTime, size)";
            request.PageSize = 1; // Should only ever be one file per folder

            FileList result = await request.ExecuteAsync().ConfigureAwait(false);
            File file = result.Files.FirstOrDefault();

            if (file != null)
            {
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
                        string localFolderPath = Path.Combine(AppContext.BaseDirectory, "Packages");

                        if (!Directory.Exists(localFolderPath)) Directory.CreateDirectory(localFolderPath);
                        using (FileStream fs = new FileStream(Path.Combine(localFolderPath, file.Name), FileMode.Create, FileAccess.Write))
                        {
                            await ms.CopyToAsync(fs).ConfigureAwait(false);
                        }
                    }
                }
                
            }
        }
    }
}

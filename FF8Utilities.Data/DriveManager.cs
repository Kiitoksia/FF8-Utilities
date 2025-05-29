using Google.Apis.Auth.OAuth2;
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

        public static async Task<DriveService> GetDriveService()
        {
            GoogleCredential credential = await GoogleCredential.FromFileAsync(Path.Combine(AppContext.BaseDirectory, "service_account.json"), CancellationToken.None);

            DriveService service = new DriveService(new BaseClientService.Initializer() { HttpClientInitializer = credential, ApplicationName = "FF8 Utilities" });
            return service;
        }

        public static async Task DownloadCSR(CSRVersion version)
        {
            DriveService service = await GetDriveService();
            var request = service.Files.List();

            string csr;
            switch (version)
            {
                case CSRVersion.English: csr = CSREnglishFolder; break;
                case CSRVersion.French: csr = CSRFrenchFolder; break;
                default: throw new NotImplementedException();
            }

            request.Q = $"{CSRFolder}' in parents and trashed = false";
            request.OrderBy = "modifiedTime desc";
            request.Fields = "files(id, name, modifiedTime)";
            request.PageSize = 1;

            FileList result = await request.ExecuteAsync();
            File file = result.Files.FirstOrDefault();

            if (file != null)
            {
                FilesResource.GetRequest downloadRequest = service.Files.Get(file.Id);
                using (FileStream fs = new FileStream(Path.Combine(AppContext.BaseDirectory, "Packages", file.Name), FileMode.Create, FileAccess.Write))
                {
                    var test = await downloadRequest.DownloadAsync(fs);

                }
            }
        }
    }
}

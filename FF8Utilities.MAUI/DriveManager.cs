using FF8Utilities.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace FF8Utilities.MAUI
{
    public class DriveManager : BaseDriveManager
    {
        public DriveManager() : base()
        {
            
        }

        public override CSRLanguage Language => CSRLanguage.English; // CSR not possible on mobile, so essentially ignore

        public override Task Initialise => Task.Run(async () =>
        {
            string secretPath = Path.Combine(Const.PackagesFolder, "client_secret.json");
            if (!File.Exists(secretPath))
            {
                using (var assetStream = await FileSystem.OpenAppPackageFileAsync("client_secret.json"))
                {
                    using (var newFile = File.Create(secretPath))
                    {
                        await assetStream.CopyToAsync(newFile);
                    }
                }
            }
        });
    }
}

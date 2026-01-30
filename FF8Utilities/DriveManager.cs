using FF8Utilities.Common;
using FF8Utilities.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace FF8Utilities
{
    public class DriveManager : BaseDriveManager
    {
        private SettingsModel Settings;

        public DriveManager(SettingsModel settings)
        {
            Settings = settings;
        }


        public override CSRLanguage Language => Settings.CSRLanguage;

        public override Task Initialise => Task.CompletedTask;
    }
}

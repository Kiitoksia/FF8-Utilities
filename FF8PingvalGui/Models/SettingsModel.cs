using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FF8Utilities.Data;
using FF8Utilities.Entities;

namespace FF8Utilities.Models
{
    public class SettingsModel : BaseModel
    {
        private bool _autoLaunchUltimeciaScript = true;
        private Platform _platform = Platform.PS2;

        private readonly MainModel _mainWindowModel;

        public SettingsModel(MainModel model)
        {
            AutoLaunchUltimeciaScript = DataManager.Current.CurrentSettings.AutoLaunchUltimecia;
            Platform = DataManager.Current.CurrentSettings.Platform;
            SaveSettingsCommand = new Command(() => true, SaveSettings);
            _mainWindowModel = model;
        }

        private void SaveSettings(object sender, EventArgs eventArgs)
        {
            DataManager.Current.CurrentSettings.AutoLaunchUltimecia = AutoLaunchUltimeciaScript;
            DataManager.Current.CurrentSettings.Platform = Platform;
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

        public Command SaveSettingsCommand { get; }
    }
}

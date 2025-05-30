using System;
using System.Collections.Generic;
using System.IO;
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
        private bool _globalHotkeysEnabled;
        private readonly MainModel _mainWindowModel;
        private Platform _platform = Platform.PS2;
        private CSRLanguage _csrLanguage;

        private int? _customZellDelayFrame;
        private int _zellCountdownTimer = 3;


        public SettingsModel(MainModel model)
        {
            AutoLaunchUltimeciaScript = DataManager.Current.CurrentSettings.AutoLaunchUltimecia;
            Platform = DataManager.Current.CurrentSettings.Platform;
            AutoLaunchUltimeciaScript = DataManager.Current.CurrentSettings.AutoLaunchUltimecia;
            CustomZellDelayFrame = DataManager.Current.CurrentSettings.CustomZellDelayFrame;
            ZellCountdownTimer = DataManager.Current.CurrentSettings.ZellCountdownTimer;
            CSRLanguage = DataManager.Current.CurrentSettings.CSRLanguage;
            SaveSettingsCommand = new Command(() => true, SaveSettings);
            _mainWindowModel = model;
        }

        private void SaveSettings(object sender, EventArgs eventArgs)
        {
            DataManager.Current.CurrentSettings.AutoLaunchUltimecia = AutoLaunchUltimeciaScript;
            DataManager.Current.CurrentSettings.Platform = Platform;
            DataManager.Current.CurrentSettings.GlobalHotkeys = false;
            DataManager.Current.CurrentSettings.CustomZellDelayFrame = CustomZellDelayFrame;
            DataManager.Current.CurrentSettings.ZellCountdownTimer = ZellCountdownTimer;
            DataManager.Current.CurrentSettings.CSRLanguage = CSRLanguage;
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
        public bool GlobalHotkeysEnabled
        {
            get
            {
                return _globalHotkeysEnabled;
            }
            set
            {
                if (_globalHotkeysEnabled == value)
                    return;
                _globalHotkeysEnabled = value;
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


        public Command SaveSettingsCommand { get; }

        public Command DownloadCSRCommand { get; }

    }
}

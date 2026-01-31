using CardManipulation;
using FF8Utilities.Common;
using FF8Utilities.Common.Cards;
using FF8Utilities.Dialogs;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace FF8Utilities.Models
{
    public class CardTrackerModel : BaseZellCardTrackerModel
    {
        private bool _didGetSecondBridgeEncounter;
        private bool _didGetRedSoldierEncounter;
        private IfritEncounterType _ifritsCavernEncounterType;
        private bool _initialised;

        public CardTrackerModel() : base()
        {
            _didGetSecondBridgeEncounter = SettingsModel.Instance.Get2ndBridgeEncounter;
            _didGetRedSoldierEncounter = SettingsModel.Instance.GetRedSoldierEncounter;
            _ifritsCavernEncounterType = SettingsModel.Instance.IfritEncounterType;
            _initialised = true;
        }


        public override bool LegacyMode => SettingsModel.Instance.LegacyCardMode;

        public override bool DidGetSecondBridgeEncounter
        {
            get => _didGetSecondBridgeEncounter;
            set
            {
                _didGetSecondBridgeEncounter = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(Output));
                if (_initialised)
                {
                    // Changed setting, save
                    SettingsModel.Instance.Get2ndBridgeEncounter = value;
                    SettingsModel.Instance.Save();
                }
            }
        }

        public override bool DidGetRedSoldierEncounter
        {
            get => _didGetRedSoldierEncounter; 
            set
            {
                if (_didGetRedSoldierEncounter == value)
                    return;
                _didGetRedSoldierEncounter = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(Output));
                if (_initialised)
                {
                    // Changed setting, save
                    SettingsModel.Instance.GetRedSoldierEncounter = value;
                    SettingsModel.Instance.Save();
                }
            }
        }

        public override IfritEncounterType IfritsCavernEncounterType
        {
            get => _ifritsCavernEncounterType;
            set
            {
                _ifritsCavernEncounterType = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(BuelEncounterVisible));
                OnPropertyChanged(nameof(Output));
                if (_initialised)
                {
                    // Changed setting, save
                    SettingsModel.Instance.IfritEncounterType = value;
                    SettingsModel.Instance.Save();
                }
            }
        }


        public override BaseCardManipulationModel CreateCardManipModel(CardManip manip, uint state, string player, int? count)
        {
            return new CardManipulationModel(manip, state, player, SettingsModel.Instance.GetZellDelayFrame(), count);
        }

        public ZellCardCalculatorWindow Window { get; set; }

        public override async Task<uint?> LaunchQuistisPatterns(LateQuistisPattern pattern)
        {
            if (LegacyMode)
            {
                MainModel.Instance.LaunchCardScript(false, LateQuistisOutput, false);                
            }

            QuistisCardPatternWindow window = new QuistisCardPatternWindow(Window, pattern);
            window.Owner = Window;
            window.ShowDialog();
            if (!string.IsNullOrEmpty(window.ResultHex))
            {
                MainModel.Instance.UseCustomQuistisPattern = true;
                MainModel.Instance.CustomQuistisPattern = window.ResultHex;
                MainModel.Instance.Pattern = EarlyQuistisPattern.LateQuistis;
                QuistisCardObtained = true;   
                return uint.Parse(window.ResultHex, NumberStyles.HexNumber, CultureInfo.InvariantCulture);
            }
            else
            {
                MainModel.Instance.UseCustomQuistisPattern = false;
                MainModel.Instance.CustomQuistisPattern = null;
                MainModel.Instance.Pattern = EarlyQuistisPattern.Frame1;
                QuistisCardObtained = false;
            }

            return null;

        }

        public override void LaunchZellPatterns(string patternString, int? count)
        {
            MainModel.Instance.LaunchCardScript(true, Output, true);
        }

        public override void ShowMessage(string message, string caption)
        {
            MessageBox.Show(message, caption, MessageBoxButton.OK);
        }
    }
}

using CardManipulation;
using FF8Utilities.Common;
using FF8Utilities.Common.Cards;
using FF8Utilities.MAUI.Pages;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace FF8Utilities.MAUI.Models
{
    public class CardTrackerModel : BaseZellCardTrackerModel
    {
        private bool _launchingWindow;

        public override bool LegacyMode => Preferences.Get(nameof(LegacyMode), false);

        public override bool DidGetRedSoldierEncounter
        {
            get => Preferences.Get(nameof(DidGetRedSoldierEncounter), false);
            set
            {
                if (DidGetRedSoldierEncounter == value) return;
                Preferences.Set(nameof(DidGetRedSoldierEncounter), value);
                OnPropertyChanged();
                OnPropertyChanged(nameof(Output));
            }
        }
        public override bool DidGetSecondBridgeEncounter
        {
            get => Preferences.Get(nameof(DidGetSecondBridgeEncounter), false);
            set
            {
                if (DidGetSecondBridgeEncounter == value) return;
                Preferences.Set(nameof(DidGetSecondBridgeEncounter), value);
                OnPropertyChanged();
                OnPropertyChanged(nameof(Output));
            }
        }
        public override IfritEncounterType IfritsCavernEncounterType
        {
            get => Enum.Parse<IfritEncounterType>(Preferences.Get(nameof(IfritsCavernEncounterType), IfritEncounterType.Buel.ToString()));
            set
            {
                if (IfritsCavernEncounterType == value) return;
                Preferences.Set(nameof(IfritsCavernEncounterType), value.ToString());
                OnPropertyChanged();
                OnPropertyChanged(nameof(Output));
            }
        }


        public override BaseCardManipulationModel CreateCardManipModel(CardManip manip, uint state, string player, int? count)
        {
            return new CardManipulationModel(manip, state, player, App.DelayFrames, count);
        }

        public override async Task<uint?> LaunchQuistisPatterns(LateQuistisPattern pattern)
        {            
            try
            {
                LaunchingWindow = true;
                LateQuistisManipulationPage page = new LateQuistisManipulationPage(pattern, (CardManipulationModel)CreateCardManipModel(CardManip, 0, "fc01", pattern.RNGIndex));

                TaskCompletionSource tcs = new TaskCompletionSource();
                EventHandler handler = null;
                handler = (s, e) =>
                {
                    tcs.SetResult();
                    page.Unloaded -= handler;
                };
                page.Unloaded += handler;
                MainThread.BeginInvokeOnMainThread(() => App.Current.Windows[0].Page.Navigation.PushModalAsync(page));
                await tcs.Task;
                if (page.SelectedStrategy == null) return null;
                return uint.Parse(page.SelectedStrategy.ResultHex, NumberStyles.HexNumber, CultureInfo.InvariantCulture);
            }
            finally
            {
                LaunchingWindow = false;
            }
            
        }

        public override void LaunchZellPatterns(string patternString, int? count)
        {
            LaunchingWindow = true;
            uint state = uint.Parse(patternString, NumberStyles.HexNumber, CultureInfo.InvariantCulture);
            ZellManipulationPage page = new ZellManipulationPage((CardManipulationModel)CreateCardManipModel(CardManip, state, "zellmama", count));
            MainThread.BeginInvokeOnMainThread(async () =>
            {
                await App.Current.Windows[0].Page.Navigation.PushModalAsync(page);
                LaunchingWindow = false;
            });

        }

        public override void ShowMessage(string message, string caption)
        {
            MainThread.BeginInvokeOnMainThread(async () =>
            {
                await App.Current.Windows[0].Page.DisplayAlertAsync(caption, message, "OK");
            });
        }

        public bool LaunchingWindow 
        { 
            get => _launchingWindow; 
            set
            {
                if (_launchingWindow == value) return;
                _launchingWindow = value;
                OnPropertyChanged();
            }
        }
    }
}

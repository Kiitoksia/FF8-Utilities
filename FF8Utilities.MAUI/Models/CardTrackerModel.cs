using CardManipulation;
using FF8Utilities.Common;
using FF8Utilities.Common.Cards;
using FF8Utilities.MAUI.Pages;
using System;
using System.Collections.Generic;
using System.Text;

namespace FF8Utilities.MAUI.Models
{
    public class CardTrackerModel : BaseZellCardTrackerModel
    {
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

        public override void LaunchQuistisPatterns(LateQuistisPattern pattern)
        {
            LateQuistisManipulationPage page = new LateQuistisManipulationPage();
            page.Model = pattern;
            MainThread.BeginInvokeOnMainThread(() => App.Current.Windows[0].Page.Navigation.PushModalAsync(page));
        }

        public override void LaunchZellPatterns()
        {
            throw new NotImplementedException();
        }

        public override void ShowMessage(string message, string caption)
        {
            MainThread.BeginInvokeOnMainThread(async () =>
            {
                await App.Current.Windows[0].Page.DisplayAlertAsync(caption, message, "OK");
            });
        }
    }
}

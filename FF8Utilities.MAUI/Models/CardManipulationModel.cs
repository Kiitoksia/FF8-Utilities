using FF8Utilities.Common;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CardManipulation;
using System.Diagnostics;
using CommunityToolkit.Maui.Views;

namespace FF8Utilities.MAUI.Models
{
    [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicProperties | DynamicallyAccessedMemberTypes.PublicMethods)]
    public class CardManipulationModel : BaseCardManipulationModel
    {
        private Timer _currentlyPlayingTimer;


        public CardManipulationModel(CardManip manip, uint state, string player, int? delayFrames, int? rngModifier) : base(manip, state, player, delayFrames, rngModifier)
        {
            PropertyChanged += (s, e) =>
            {
                if (e.PropertyName == nameof(TextColor)) OnPropertyChanged(nameof(TextColourMaui));
                else if (e.PropertyName == nameof(InstantMashBackgroundColor)) OnPropertyChanged(nameof(InstantMashBackgroundMaui));
            };
        }

        public event EventHandler RenderTimerTick;

        //private void RenderTick(object sender, EventArgs args)
        //{
        //    if (!_renderStopWatch.IsRunning) return;
        //    RenderTimerTick?.Invoke(this, EventArgs.Empty);
        //    OnRenderTick(_renderStopWatch.Elapsed);
        //}

        public override int CountdownTimer => Preferences.Get(nameof(CountdownTimer), 3);

        public override int BeepInterval => Preferences.Get(nameof(BeepInterval), 400);

        public override int BeepCount => Preferences.Get(nameof(BeepCount), 4);

        public override int BeepOffsetFrames => Preferences.Get(nameof(BeepOffsetFrames), 0);

        public Color TextColourMaui => Color.FromRgba(TextColor.R, TextColor.G, TextColor.B, TextColor.A);

        public Color InstantMashBackgroundMaui => Color.FromRgba(InstantMashBackgroundColor.R, InstantMashBackgroundColor.G, InstantMashBackgroundColor.B, InstantMashBackgroundColor.A);

        public override Common.Platform Platform => App.Platform;

        protected override void PauseBeeps()
        {
            _currentlyPlayingTimer?.Dispose();
            _currentlyPlayingTimer = null;
        }


        protected override void PlayBeeps(BeepSchedule schedule)
        {
            int currentBeeps = 1;
            _currentlyPlayingTimer = new Timer(_ =>
            {
                if (TimingOptions.HasFlag(CardTrackingTimingOptions.Vibration))
                {
                    bool finalBeep = currentBeeps >= schedule.Count;
#if IOS
                    // iOS can only vibrate at 500ms fixed, so only vibrate on the final beep
                    if (finalBeep) Vibration.Vibrate();
#else
                    // Android supports variable vibration lengths, use short vibrations for incoming, and a long for the hit
                    Vibration.Vibrate(finalBeep ? 500 : 20);
#endif
                }

                if (TimingOptions.HasFlag(CardTrackingTimingOptions.Beeps))
                {
                    MainThread.BeginInvokeOnMainThread(() =>
                    {
                        MediaPlayer?.Play();
                    });
                }

                currentBeeps++;

            }, null, schedule.InitialDelayMs, schedule.IntervalMs);
            // TODO
        }

        public override void Dispose()
        {            
            base.Dispose();            
        }

        public override void TimerStarted()
        {
            
        }

        public override void TimerStopped()
        {
            
        }

        public static CardTrackingTimingOptions TimingOptions
        {
            get => Enum.Parse<CardTrackingTimingOptions>(Preferences.Get(nameof(TimingOptions), CardTrackingTimingOptions.BeepsAndVibration.ToString()));
            set => Preferences.Set(nameof(TimingOptions), value.ToString());
        }

        public MediaElement MediaPlayer { get; set; }

    }

    [Flags]
    public enum CardTrackingTimingOptions
    {
        None = 1,
        Beeps = 2,
        Vibration = 4,
        BeepsAndVibration = 2 + 4
    }
    
}

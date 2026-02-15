using CardManipulation;
using CommunityToolkit.Maui.Views;
using FF8Utilities.Common;
using Plugin.Maui.Audio;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FF8Utilities.MAUI.Models
{
    [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicProperties | DynamicallyAccessedMemberTypes.PublicMethods)]
    public class CardManipulationModel : BaseCardManipulationModel
    {
        private Timer _currentlyPlayingTimer;
        private IAudioPlayer _audioManager;
        private Task _audioCreatedTask;

        public CardManipulationModel(CardManip manip, uint state, string player, int? delayFrames, int? rngModifier) : base(manip, state, player, delayFrames, rngModifier)
        {
            PropertyChanged += (s, e) =>
            {
                if (e.PropertyName == nameof(TextColor)) OnPropertyChanged(nameof(TextColourMaui));
                else if (e.PropertyName == nameof(InstantMashBackgroundColor)) OnPropertyChanged(nameof(InstantMashBackgroundMaui));
            };

            _audioCreatedTask = Task.Run(async () =>
            {
                _audioManager = AudioManager.Current.CreatePlayer(await FileSystem.OpenAppPackageFileAsync("clack.wav"));
            });
        }

        public event EventHandler RenderTimerTick;

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
            int playedBeeps = 0;
            _currentlyPlayingTimer = new Timer(async _ =>
            {
                await Task.WhenAll(
                    Task.Run(() =>
                    {
                        if (TimingOptions.HasFlag(CardTrackingTimingOptions.Vibration))
                        {
                            bool finalBeep = playedBeeps + 1 >= schedule.Count;
#if IOS
                    // iOS can only vibrate at 500ms fixed, so only vibrate on the final beep
                    if (finalBeep) Vibration.Vibrate();
#else
                            // Android supports variable vibration lengths, use short vibrations for incoming, and a long for the hit
                            Vibration.Vibrate(finalBeep ? 500 : 20);
#endif
                        }
                    }),
                    Task.Run(async () =>
                    {
                        if (TimingOptions.HasFlag(CardTrackingTimingOptions.Beeps))
                        {
                            await _audioCreatedTask;
                            _audioManager.Play();
                        }                        
                    })
                );
                               
                playedBeeps++;
                if (playedBeeps >= schedule.Count)
                {
                    _currentlyPlayingTimer.Dispose();
                    _currentlyPlayingTimer = null;
                    schedule.OnCompleted?.Invoke();
                }
            }, null, schedule.InitialDelayMs, schedule.IntervalMs);
            // TODO
        }

        public override void Dispose()
        {            
            base.Dispose();
            _audioManager.Stop();
            _audioManager.Dispose();
            _audioManager = null;
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

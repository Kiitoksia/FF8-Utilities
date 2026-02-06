using CardManipulation;
using CardManipulation.Models;
using FF8Utilities.Common;
using FlowTimer;
using System;
using System.IO;
using System.Threading;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

namespace FF8Utilities.Models
{
    public class CardManipulationModel : BaseCardManipulationModel
    {
        private AudioContext _audioContext;
        private BeepSound _loadedBeepSound;
        private byte[] _pcm;
        private Timer _currentlyPlayingTimer;
        private TimeSpan _lastRenderTime;

        public CardManipulationModel(CardManip manip, uint state, string player, int delayFrames, int? rngModifier)
            : base(manip, state, player, delayFrames, rngModifier)
        {
            CompositionTarget.Rendering += CompositionTarget_Rendering;
            _loadedBeepSound = SettingsModel.Instance.BeepSound;
        }

        private void CompositionTarget_Rendering(object sender, EventArgs e)
        {
            var args = (RenderingEventArgs)e;
            var deltaTime = args.RenderingTime - _lastRenderTime;
            _lastRenderTime = args.RenderingTime;

            // Drive base rendering logic
            OnRenderTick(args.RenderingTime);

            // Notify UI that brushes may need updating
            OnPropertyChanged(nameof(TextBrush));
            OnPropertyChanged(nameof(InstantMashBackgroundBrush));
        }

        public override void Dispose()
        {
            CompositionTarget.Rendering -= CompositionTarget_Rendering;
            _audioContext?.Destroy();
            _currentlyPlayingTimer?.Dispose();
            base.Dispose();
        }

        // Convert base Color to WPF Brush for binding
        public Brush TextBrush =>
            new SolidColorBrush(System.Windows.Media.Color.FromRgb(base.TextColor.R, base.TextColor.G, base.TextColor.B));

        public Brush InstantMashBackgroundBrush =>
            new SolidColorBrush(System.Windows.Media.Color.FromRgb(base.InstantMashBackgroundColor.R, base.InstantMashBackgroundColor.G, base.InstantMashBackgroundColor.B));

        protected override void PlayBeeps(BeepSchedule schedule)
        {
            if (_loadedBeepSound != SettingsModel.Instance.BeepSound)
            {
                _audioContext?.Destroy();
                _audioContext = null;
                _loadedBeepSound = SettingsModel.Instance.BeepSound;
            }

            if (_audioContext == null)
            {
                Stream waveStream;
                switch (SettingsModel.Instance.BeepSound)
                {
                    case BeepSound.Ping1: waveStream = Properties.Resources.ping1; break;
                    case BeepSound.Ping2: waveStream = Properties.Resources.ping2; break;
                    case BeepSound.Click: waveStream = Properties.Resources.click1; break;
                    case BeepSound.Clack: waveStream = Properties.Resources.clack; break;
                    default: throw new ArgumentOutOfRangeException(nameof(SettingsModel.Instance.BeepSound), "Unknown beep sound setting");
                }

                using (waveStream)
                using (var memoryStream = new MemoryStream())
                {
                    waveStream.CopyTo(memoryStream);
                    Wave.LoadWAV(memoryStream.ToArray(), out _pcm, out SDL.SDL_AudioSpec spec);
                    _audioContext = new AudioContext(spec.freq, spec.format, spec.channels);
                }
            }

            int interval = schedule.IntervalMs;
            int desiredBeeps = schedule.Count;
            int delay = schedule.InitialDelayMs;

            int playedBeeps = 0;
            _currentlyPlayingTimer = new Timer(_ =>
            {
                _audioContext.QueueAudio(_pcm);
                playedBeeps++;
                if (playedBeeps >= desiredBeeps)
                {
                    _currentlyPlayingTimer?.Dispose();
                    schedule.OnCompleted?.Invoke();
                }
            }, null, delay, interval);
        }

        protected override void PauseBeeps()
        {
            _audioContext?.ClearQueuedAudio();
            _currentlyPlayingTimer?.Dispose();
            _currentlyPlayingTimer = null;
        }

        public override void TimerStarted()
        {
            
        }

        public override void TimerStopped()
        {
            
        }

        // Bind base to settings for WPF
        public override int CountdownTimer => SettingsModel.Instance.ZellCountdownTimer;
        public override int BeepInterval => SettingsModel.Instance.BeepInterval;
        public override int BeepCount => SettingsModel.Instance.BeepCount;
        public override int BeepOffsetFrames => SettingsModel.Instance.BeepOffsetFrames;

        public override Platform Platform => SettingsModel.Instance.Platform;
    }
}
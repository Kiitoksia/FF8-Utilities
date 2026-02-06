using FF8Utilities.Common;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CardManipulation;
using System.Diagnostics;

namespace FF8Utilities.MAUI.Models
{
    [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicProperties | DynamicallyAccessedMemberTypes.PublicMethods)]
    public class CardManipulationModel : BaseCardManipulationModel
    {
        private IDispatcherTimer _renderTimer;
        private Stopwatch _renderStopWatch;

        public CardManipulationModel(CardManip manip, uint state, string player, int? delayFrames, int? rngModifier) : base(manip, state, player, delayFrames, rngModifier)
        {
            _renderTimer = Application.Current.Dispatcher.CreateTimer();
            _renderTimer.Interval = TimeSpan.FromMilliseconds(16); // 60FPS
            _renderStopWatch = new Stopwatch();
            _renderTimer.Tick += RenderTick;

            _renderTimer.Start();
            _renderStopWatch.Start();

            PropertyChanged += (s, e) =>
            {
                if (e.PropertyName == nameof(TextColor)) OnPropertyChanged(nameof(TextColourMaui));
                else if (e.PropertyName == nameof(InstantMashBackgroundColor)) OnPropertyChanged(nameof(InstantMashBackgroundMaui));
            };
        }

        public event EventHandler RenderTimerTick;

        public void Refresh()
        {
            RenderTick(this, EventArgs.Empty);
        }

        private void RenderTick(object sender, EventArgs args)
        {
            RenderTimerTick?.Invoke(this, EventArgs.Empty);
            OnRenderTick(_renderStopWatch.Elapsed);
        }

        public override int CountdownTimer => Preferences.Get(nameof(CountdownTimer), 3);

        public override int BeepInterval => Preferences.Get(nameof(BeepInterval), 400);

        public override int BeepCount => Preferences.Get(nameof(BeepCount), 4);

        public override int BeepOffsetFrames => Preferences.Get(nameof(BeepOffsetFrames), 0);

        public Color TextColourMaui => Color.FromRgba(TextColor.R, TextColor.G, TextColor.B, TextColor.A);

        public Color InstantMashBackgroundMaui => Color.FromRgba(InstantMashBackgroundColor.R, InstantMashBackgroundColor.G, InstantMashBackgroundColor.B, InstantMashBackgroundColor.A);

        public override Common.Platform Platform => App.Platform;

        protected override void PauseBeeps()
        {
            // TODO
        }

        protected override void PlayBeeps(BeepSchedule schedule)
        {
            // TODO
        }

        public override void Dispose()
        {            
            base.Dispose();
            _renderTimer?.Stop();
            if (_renderTimer != null) _renderTimer.Tick -= RenderTick;
            _renderTimer = null;
        }

        public override void TimerStarted()
        {
            _renderStopWatch.Restart();
        }

        public override void TimerStopped()
        {
            _renderStopWatch.Stop();
        }
    }
}

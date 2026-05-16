using System;
using System.Threading;
using System.Threading.Tasks;
using CardManipulation;
using FF8Utilities.Common;
using FF8Utilities.Web.Services;

namespace FF8Utilities.Web.Models
{
    public class CardManipulationModel : BaseCardManipulationModel
    {
        private SettingsService _settings;
        private CancellationTokenSource _timerCts;

        public CardManipulationModel(CardManip manip, uint state, string player, int? delayFrames, int? rngModifier, SettingsService settings)
            : base(manip, state, player, delayFrames, rngModifier)
        {
            _settings = settings;
        }

        public override int CountdownTimer => _settings?.CountdownTimer ?? 3;
        public override int BeepInterval => _settings?.BeepInterval ?? 400;
        public override int BeepCount => _settings?.BeepCount ?? 4;
        public override int BeepOffsetFrames => _settings?.BeepOffsetFrames ?? 0;
        public override Platform Platform => _settings?.Platform ?? Platform.PC;

        public event Action Redraw;

        public event Action<BeepSchedule, BeepSound> PlayAudio;

        public event Action PauseAudio;

        public override void TimerStarted()
        {
            _timerCts = new CancellationTokenSource();
            _ = RunRenderLoopAsync(_timerCts.Token);
        }

        public override void TimerStopped()
        {
            _timerCts?.Cancel();
            _timerCts = null;
        }

        private async Task RunRenderLoopAsync(CancellationToken ct)
        {
            using(var timer = new PeriodicTimer(TimeSpan.FromMilliseconds(16.67)))
            {
                try
                {
                    while (await timer.WaitForNextTickAsync(ct))
                    {
                        Refresh();
                        Redraw?.Invoke();
                    }
                }
                catch (OperationCanceledException)
                {

                }
            }
            
        }

        protected override void PauseBeeps()
        {
            PauseAudio?.Invoke();
        }

        protected override void PlayBeeps(BeepSchedule schedule)
        {
            
            PlayAudio?.Invoke(schedule, _settings.BeepSound);
        }

        public async Task Initialise()
        {
            await _settings.Initialise();
        }
    }
}

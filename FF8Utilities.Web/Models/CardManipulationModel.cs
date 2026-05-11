using Blazored.LocalStorage;
using CardManipulation;
using FF8Utilities.Common;
using FF8Utilities.Web.Services;

namespace FF8Utilities.Web.Models
{
    public class CardManipulationModel : BaseCardManipulationModel
    {
        private ISettingsService _settings;


        public CardManipulationModel(CardManip manip, uint state, string player, int? delayFrames, int? rngModifier, ISettingsService settings) : base(manip, state, player, delayFrames, rngModifier)
        {
            _settings = settings;
        }

        public override int CountdownTimer => _settings.CountdownTimer;

        public override int BeepInterval => _settings.BeepInterval;

        public override int BeepCount => _settings.BeepCount;

        public override int BeepOffsetFrames => _settings.BeepOffsetFrames;

        public override Platform Platform => _settings.Platform;

        public override void TimerStarted()
        {
            throw new NotImplementedException();
        }

        public override void TimerStopped()
        {
            throw new NotImplementedException();
        }

        protected override void PauseBeeps()
        {
            throw new NotImplementedException();
        }

        protected override void PlayBeeps(BeepSchedule schedule)
        {
            throw new NotImplementedException();
        }




        public async Task Initialise()
        {
            await _settings.Initialise();
        }
    }
}

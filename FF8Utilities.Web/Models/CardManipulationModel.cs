using System;
using System.Threading.Tasks;
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

        public override int CountdownTimer => _settings?.CountdownTimer ?? 3;

        public override int BeepInterval => _settings?.BeepInterval ?? 400;

        public override int BeepCount => _settings?.BeepCount ?? 4;

        public override int BeepOffsetFrames => _settings?.BeepOffsetFrames ?? 0;

        public override Platform Platform => _settings?.Platform ?? Platform.PC;

        public override void TimerStarted()
        {
            
        }

        public override void TimerStopped()
        {
            
        }

        protected override void PauseBeeps()
        {
           
        }

        protected override void PlayBeeps(BeepSchedule schedule)
        {
            
        }




        public async Task Initialise()
        {
            await _settings.Initialise();
        }
    }
}

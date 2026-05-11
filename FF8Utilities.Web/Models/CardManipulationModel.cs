using CardManipulation;
using Blazored.LocalStorage;
using FF8Utilities.Common;

namespace FF8Utilities.Web.Models
{
    public class CardManipulationModel : BaseCardManipulationModel
    {
        private ILocalStorageService _storage;
        private int _countdownTimer;
        private int _beepInterval;
        private int _beepCount;
        private int _beepOffsetFrames;
        private Platform _platform;


        public CardManipulationModel(CardManip manip, uint state, string player, int? delayFrames, int? rngModifier, ILocalStorageService storage) : base(manip, state, player, delayFrames, rngModifier)
        {
            _storage = storage;
        }

        public override int CountdownTimer => _countdownTimer;

        public override int BeepInterval => _beepInterval;

        public override int BeepCount => _beepCount;

        public override int BeepOffsetFrames => _beepOffsetFrames;

        public override Platform Platform => _platform;

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

        public async Task SaveSettings()
        {
            await _storage.SetItemAsync(nameof(CountdownTimer), CountdownTimer);
            await _storage.SetItemAsync(nameof(BeepInterval), BeepInterval);
            await _storage.SetItemAsync(nameof(BeepCount), BeepCount);
            await _storage.SetItemAsync(nameof(BeepOffsetFrames), BeepOffsetFrames);
            await _storage.SetItemAsync(nameof(Platform), Platform);
        }


        public async Task Initialise()
        {
            async Task<T> GetItemOrDefault<T>(string key, T defaultVal = default)
            {
                if (await _storage.ContainKeyAsync(key)) return await _storage.GetItemAsync<T>(key);
                return defaultVal;
            }

            _countdownTimer = await GetItemOrDefault<int>(nameof(CountdownTimer), 3);
            _countdownTimer = await GetItemOrDefault<int>(nameof(CountdownTimer), 3);
            _beepInterval = await GetItemOrDefault<int>(nameof(BeepInterval), 500);
            _beepCount = await GetItemOrDefault<int>(nameof(BeepCount), 3);
            _beepOffsetFrames = await GetItemOrDefault<int>(nameof(BeepOffsetFrames), 0);
            _platform = await GetItemOrDefault<Platform>(nameof(Platform), Platform.PC);
        }
    }
}

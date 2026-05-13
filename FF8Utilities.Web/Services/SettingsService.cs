using System.Threading.Tasks;
using Blazored.LocalStorage;
using FF8Utilities.Common;

namespace FF8Utilities.Web.Services
{
    public interface ISettingsService
    {
        int CountdownTimer { get; set; }
        int BeepInterval { get; set; }
        int BeepCount { get; set; }
        int BeepOffsetFrames { get; set; }
        Platform Platform { get; set; }
        int? DelayFrames { get; set; }
        bool DidGetRedSoldierEncounter { get; set; }
        bool DidGetSecondBridgeEncounter { get; set; }
        IfritEncounterType IfritsCavernEncounterType { get; set; }

        Task Initialise();
        Task Save();
    }

    public class SettingsService : ISettingsService
    {
        private ILocalStorageService _storage;
        public SettingsService(ILocalStorageService storage)
        {
            _storage = storage;
        }

        public int CountdownTimer { get; set; }
        public int BeepInterval { get; set; }
        public int BeepCount { get; set; }
        public int BeepOffsetFrames { get; set; }
        public Platform Platform { get; set; }
        public int? DelayFrames { get; set; }
        public bool DidGetRedSoldierEncounter { get; set; }
        public bool DidGetSecondBridgeEncounter { get; set; }
        public IfritEncounterType IfritsCavernEncounterType { get; set; }


        private async Task<T> GetSetting<T>(string key, T defaultVal = default)
        {
            if (await _storage.ContainKeyAsync(key)) return await _storage.GetItemAsync<T>(key);
            return defaultVal;
        }


        public async Task Initialise()
        {
            CountdownTimer = await GetSetting(nameof(CountdownTimer), 3);
            BeepInterval = await GetSetting(nameof(BeepInterval), 400);
            BeepCount = await GetSetting(nameof(BeepCount), 4);
            BeepOffsetFrames = await GetSetting(nameof(BeepOffsetFrames), 0);
            Platform = await GetSetting(nameof(Platform), Platform.PC);
            DelayFrames = await GetSetting<int?>(nameof(DelayFrames), null);
            DidGetRedSoldierEncounter = await GetSetting<bool>(nameof(DidGetRedSoldierEncounter), false);
            DidGetSecondBridgeEncounter = await GetSetting<bool>(nameof(DidGetSecondBridgeEncounter), false);
            IfritsCavernEncounterType = await GetSetting<IfritEncounterType>(nameof(IfritsCavernEncounterType), IfritEncounterType.RedBat);
        }

        public async Task Save()
        {
            await _storage.SetItemAsync(nameof(CountdownTimer), CountdownTimer);
            await _storage.SetItemAsync(nameof(BeepInterval), BeepInterval);
            await _storage.SetItemAsync(nameof(BeepCount), BeepCount);
            await _storage.SetItemAsync(nameof(BeepOffsetFrames), BeepOffsetFrames);
            await _storage.SetItemAsync(nameof(Platform), Platform);
            await _storage.SetItemAsync(nameof(DelayFrames), DelayFrames);
            await _storage.SetItemAsync(nameof(DidGetRedSoldierEncounter), DidGetRedSoldierEncounter);
            await _storage.SetItemAsync(nameof(DidGetSecondBridgeEncounter), DidGetSecondBridgeEncounter);
            await _storage.SetItemAsync(nameof(IfritsCavernEncounterType), IfritsCavernEncounterType);
        }
    }
}

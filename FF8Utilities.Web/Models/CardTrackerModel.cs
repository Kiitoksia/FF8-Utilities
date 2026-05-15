using CardManipulation;
using FF8Utilities.Common;
using FF8Utilities.Common.Cards;
using FF8Utilities.Web.Services;
using System;
using System.Globalization;
using System.Threading.Tasks;


namespace FF8Utilities.Web.Models
{
    public class CardTrackerModel : BaseZellCardTrackerModel
    {
        private ISettingsService _settings;
        private TaskCompletionSource<uint?> _quistisTaskCompletionSource;

        public CardTrackerModel(ISettingsService settings) : base()
        {
            _settings = settings;
        }

        public override bool LegacyMode => false; // Legacy not supported on Web

        public override bool DidGetRedSoldierEncounter
        {
            get => _settings?.DidGetRedSoldierEncounter ?? false;
            set => _settings.DidGetRedSoldierEncounter = value; //  TODO Maybe need to call SaveAsync here
        }
        public override bool DidGetSecondBridgeEncounter
        {
            get => _settings?.DidGetSecondBridgeEncounter ?? false;
            set => _settings.DidGetSecondBridgeEncounter = value;
        }
        public override IfritEncounterType IfritsCavernEncounterType
        {
            get => _settings?.IfritsCavernEncounterType ?? IfritEncounterType.RedBat;
            set => _settings.IfritsCavernEncounterType = value;
        }

        public LateQuistisPattern CurrentLateQuistisPattern { get; set; }

        public event Action<CardManipulationModel> StartLateQuistisPattern;

        public event Action<CardManipulationModel> StartZellPatterns;

        public override BaseCardManipulationModel CreateCardManipModel(CardManip manip, uint state, string player, int? count)
        {
            return new CardManipulationModel(manip, state, player, _settings?.DelayFrames, count, _settings);
        }

        public override async Task<uint?> LaunchQuistisPatterns(LateQuistisPattern pattern)
        {
            _quistisTaskCompletionSource = new TaskCompletionSource<uint?>();
            CurrentLateQuistisPattern = pattern;
            CardManipulationModel model = (CardManipulationModel)CreateCardManipModel(CardManip, 0, "fc01", pattern.RNGIndex);
            StartLateQuistisPattern?.Invoke(model);
            return await _quistisTaskCompletionSource.Task;
        }

        public void SubmitQuistisResult(uint? result)
        {
            CurrentLateQuistisPattern = null;
            _quistisTaskCompletionSource?.TrySetResult(result);
        }

        public override void LaunchZellPatterns(string patternString, int? count)
        {
            uint state = uint.Parse(patternString, System.Globalization.NumberStyles.HexNumber, CultureInfo.InvariantCulture);
            CardManipulationModel model = (CardManipulationModel)CreateCardManipModel(CardManip, state, "zellmama", count);
            StartZellPatterns?.Invoke(model);
        }

        public override void ShowMessage(string message, string caption)
        {
            
        }
    }
}

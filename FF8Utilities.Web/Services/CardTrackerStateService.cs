using FF8Utilities.Common;
using FF8Utilities.Common.Cards;
using FF8Utilities.Web.Models;

namespace FF8Utilities.Web.Services
{
    public class CardTrackerStateService
    {
        public EarlyQuistisPattern SelectedEarlyQuistisPattern { get; set; }

        public LateQuistisPattern SelectedLateQuistisPattern { get; set; }

        public uint? LateQuistisResult { get; set; }

        public CardManipulationModel ManipModel { get; set; }

        /// <summary>
        /// Clears all current card values
        /// </summary>
        public void Reset()
        {
            SelectedEarlyQuistisPattern = null;
            SelectedLateQuistisPattern = null;
            LateQuistisResult = null;
            ManipModel = null;
        }
    }
}

using System;
using FF8Utilities.Common;
using FF8Utilities.Web.Models;
using FF8Utilities.Web.Services;
using Microsoft.AspNetCore.Components;

namespace FF8Utilities.Web.V2
{
    /// <summary>
    /// UI state for the v2 pages. Keeps the card tracker alive while the Quistis/Zell
    /// pattern pages are open so encounter counts survive navigating back and forth.
    /// </summary>
    public class V2UiService
    {
        private readonly NavigationManager _navigation;
        private readonly SettingsService _settings;
        private readonly CardTrackerStateService _cardState;

        public V2UiService(NavigationManager navigation, SettingsService settings, CardTrackerStateService cardState)
        {
            _navigation = navigation;
            _settings = settings;
            _cardState = cardState;
        }

        public event Action SettingsRequested;

        public void OpenSettings() => SettingsRequested?.Invoke();

        /// <summary>Home page: Early (true) or Late (false) Quistis</summary>
        public bool EarlyQuistis { get; set; } = true;

        /// <summary>Home page: track battles for 1st try Zell (true) or 2nd try Zell (false)</summary>
        public bool TrackZell { get; set; } = true;

        public CardTrackerModel Tracker { get; private set; }

        public int TrackerTab { get; set; }

        /// <summary>One-off message shown when the tracker page next opens</summary>
        public string TrackerMessage { get; set; }

        public CardTrackerModel StartTracker(EarlyQuistisPattern earlyPattern)
        {
            CardTrackerModel model = new CardTrackerModel(_settings);
            model.EarlyQuistisPattern = earlyPattern;
            model.QuistisPatternResult = earlyPattern?.Result.ToString("x8");
            model.StartLateQuistisPattern += manipModel =>
            {
                _cardState.ManipModel = manipModel;
                _cardState.SelectedLateQuistisPattern = model.CurrentLateQuistisPattern;
                _navigation.NavigateTo("v2/quistis-card");
            };
            model.StartZellPatterns += manipModel =>
            {
                _cardState.ManipModel = manipModel;
                _navigation.NavigateTo("v2/zell-card");
            };

            Tracker = model;
            TrackerTab = 0;
            TrackerMessage = null;
            return model;
        }

        public void ClearTracker()
        {
            Tracker = null;
            TrackerTab = 0;
            TrackerMessage = null;
        }
    }
}

using CardManipulation;
using CardManipulation.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;

namespace FF8Utilities.Common
{
    public abstract class BaseCardManipulationModel : BaseModel, IDisposable
    {
        private bool _rareCardAvailable;
        private bool _rareCardSoon;
        private string _snake;
        private decimal _timeElapsedSeconds;
        private Color _textColor = Color.White;
        private TimeSpan _lastRenderTime = TimeSpan.Zero;
        private string _rareCardTimer;
        private string _recoveryPattern;
        private readonly CardManip _manip;
        private readonly string _player;
        private CancellationTokenSource _cts;
        private string _errorText;
        private uint? _lastState;
        private string _foundCards;
        private string _explanation;
        private Color _instantMashBackgroundColor;
        private string _firstFrameAvailableFramesDisplay;
        private bool _isPlayingBeeps;
        private bool _willBeepsPlay;
        private bool _showInstantMashText;
        private int _instantMashFramesAvailable;

        private bool _launchedFromCountdown;
        private TimeSpan _timeTillNextCard;
        private TimeSpan _timeTillNextCardEnd;
        private string _countdownText;

        public ICommand SubmitCommand { get; }
        public ICommand CountdownCommand { get; }


        public BaseCardManipulationModel(CardManip manip, uint state, string player, int delayFrames, int? rngModifier)
        {
            _manip = manip;
            State = Math.Max(state, 1);

            // Map known EQ states
            switch (state)
            {
                case 1: State = 0x1de5_b942; break;
                case 2: State = 0x963c_b5e4; break;
                case 3: State = 0x1f13_2481; break;
                default: break; // Already hex
            }

            _player = player;
            Count = rngModifier ?? 0;

            SubmitCommand = new RelayCommand(Submit);
            CountdownCommand = new RelayCommand(async () => await LaunchCountdownAsync());

            manip.Options.DelayFrame = delayFrames;

            // Initial UI text based on counting vs first-game
            if (Count > 0)
            {
                Explanation = "Confirm to start timer";
                ShowInstantMashText = true;
            }
            else
            {
                Explanation = "Mash first game and input cards";
                ShowInstantMashText = false;
            }

            CountdownText = "Start Countdown";

            // Precompute instant mash info
            GetInstantMashText();
        }

        // Platform should call this on each render tick with the current rendering time.
        public void OnRenderTick(TimeSpan renderingTime)
        {
            if (CurrentResult == null) return;

            var deltaTime = renderingTime - _lastRenderTime;
            _lastRenderTime = renderingTime;

            RareCardAvailable = CurrentResult.RareTable[0];
            RareCardSoon = !CurrentResult.RareTable[0] && CurrentResult.RareTable.Take(10).Any(t => t);
            Snake = string.Join("", CurrentResult.RareTable.Select(t => t ? "*" : "-"));
            TimeElapsedSeconds = (decimal)CurrentResult.DurationSeconds;

            if (RareCardAvailable) TextColor = Color.Green;
            else if (RareCardSoon) TextColor = Color.Orange;
            else TextColor = Color.White;

            if (RareCardAvailable)
            {
                RareCardTimer = "NOW";
            }
            else
            {
                int framesTillAvailable = 0;
                int framesTillAvailableEnd = 0;
                for (int i = 0; i < CurrentResult.RareTable.Count; i++)
                {
                    if (CurrentResult.RareTable[i])
                    {
                        framesTillAvailable = i;
                        break;
                    }
                }

                for (int i = framesTillAvailable; i < CurrentResult.RareTable.Count; i++)
                {
                    if (!CurrentResult.RareTable[i])
                    {
                        framesTillAvailableEnd = i;
                        break;
                    }
                }

                _timeTillNextCard = TimeSpan.FromSeconds(framesTillAvailable * 0.01666); // 60 FPS
                _timeTillNextCardEnd = TimeSpan.FromSeconds(framesTillAvailableEnd * 0.01666); // 60 FPS
                RareCardTimer = $"{_timeTillNextCard.TotalSeconds:F2}s";

                if (_timeTillNextCard.TotalSeconds >= 1.5 && !_launchedFromCountdown)
                {
                    TryPlayBeeps();
                }
            }
        }

        public uint State { get; private set; }
        public int Count { get; private set; }

        public RareTimerResult CurrentResult { get; private set; }

        public bool ShowInstantMashText
        {
            get => _showInstantMashText;
            private set
            {
                if (_showInstantMashText == value) return;
                _showInstantMashText = value;
                OnPropertyChanged();
            }
        }

        public int FirstAvailableFrame { get; private set; }

        public int InstantMashFramesAvailable
        {
            get => _instantMashFramesAvailable;
            set
            {
                if (_instantMashFramesAvailable == value) return;
                _instantMashFramesAvailable = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(ShowInstantMashFramesAvailableText));
            }
        }

        public bool ShowInstantMashFramesAvailableText => InstantMashFramesAvailable != 0;

        public bool WillBeepsPlay
        {
            get => _willBeepsPlay;
            private set
            {
                if (_willBeepsPlay == value) return;
                _willBeepsPlay = value;
                OnPropertyChanged();
            }
        }

        public Color InstantMashBackgroundColor
        {
            get => _instantMashBackgroundColor;
            private set
            {
                if (_instantMashBackgroundColor == value) return;
                _instantMashBackgroundColor = value;
                OnPropertyChanged();
            }
        }

        public string FirstFrameAvailableFramesDisplay
        {
            get => _firstFrameAvailableFramesDisplay;
            private set
            {
                if (_firstFrameAvailableFramesDisplay == value) return;
                _firstFrameAvailableFramesDisplay = value;
                OnPropertyChanged();
            }
        }

        public bool RareCardAvailable
        {
            get => _rareCardAvailable;
            private set
            {
                if (_rareCardAvailable == value) return;
                _rareCardAvailable = value;
                OnPropertyChanged();
            }
        }

        public bool RareCardSoon
        {
            get => _rareCardSoon;
            private set
            {
                if (_rareCardSoon == value) return;
                _rareCardSoon = value;
                OnPropertyChanged();
            }
        }

        public string Snake
        {
            get => _snake;
            private set
            {
                if (_snake == value) return;
                _snake = value;
                OnPropertyChanged();
            }
        }

        public decimal TimeElapsedSeconds
        {
            get => _timeElapsedSeconds;
            private set
            {
                if (_timeElapsedSeconds == value) return;
                _timeElapsedSeconds = value;
                OnPropertyChanged();
            }
        }

        public Color TextColor
        {
            get => _textColor;
            private set
            {
                if (_textColor == value) return;
                _textColor = value;
                OnPropertyChanged();
            }
        }

        public string RareCardTimer
        {
            get => _rareCardTimer;
            private set
            {
                if (_rareCardTimer == value) return;
                _rareCardTimer = value;
                OnPropertyChanged();
            }
        }

        public string RecoveryPattern
        {
            get => _recoveryPattern;
            set
            {
                if (_recoveryPattern == value) return;
                _recoveryPattern = value;
                OnPropertyChanged();
            }
        }

        public string ErrorText
        {
            get => _errorText;
            private set
            {
                if (_errorText == value) return;
                _errorText = value;
                OnPropertyChanged();
            }
        }

        public string FoundCards
        {
            get => _foundCards;
            private set
            {
                if (_foundCards == value) return;
                _foundCards = value;
                OnPropertyChanged();
            }
        }

        public string Explanation
        {
            get => _explanation;
            private set
            {
                if (_explanation == value) return;
                _explanation = value;
                OnPropertyChanged();
            }
        }

        public string CountdownText
        {
            get => _countdownText;
            private set
            {
                if (_countdownText == value) return;
                _countdownText = value;
                OnPropertyChanged();
            }
        }

        public void UpdateFromResult(RareTimerResult result)
        {
            CurrentResult = result;
        }

        public RareTimerResult GetFirstFrameResult()
        {
            var searchType = SearchType.First;
            if (Count != 0) searchType = SearchType.Counting;
            else if (string.IsNullOrWhiteSpace(RecoveryPattern)) searchType = SearchType.Recovery;

            return _manip.GetRareTimerStep(_lastState ?? State, _player, 0, searchType, count: _lastState == null ? Count : 0);
        }

        public void GetInstantMashText()
        {
            var result = GetFirstFrameResult();

            int firstAvailableFrame = 0;
            for (int i = 0; i < result.RareTable.Count; i++)
            {
                if (result.RareTable[i])
                {
                    firstAvailableFrame = i;
                    var nextFrames = result.RareTable.Skip(i).Take(4);
                    if (nextFrames.All(t => t))
                    {
                        firstAvailableFrame = i;
                        break;
                    }
                }
            }

            FirstAvailableFrame = firstAvailableFrame;

            if (firstAvailableFrame <= 2)
            {
                InstantMashBackgroundColor = Color.DarkRed;
            }
            else if (firstAvailableFrame <= 85)
            {
                InstantMashBackgroundColor = Color.DarkOrange;
            }
            else
            {
                InstantMashBackgroundColor = Color.Transparent;
            }

            if (firstAvailableFrame == 0)
            {
                InstantMashFramesAvailable = result.RareTable.FindIndex(i => !i);
            }
            else if (firstAvailableFrame <= 2)
            {
                InstantMashFramesAvailable = 10;
            }

            FirstFrameAvailableFramesDisplay = $"{(firstAvailableFrame <= 2 ? "YES" : "NO")} = {firstAvailableFrame}";
            WillBeepsPlay = firstAvailableFrame > 85;
        }

        private void StartTimer()
        {
            if (Count == 0 && string.IsNullOrWhiteSpace(RecoveryPattern) && _lastState == null)
            {
                // Waiting for second try; ignore input
                return;
            }

            TimerStarted();

            ErrorText = null;
            Explanation = "Confirm to start timer";
            _cts = new CancellationTokenSource();

            var searchType = SearchType.First;
            if (Count != 0) searchType = SearchType.Counting;
            else if (string.IsNullOrWhiteSpace(RecoveryPattern))
            {
                searchType = SearchType.Recovery;
                GetInstantMashText();
            }

            _ = _manip.RareTimerAsync(
                _lastState ?? State,
                _player,
                searchType,
                currentTimer => UpdateFromResult(currentTimer),
                _cts.Token,
                count: _lastState == null ? Count : 0);
        }

        private async Task LaunchCountdownAsync()
        {
            var now = DateTime.Now;
            var timeToWaitTill = now.AddSeconds(CountdownTimer);

            while (DateTime.Now < timeToWaitTill)
            {
                await Task.Delay(5);
                var span = DateTime.Now - now;
                var timeLeft = CountdownTimer - span.TotalSeconds;
                CountdownText = timeLeft.ToString("##0.00");
            }

            CountdownText = "Start Countdown";
            _launchedFromCountdown = true;
            Submit();
        }

        public abstract int CountdownTimer { get; }

        private void Submit()
        {
            if (_cts?.Token.IsCancellationRequested ?? true)
            {
                if (string.IsNullOrWhiteSpace(RecoveryPattern))
                {
                    StartTimer();
                }
                else
                {
                    var pattern = _manip.ParsePattern(RecoveryPattern, _player);
                    if (pattern.Error == null)
                    {
                        var searchType = (Count == 0 ? SearchType.First : SearchType.Counting);
                        if (_lastState != null)
                        {
                            searchType = SearchType.Recovery;
                        }

                        var results = _manip.SearchOpenings(
                            _lastState ?? State,
                            _player,
                            pattern,
                            false,
                            count: Count,
                            searchType: searchType,
                            elapsedSeconds: CurrentResult?.DurationSeconds ?? 0);

                        if (results.Any())
                        {
                            var result = results[0];
                            _lastState = result.LastState;
                            RecoveryPattern = null;
                            FoundCards = $"Index {result.Index}: {string.Join(", ", result.Cards)}";
                            Explanation = "Pattern found.  Confirm to start timer";
                            ErrorText = null;
                            GetInstantMashText();
                            ShowInstantMashText = true;
                        }
                        else
                        {
                            ErrorText = "No cards found with this pattern";
                            ShowInstantMashText = false;
                        }
                    }
                    else
                    {
                        ErrorText = pattern.Error;
                        ShowInstantMashText = false;
                    }
                }
            }
            else
            {
                _cts.Cancel();
                PauseBeeps();
                TimerStopped();
            }
        }

        public abstract int BeepInterval { get; }

        public abstract int BeepCount { get; }

        public abstract int BeepOffsetFrames { get; }

        private void TryPlayBeeps()
        {
            if (_isPlayingBeeps) return;
            if (_cts?.IsCancellationRequested ?? true) return;

            _isPlayingBeeps = true;
            PlayBeepsCore();
        }

        // Base computes timing; concrete implementations actually play audio.
        private void PlayBeepsCore()
        {
            // Compute offsets; platform implementation should use these to schedule actual beeps.
            int intervalMs = BeepInterval;
            int desiredBeeps = BeepCount;

            int frameOffsetMs = 0;
            if (_player == "zellmama")
            {
                frameOffsetMs = (int)Math.Floor((_timeTillNextCardEnd.TotalMilliseconds - _timeTillNextCard.TotalMilliseconds) / 2.1);
            }
            else
            {
                frameOffsetMs = 32; // ~2 frames
            }

            frameOffsetMs += BeepOffsetFrames * 16; // frames->ms

            int totalBeepDurationMs = intervalMs * (desiredBeeps - 1);
            int delayMs = Math.Max((int)_timeTillNextCard.TotalMilliseconds - totalBeepDurationMs + frameOffsetMs, 0);

            // Delegate to platform-specific implementation. Provide parameters.
            PlayBeeps(new BeepSchedule
            {
                InitialDelayMs = delayMs,
                IntervalMs = intervalMs,
                Count = desiredBeeps,
                OnCompleted = () => _isPlayingBeeps = false
            });
        }

        protected abstract void PlayBeeps(BeepSchedule schedule);
        protected abstract void PauseBeeps();

        public virtual void Dispose()
        {
            _cts?.Dispose();
            GC.SuppressFinalize(this);
        }

        public abstract void TimerStarted();
        public abstract void TimerStopped();
    }

    public sealed class BeepSchedule
    {
        public int InitialDelayMs { get; set; }
        public int IntervalMs { get; set; }
        public int Count { get; set; }
        public Action OnCompleted { get; set; }
    }

    public class RelayCommand : ICommand
    {
        private readonly Action<object> _execute;
        private readonly Func<object, bool> _canExecute;

        public RelayCommand(Action<object> execute, Func<object, bool> canExecute = null)
        {
            _execute = execute ?? throw new ArgumentNullException(nameof(execute));
            _canExecute = canExecute;
        }

        public RelayCommand(Action execute, Func<bool> canExecute = null) : this(_ => execute(), t => canExecute?.Invoke() ?? true)
        {

        }

        public bool CanExecute(object parameter) => _canExecute?.Invoke(parameter) ?? true;
        public void Execute(object parameter) => _execute(parameter);

        public event EventHandler CanExecuteChanged;
        public void RaiseCanExecuteChanged() => CanExecuteChanged?.Invoke(this, EventArgs.Empty);
    }

    public class RelayCommand<T> : RelayCommand
    {
        public RelayCommand(Action<T> execute, Func<object, bool> canExecute = null) : base(t => execute((T)t), canExecute)
        {

        }
    }
}
using CardManipulation;
using CardManipulation.Models;
using FF8Utilities.Entities;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Threading;
using Brushes = System.Windows.Media.Brushes;

namespace FF8Utilities.Models
{
    public class CardManipulationModel : BaseModel, IDisposable
    {
        private bool rareCardAvailable;
        private bool rareCardSoon;
        private string _snake;
        private decimal _timeElapsedSeconds;
        private SolidColorBrush textColor = Brushes.White;
        private TimeSpan _lastRenderTime = TimeSpan.Zero;
        private string _rareCardTimer;
        private string recoveryPattern;
        private CardManip _manip;
        private uint _state;
        private string _player;
        private int _count;        
        private CancellationTokenSource _cts;
        private string _errorText;



        /// <summary>
        /// It is important this is disposed of afterwards as it subscribes to the CompositionTarget.Rendering event
        /// </summary>
        /// <param name="manip"></param>
        /// <param name="state"></param>
        /// <param name="player"></param>
        /// <param name="delayFrames"></param>
        /// <param name="rngModifier"></param>
        public CardManipulationModel(CardManip manip, uint state, string player, int delayFrames, int? rngModifier)
        {            
            _manip = manip;
            _state = state;
            _player = player;
            _count = rngModifier ?? 0;

            SubmitCommand = new Command(() => true, Submit);
            manip.Options.DelayFrame = delayFrames;

            // Model updates need to happen smoothly in the UI Thread, use CompositionTarget for this
            CompositionTarget.Rendering += CompositionTarget_Rendering;

            StartTimer();
        }


        public Command SubmitCommand { get; }

        public Command PauseCommand { get; }

        private void StartTimer()
        {
            if (_count == 0 && string.IsNullOrWhiteSpace(RecoveryPattern))
            {
                ErrorText = "Mash first game and input cards";
            }
            else
            {
                _cts = new CancellationTokenSource();
                SearchType searchType = SearchType.First;
                if (_count != 0) searchType = SearchType.Counting;
                else if (string.IsNullOrWhiteSpace(RecoveryPattern)) searchType = SearchType.Recovery;
                
                _ = _manip.RareTimerAsync(_state, _player, searchType, (currentTimer) => UpdateFromResult(currentTimer), _cts.Token, count: _count);
            }            
        }

        private void Submit(object sender, EventArgs args)
        {
            if (_cts?.Token.IsCancellationRequested ?? true)
            {
                // Already cancelled and they submit, restart!
                if (string.IsNullOrWhiteSpace(RecoveryPattern))
                {
                    // Redo the current timer
                    StartTimer();
                }
                else
                {
                    // Recovery search
                    PatternParseResult pattern = _manip.ParsePattern(RecoveryPattern, _player);
                    if (pattern.Error == null)
                    {
                        List<SearchResult> results = _manip.SearchOpenings(_state, _player, pattern, false, offsetOverride: _currentResult?.Incr, 
                            count: _count, searchType: SearchType.Recovery);
                    }
                }
            }
            else
            {
                _cts.Cancel();
            }
            
        }

        private void Pause(object sender, EventArgs args)
        {
            _cts.Cancel();
        }

        private void CompositionTarget_Rendering(object sender, EventArgs e)
        {
            if (_currentResult == null) return;
            var args = (RenderingEventArgs)e;
            var deltaTime = args.RenderingTime - _lastRenderTime;

            _lastRenderTime = args.RenderingTime;

            // Perform your UI-safe per-frame logic here
            RareCardAvailable = _currentResult.RareTable[0];
            RareCardSoon = !_currentResult.RareTable[0] && _currentResult.RareTable.Take(10).Any(t => t);
            Snake = string.Join("", _currentResult.RareTable.Select(t => t ? "*" : "-"));
            TimeElapsedSeconds = (decimal)_currentResult.DurationSeconds;

            if (RareCardAvailable) TextColor = Brushes.Green;
            else if (RareCardSoon) TextColor = Brushes.Orange;
            else TextColor = Brushes.White;

            if (RareCardAvailable)
            {
                RareCardTimer = "NOW";
            }
            else
            {
                int framesTillAvailable = 0;
                for (int i = 0; i < _currentResult.RareTable.Count; i++)
                {
                    if (_currentResult.RareTable[i])
                    {
                        framesTillAvailable = i;
                        break;
                    }
                }

                TimeSpan timeTillAvailable = TimeSpan.FromSeconds(framesTillAvailable * 0.01666); // Assuming 60 FPS
                RareCardTimer = $"{timeTillAvailable.TotalSeconds:F2}s";
            }
        }

        public bool RareCardAvailable
        {
            get => rareCardAvailable;
            private set
            {
                if (rareCardAvailable == value)
                    return;
                rareCardAvailable = value;
                OnPropertyChanged();
            }
        }
        public bool RareCardSoon
        {
            get => rareCardSoon;
            private set
            {
                if (rareCardSoon == value)
                    return;
                rareCardSoon = value;
                OnPropertyChanged();
            }
        }

        public string Snake
        {
            get => _snake;
            private set
            {
                if (_snake == value)
                    return;
                _snake = value;
                OnPropertyChanged();
            }
        }

        public decimal TimeElapsedSeconds
        {
            get => _timeElapsedSeconds;
            private set
            {
                if (_timeElapsedSeconds == value)
                    return;
                _timeElapsedSeconds = value;
                OnPropertyChanged();
            }
        }

        public SolidColorBrush TextColor
        {
            get => textColor;
            private set
            {
                if (textColor == value)
                    return;
                textColor = value;
                OnPropertyChanged();
            }
        }

        private RareTimerResult _currentResult;

        public void UpdateFromResult(RareTimerResult result)
        {
            _currentResult = result;           
        }

        public void Dispose()
        {
            CompositionTarget.Rendering += CompositionTarget_Rendering;
            GC.SuppressFinalize(this);
        }

        public string RareCardTimer
        {
            get => _rareCardTimer;
            private set
            {
                if (_rareCardTimer == value)
                    return;
                _rareCardTimer = value;
                OnPropertyChanged();
            }
        }

        public string RecoveryPattern
        {
            get => recoveryPattern;
            set
            {
                if (recoveryPattern == value)
                    return;
                recoveryPattern = value;
                OnPropertyChanged();
            }
        }

        public string ErrorText
        {
            get => _errorText;
            private set
            {
                if (_errorText == value)
                    return;
                _errorText = value;
                OnPropertyChanged();
            }
        }
    }
}

using CardManipulation;
using CardManipulation.Models;
using FF8Utilities.Entities;
using FlowTimer;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Media;
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
        private uint? _lastState;
        private string _foundCards;
        private string _explanation;
        private AudioContext _audioContext;
        private BeepSound _loadedBeepSound;
        private byte[] _pcm;


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

            if (_count > 0)
            {
                Explanation = "Confirm to start timer";
            }
            else
            {
                Explanation = "Mash first game and input cards";
            }

            

            _loadedBeepSound = SettingsModel.Instance.BeepSound;
            StartTimer();
        }



        public Command SubmitCommand { get; }

        public Command PauseCommand { get; }

        private void StartTimer()
        {
            if (_count == 0 && string.IsNullOrWhiteSpace(RecoveryPattern) && _lastState == null)
            {
                          
            }
            else
            {
                Explanation = "Confirm to start timer";
                _cts = new CancellationTokenSource();
                SearchType searchType = SearchType.First;
                if (_count != 0) searchType = SearchType.Counting;
                else if (string.IsNullOrWhiteSpace(RecoveryPattern)) searchType = SearchType.Recovery;
                
                _ = _manip.RareTimerAsync(_lastState ?? _state, _player, searchType, (currentTimer) => UpdateFromResult(currentTimer), _cts.Token, count: _count);
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
                        List<SearchResult> results = _manip.SearchOpenings(_state, _player, pattern, false, count: _count, searchType: SearchType.First);
                        if (results.Any())
                        {
                            SearchResult result = results[0];
                            _lastState = result.LastState;
                            RecoveryPattern = null;
                            FoundCards = $"Index: {result.Index}: {string.Join(", ", result.Cards)}";
                            Explanation = "Pattern found.  Confirm to start timer";
                        }
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
            _audioContext?.ClearQueuedAudio();
            _cts.Cancel();
        }


        private Timer _currentlyPlayingTimer;

        private bool _isPlayingBeeps;
        private void PlayBeeps()
        {
            if (_isPlayingBeeps) return;
            _isPlayingBeeps = true;
            if (_loadedBeepSound != SettingsModel.Instance.BeepSound)
            {
                // Reload audio context
                _audioContext?.Destroy();
                _audioContext = null;
            }

            if (_audioContext == null)
            {
                Stream waveStream;
                switch (SettingsModel.Instance.BeepSound)
                {
                    case BeepSound.Ping1: waveStream = Properties.Resources.ping1; break;
                    case BeepSound.Ping2: waveStream = Properties.Resources.ping2; break;
                    case BeepSound.Click: waveStream = Properties.Resources.click1; break;
                    case BeepSound.Clack: waveStream = Properties.Resources.clack; break;
                    default: throw new ArgumentOutOfRangeException(nameof(SettingsModel.Instance.BeepSound), "Unknown beep sound setting");
                }
                using (waveStream)
                {
                    using (MemoryStream memoryStream = new MemoryStream())
                    {
                        waveStream.CopyTo(memoryStream);
                        Wave.LoadWAV(memoryStream.ToArray(), out _pcm, out SDL.SDL_AudioSpec spec);
                        _audioContext = new AudioContext(spec.freq, spec.format, spec.channels);
                    }
                }
            }


            int interval = (int)SettingsModel.Instance.BeepInterval;
            int desiredBeeps = SettingsModel.Instance.BeepCount;
            int maxNaturalInterval = (int)Math.Floor(_timeTillNextCard.TotalMilliseconds / desiredBeeps);

            int frameOffset = 0;
            if (_player == "zellmama")
            {
                // Aim for the middle of the snake as it doesnt matter which frame and this gives maximum chance
                // Slightly less than half to handle user reaction
                frameOffset = (int)Math.Floor((_timeTillNextCardEnd.TotalMilliseconds - _timeTillNextCard.TotalMilliseconds) / 2.1);
            }
            else
            {
                // Aim for the start of the snake, but add 3 frames on for safety
                frameOffset = 32; // Roughly 2 frames
            }

            interval = Math.Min(interval, maxNaturalInterval);

            int totalBeepDuration = interval * (desiredBeeps - 1);
            int delay = Math.Max((int)_timeTillNextCard.TotalMilliseconds - totalBeepDuration + frameOffset, 0);

            int playedBeeps = 0;
            // Play at normal speed
            _currentlyPlayingTimer = new Timer((state) =>
            {
                _audioContext.QueueAudio(_pcm);
                playedBeeps++;
                if (playedBeeps >= desiredBeeps)
                {
                    _currentlyPlayingTimer?.Dispose();
                    return;
                }
            }, null, delay, interval);
        }

        private TimeSpan _timeTillNextCard;
        private TimeSpan _timeTillNextCardEnd;

        private void CompositionTarget_Rendering(object sender, EventArgs e)
        {
            if (_currentResult == null) return;
            var args = (RenderingEventArgs)e;
            var deltaTime = args.RenderingTime - _lastRenderTime;

            _lastRenderTime = args.RenderingTime;

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
                int framesTillAvailableEnd = 0;
                for (int i = 0; i < _currentResult.RareTable.Count; i++)
                {
                    if (_currentResult.RareTable[i])
                    {
                        framesTillAvailable = i;
                        break;
                    }
                }

                for (int i = framesTillAvailable; i < _currentResult.RareTable.Count; i++)
                {
                    if (!_currentResult.RareTable[i])
                    {
                        framesTillAvailableEnd = i;
                        break;
                    }
                }

                _timeTillNextCard = TimeSpan.FromSeconds(framesTillAvailable * 0.01666); // Assuming 60 FPS
                _timeTillNextCardEnd = TimeSpan.FromSeconds(framesTillAvailableEnd * 0.01666); // Assuming 60 FPS
                RareCardTimer = $"{_timeTillNextCard.TotalSeconds:F2}s";
                Debug.WriteLine($"Time till available: {_timeTillNextCard.TotalSeconds:F2}s");
                if (_timeTillNextCard.TotalSeconds > 2.8)
                {
                    _currentlyPlayingTimer?.Dispose();
                    _audioContext?.ClearQueuedAudio();
                    _isPlayingBeeps = false;
                }
                else
                {
                    PlayBeeps();
                }
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

        public string FoundCards
        {
            get => _foundCards;
            private set
            {
                if (_foundCards == value)
                {
                    return;
                }

                _foundCards = value;
                OnPropertyChanged();
            }
        }

        public string Explanation
        {
            get => _explanation;
            private set
            {
                if (_explanation == value)
                {
                    return;
                }

                _explanation = value;
                OnPropertyChanged();
            }
        }
    }
}

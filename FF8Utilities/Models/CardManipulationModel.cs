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
using static System.Windows.Forms.AxHost;
using Brush = System.Windows.Media.Brush;
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
        private Brush _instantMashBackgroundColor;
        private string _firstFrameAvailableFramesDisplay;
        private Timer _currentlyPlayingTimer;
        private bool _isPlayingBeeps;
        private bool _willBeepsPlay;
        private bool _showInstantMashText;
        private int _instantMashFramesAvailable;



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
            
            // Handle early quistis frames that are not hex indexes
            switch (state)
            {

                case 1:
                    _state = 0x1de5_b942;
                    break;
                case 2:
                    _state = 0x963c_b5e4;
                    break;
                case 3:
                    _state = 0x1f13_2481;
                    break;
                default:
                    // Already a hex state
                    break;
            }
            _player = player;
            _count = rngModifier ?? 0;

            SubmitCommand = new Command(() => true, Submit);
            manip.Options.DelayFrame = delayFrames;

            // Model updates need to happen smoothly in the UI Thread, use CompositionTarget for this
            CompositionTarget.Rendering += CompositionTarget_Rendering;

            if (_count > 0)
            {
                Explanation = "Confirm to start timer";
                ShowInstantMashText = true;
            }
            else
            {
                Explanation = "Mash first game and input cards";
                ShowInstantMashText = false;
            }

            

            _loadedBeepSound = SettingsModel.Instance.BeepSound;
            // Get the first item so we can see the instant mash timing
            GetInstantMashText();
        }

        public bool ShowInstantMashText
        {
            get => _showInstantMashText;
            private set
            {
                if (_showInstantMashText == value)
                {
                    return;
                }

                _showInstantMashText = value;
                OnPropertyChanged();
            }
        }

        public RareTimerResult GetFirstFrameResult()
        {
            SearchType searchType = SearchType.First;
            if (_count != 0) searchType = SearchType.Counting;
            else if (string.IsNullOrWhiteSpace(RecoveryPattern)) searchType = SearchType.Recovery;
            return _manip.GetRareTimerStep(_lastState ?? _state, _player, 0, searchType, count: _lastState == null ? _count : 0);
        }


        public void GetInstantMashText()
        {

            RareTimerResult result = GetFirstFrameResult();

            int firstAvailableFrame = 0;
            for (int i = 0; i < result.RareTable.Count; i++)
            {
                if (result.RareTable[i])
                {
                    firstAvailableFrame = i;
                    IEnumerable<bool> nextFrames = result.RareTable.Skip(i).Take(4);
                    if (nextFrames.All(t => t))
                    {
                        // Only allow if there are 4 mashable frames
                        firstAvailableFrame = i;
                        break;
                    }
                }
            }

            FirstAvailableFrame = firstAvailableFrame;
            if (firstAvailableFrame <= 2)
            {
                // Instant Mash
                InstantMashBackgroundColor = Brushes.DarkRed;
            }
            else if (firstAvailableFrame <= 85)
            {
                InstantMashBackgroundColor = Brushes.DarkOrange;
            }
            else
            {
                InstantMashBackgroundColor = Brushes.Transparent;
            }

            if (firstAvailableFrame == 0)
            {
                // Also output how many frames its available for
                InstantMashFramesAvailable = result.RareTable.FindIndex(i => !i);
            }
            else if (firstAvailableFrame <= 2)
            {
                // Not hit yet, so there will always be 10 frames
                InstantMashFramesAvailable = 10;
            }
            FirstFrameAvailableFramesDisplay = $"{(firstAvailableFrame <= 2 ? "YES" : "NO")} = {firstAvailableFrame}";
            WillBeepsPlay = firstAvailableFrame > 85;
        }

        /// <summary>
        /// Do not bind to in UI, does not use INotifyPropertyChanged
        /// </summary>
        public int FirstAvailableFrame { get; set; }

        public int InstantMashFramesAvailable
        {
            get => _instantMashFramesAvailable;
            set
            {
                if (_instantMashFramesAvailable == value)
                    return;
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
                if (_willBeepsPlay == value)
                {
                    return;
                }

                _willBeepsPlay = value;
                OnPropertyChanged();
            }
        }

        public Brush InstantMashBackgroundColor
        {
            get => _instantMashBackgroundColor;
            private set
            {
                if (_instantMashBackgroundColor == value)
                {
                    return;
                }

                _instantMashBackgroundColor = value;
                OnPropertyChanged();
            }
        }

        public string FirstFrameAvailableFramesDisplay
        {
            get => _firstFrameAvailableFramesDisplay;
            private set
            {
                if (_firstFrameAvailableFramesDisplay == value)
                {
                    return;
                }

                _firstFrameAvailableFramesDisplay = value;
                OnPropertyChanged();
            }
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
                // Valid to start
                ErrorText = null;
                Explanation = "Confirm to start timer";
                _cts = new CancellationTokenSource();
                SearchType searchType = SearchType.First;
                if (_count != 0) searchType = SearchType.Counting;
                else if (string.IsNullOrWhiteSpace(RecoveryPattern))
                {
                    searchType = SearchType.Recovery;
                    GetInstantMashText();
                }
                
                _ = _manip.RareTimerAsync(_lastState ?? _state, _player, searchType, (currentTimer) => UpdateFromResult(currentTimer), _cts.Token, count: _lastState == null ? _count : 0);
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
                        SearchType searchType = (_count == 0 ? SearchType.First : SearchType.Counting);
                        if (_lastState != null)
                        {
                            // We are recovering from a 2nd try
                            searchType = SearchType.Recovery;
                        }
                        List<SearchResult> results = _manip.SearchOpenings(_lastState ?? _state, _player, pattern, false, count: _count, 
                            searchType: searchType, 
                            elapsedSeconds: CurrentResult?.DurationSeconds ?? 0);
                        if (results.Any())
                        {
                            SearchResult result = results[0];
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
            }
            
        }

        private void Pause(object sender, EventArgs args)
        {
            _audioContext?.ClearQueuedAudio();
            _cts.Cancel();
        }


        
        private void PlayBeeps()
        {
            if (_isPlayingBeeps) return;
            if (_cts.IsCancellationRequested) return;
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


            int interval = SettingsModel.Instance.BeepInterval;
            int desiredBeeps = SettingsModel.Instance.BeepCount;

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

            frameOffset += SettingsModel.Instance.BeepOffsetFrames * 16; // Convert frames to milliseconds
            
            int totalBeepDuration = interval * (desiredBeeps - 1);
            int delay = Math.Max((int)_timeTillNextCard.TotalMilliseconds - totalBeepDuration + frameOffset, 0);

            if (_timeTillNextCard.TotalSeconds >= 1.5)
            {
                int playedBeeps = 0;
                // Play at normal speed
                _currentlyPlayingTimer = new Timer((state) =>
                {
                    _audioContext.QueueAudio(_pcm);
                    playedBeeps++;
                    if (playedBeeps >= desiredBeeps)
                    {
                        _currentlyPlayingTimer?.Dispose();
                        _isPlayingBeeps = false;
                        return;
                    }
                }, null, delay, interval);
            }            
        }


        private TimeSpan _timeTillNextCard;
        private TimeSpan _timeTillNextCardEnd;

        private void CompositionTarget_Rendering(object sender, EventArgs e)
        {
            if (CurrentResult == null) return;
            var args = (RenderingEventArgs)e;
            var deltaTime = args.RenderingTime - _lastRenderTime;

            _lastRenderTime = args.RenderingTime;

            RareCardAvailable = CurrentResult.RareTable[0];
            RareCardSoon = !CurrentResult.RareTable[0] && CurrentResult.RareTable.Take(10).Any(t => t);
            Snake = string.Join("", CurrentResult.RareTable.Select(t => t ? "*" : "-"));
            TimeElapsedSeconds = (decimal)CurrentResult.DurationSeconds;

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

                _timeTillNextCard = TimeSpan.FromSeconds(framesTillAvailable * 0.01666); // Assuming 60 FPS
                _timeTillNextCardEnd = TimeSpan.FromSeconds(framesTillAvailableEnd * 0.01666); // Assuming 60 FPS
                RareCardTimer = $"{_timeTillNextCard.TotalSeconds:F2}s";
                if (_timeTillNextCard.TotalSeconds >= 1.5)
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

        public RareTimerResult CurrentResult { get; private set; }

        public void UpdateFromResult(RareTimerResult result)
        {
            CurrentResult = result;     
        }

        public void Dispose()
        {
            this._cts?.Dispose();
            CompositionTarget.Rendering -= CompositionTarget_Rendering;
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

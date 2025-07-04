using CardManipulation.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Threading;
using Brushes = System.Windows.Media.Brushes;

namespace FF8Utilities.Models
{
    public class CardManipulationModel : BaseModel
    {
        private bool rareCardAvailable;
        private bool rareCardSoon;
        private string _snake;
        private decimal _timeElapsedSeconds;
        private SolidColorBrush textColor = Brushes.White;
        private TimeSpan _lastRenderTime = TimeSpan.Zero;
        private string _rareCardTimer;
        private string recoveryPattern;


        public CardManipulationModel()
        {
            // Model updates need to happen smoothly in the UI Thread, use CompositionTarget for this
            CompositionTarget.Rendering += CompositionTarget_Rendering;
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
    }
}

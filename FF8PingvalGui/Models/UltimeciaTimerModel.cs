using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using FF8Utilities.Entities;

namespace FF8Utilities.Models
{
    public class UltimeciaTimerModel : BaseModel
    {
        private int _progress;
        private int _count;
        private bool _timerEnabled;
        private Timer _timer;

        public UltimeciaTimerModel()
        {
            TimerCommand = new Command(() => true, TimerCommandLaunch);
            _timer = new Timer((double) 1000 / 30);

            _timer.Elapsed += async (s, e) =>
            {

                Progress++;
                if (Progress >= 15)
                {
                    Progress = 0;
                    Count++;
                }
            };
        }

        private void TimerCommandLaunch(object sender, EventArgs eventArgs)
        {
            // TODO Handle internally instead of launching script
            ////string script = Settings
            //TimerEnabled = !TimerEnabled;
            //if (TimerEnabled) 
            //{ 
            //    _timer.Start();
            //    Count = 0;
            //    Progress = 0;
            //}
            //else _timer.Stop();
        }

        public int Progress
        {
            get => _progress;
            set
            {
                if (value == _progress) return;
                _progress = value;
                OnPropertyChanged();
            }
        }

        public Command TimerCommand { get; }

        public int Count
        {
            get => _count;
            set
            {
                if (value == _count) return;
                _count = value;
                OnPropertyChanged();
            }
        }

        public bool TimerEnabled
        {
            get => _timerEnabled;
            set
            {
                if (value == _timerEnabled) return;
                _timerEnabled = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(ButtonDisplay));
            }
        }

        public string ButtonDisplay => TimerEnabled ? "Stop Timer" : "Start Timer";
    }
}

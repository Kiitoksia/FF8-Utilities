using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FF8PingvalGui.Entities;

namespace FF8PingvalGui.Models
{
    public class ZellCardModel : BaseModel
    {
        private QuistisPattern _pattern = QuistisPattern.Elastoid;
        private int? _rngPattern;

        private ConsoleControl.WPF.ConsoleControl _control;

        public ZellCardModel(ConsoleControl.WPF.ConsoleControl control)
        {
            _control = control;
            LaunchCommand = new Command(() => true, ExecuteMethod);
        }

        private void ExecuteMethod(object sender, EventArgs eventArgs)
        {
            //_control.StartProcess("zellcard.exe", "");
            throw new NotImplementedException();
        }

        public QuistisPattern Pattern
        {
            get
            {
                return _pattern;
            }
            set
            {
                if (value == _pattern) return;
                _pattern = value;
                OnPropertyChanged();
            }
        }

        public int? RngPattern
        {
            get
            {
                return _rngPattern;
            }
            set
            {
                if (value == _rngPattern) return;
                _rngPattern = value;
                OnPropertyChanged();
            }
        }

        public Command LaunchCommand { get; }
    }
}

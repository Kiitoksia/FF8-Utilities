using CardManipulation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FF8Utilities.Models
{
    public class CardManipulationModel : BaseModel
    {
        private bool rareCardAvailable;
        private bool rareCardSoon;
        private string _snake;
        private decimal _timeElapsedSeconds;


        public CardManipulationModel()
        {

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

        public void UpdateFromResult(RareTimerResult result)
        {
            RareCardAvailable = result.RareTable[0];
            RareCardSoon = !result.RareTable[0] && result.RareTable.Any(t => t);
            Snake = string.Join("", result.RareTable.Select(t => t ? "*" : "-"));
            TimeElapsedSeconds = (decimal)result.DurationSeconds;
        }
    }
}

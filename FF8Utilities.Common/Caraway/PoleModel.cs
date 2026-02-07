using CarawayCode.Entities;
using FF8Utilities.Common;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;

namespace FF8Utilities.Common.Caraway
{
    public class PoleModel : BaseModel
    {
        private int? _count;
        private string _description;

        public PoleModel(string description)
        {
            Description = description;
            ClearCount = new RelayCommand(() => Count = null);
        }

        public int? Count
        {
            get
            {
                return _count;
            }
            set
            {
                if (value == _count) return;
                _count = value;

                if (_count < 0) _count = 15;
                if (_count > 15) _count = 0;
                OnPropertyChanged();
            }
        }

        public string Description
        {
            get
            {
                return _description;
            }
            set
            {
                if (value == _description) return;
                _description = value;
                OnPropertyChanged();
            }
        }

        public ICommand ClearCount { get; }

        /// <summary>
        /// Returns null if Count is empty
        /// </summary>
        /// <returns></returns>
        public PoleCount ToPoleCount()
        {
            if (Count == null) return null;
            return new PoleCount(Count.Value);
        }


        /// <summary>
        /// Converts PoleModels into PoleCount entities for interacting with CarawayCode project
        /// </summary>
        public static PoleCount[] ConvertTo(IEnumerable<PoleModel> poles)
        {
            return poles.Where(p => p.Count != null).Select(p => new PoleCount(p.Count.Value)).ToArray();
        }

        public static PoleModel[] Poles = new[]
        {
            new PoleModel("Series 1"),
            new PoleModel("Series 2"),
            new PoleModel("Series 3"),
            new PoleModel("Series 4"),
            new PoleModel("Series 5"),
            new PoleModel("Series 6"),
        };
    }
}

using FF8Utilities.Entities;

namespace FF8Utilities.Models
{
    public class PoleModel : BaseModel
    {
        private int? _count;
        private string _description;

        public PoleModel(string description)
        {
            Description = description;
            ClearCount = new Command(() => true, (s, e) => Count = null);
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

        public Command ClearCount { get; }
    }
}

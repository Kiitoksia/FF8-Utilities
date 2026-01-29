using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FF8Utilities.Common.Cards
{
    public class EncounterAbilityModel : BaseModel
    {
        private int _count;
        private bool isVisible = true;


        public EncounterAbilityModel(string description, int addition, int count = 0)
        {
            Description = description;
            Addition = addition;
            Count = count;
        }

        public string Description { get; }
        public int Addition { get; }

        public int Count
        {
            get => _count; set
            {
                if (_count == value)
                    return;
                _count = value;
                OnPropertyChanged();
            }
        }

        public int Output => Addition * Count;

        public bool IsVisible
        {
            get => isVisible;
            set
            {
                if (isVisible == value)
                    return;
                isVisible = value;
                OnPropertyChanged();
            }
        }
    }
}

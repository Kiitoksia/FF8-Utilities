using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FF8Utilities.Models
{
    public class EncounterAbilityModel : BaseModel
    {
        private int _count;

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
    }
}

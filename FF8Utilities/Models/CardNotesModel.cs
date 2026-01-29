using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FF8Utilities.Common;

namespace FF8Utilities.Models
{
    public class CardNotesModel : BaseModel
    {
        private string _card;
        private string _position;

        public CardNotesModel(Card card, CardPosition position)
        {
            Card = card.GetDescription();
            Position = position.GetDescription();
        }

        public string Card
        {
            get
            {
                return _card;
            }
            set
            {
                if (value == _card) return;
                _card = value;
                OnPropertyChanged();
            }
        }

        public string Position
        {
            get
            {
                return _position;
            }
            set
            {
                if (value == _position) return;
                _position = value;
                OnPropertyChanged();
            }
        }
    }
}

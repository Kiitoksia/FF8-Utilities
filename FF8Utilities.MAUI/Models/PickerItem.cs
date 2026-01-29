using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FF8Utilities.MAUI.Models
{
    public class PickerItem
    {
        public PickerItem()
        {

        }

        public PickerItem(string display, object value)
        {
            Display = display;
            Value = value;
        }

        public string Display { get; set; }

        public object Value { get; set; }
    }
}

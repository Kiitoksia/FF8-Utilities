using System;
using System.Collections.Generic;
using System.Text;

namespace FF8Utilities.Common.Cards
{
    public class QuistisPattern
    {
        public QuistisPattern(string display, uint result)
        {
            Display = display;
            Result = result;
        }

        public string Display { get; }
        public uint Result { get; }
    }
}

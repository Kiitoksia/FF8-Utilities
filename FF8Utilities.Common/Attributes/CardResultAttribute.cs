using System;
using System.Collections.Generic;
using System.Text;

namespace FF8Utilities.Common
{
    public class CardResultAttribute : Attribute
    {
        public CardResultAttribute(uint result)
        {
            Result = result;
        }

        public uint Result { get; }
    }
}

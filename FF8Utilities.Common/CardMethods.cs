using System;
using System.Collections.Generic;
using System.Text;

namespace FF8Utilities.Common
{
    public static class CardMethods
    {
        public static uint GetCardResult(this QuistisPattern pattern)
        {
            return (uint)EnumMethods.GetAttribute(pattern, typeof(CardResultAttribute));
        }
    }
}

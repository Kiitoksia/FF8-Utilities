using System;

namespace ff8_card_manip
{
    public static class DateTimeExtensions
    {
        public static double SecondsSinceEpoch(this DateTime d)
        {
            return (d - new DateTime(1970, 1, 1, 0, 0, 0)).TotalSeconds;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardManipulation
{
    public static class DateTimeExtensions
    {
        public static double SecondsSinceEpoch(this DateTime d)
        {
            return (d - new DateTime(1970, 1, 1, 0, 0, 0)).TotalSeconds;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZellCardManip
{
    public enum Element
    {
        None,
        Thunder,
        Earth,
        Fire,
        Ice,
        Poison,
        Wind,
        Water,
        Holy
    }

    [Flags]
    public enum QuistisPattern
    {
        Elastoid = 1,
        Malboro = 2,
        Wedge = 3
    }

    public enum SearchType
    {
        First,
        Counting,
        Recovery
    }
}

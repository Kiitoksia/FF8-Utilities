using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarawayCode.Entities
{
    [DebuggerDisplay("{" + nameof(Count) + "}")]
    public class PoleCount
    {
        public PoleCount(int count)
        {
            Count = count;
        }
        public int Count { get; }
    }
}

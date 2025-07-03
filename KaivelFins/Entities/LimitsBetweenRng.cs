using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KaivelFins.Entities
{
    public class LimitsBetweenRng
    {
        public LimitsBetweenRng(int limits, int refreshesToLastLimit)
        {
            Limits = limits;
            RefreshesToLastLimit = refreshesToLastLimit;
        }

        public int Limits { get; }

        public int RefreshesToLastLimit { get; }
    }
}

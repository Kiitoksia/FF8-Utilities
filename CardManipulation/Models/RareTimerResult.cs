using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardManipulation.Models
{
    public class RareTimerResult
    {
        public int Incr { get; set; }
        public List<bool> RareTable { get; set; }
        public double DurationSeconds { get; set; }
    }
}

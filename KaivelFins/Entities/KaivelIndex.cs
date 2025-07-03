
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KaivelFins.Entities
{
    public class KaivelIndex
    {
        public KaivelIndex()
        {

        }

        internal KaivelIndex(string error)
        {
            Fish1Sequence = error;
        }

        public int Index { get; internal set; }
        public string Pattern { get; internal set; }
        public string Fish1Sequence { get; internal set; }
        public string Fish1Refreshes { get; internal set; }
        public int Fish1HP { get; internal set; }
        public int Fish1Drop { get; internal set; }

        public int Fish1Limits { get; internal set; }
        public int Fish1RefreshesToLastLimit { get; internal set; }

        public bool Wait { get; internal set; }
    }
}

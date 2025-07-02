using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CardManipulation
{
    public class CardManip
    {
        public void Search(CancellationToken cancellationToken)
        {
            Player player = PlayerTable.Get("zellmama");
        }
    }
}

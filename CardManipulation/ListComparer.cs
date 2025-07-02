using System.Collections.Generic;
using System.Linq;

namespace CardManipulation
{
    class ListComparer : IComparer<IList<int>>
    {
        public int Compare(IList<int> a, IList<int> b)
        {
            if (a.Count == 0 && b.Count == 0)
            {
                return 0;
            }
            else if (a.Count == 0)
            {
                return -1;
            }
            else if (b.Count == 0)
            {
                return 1;
            }
            else if (a[0] == b[0])
            {
                return Compare(a.Skip(1).ToList(), b.Skip(1).ToList());
            }
            else if (a[0] < b[0])
            {
                return -1;
            }
            else
            {
                return 1;
            }
        }
    }
}

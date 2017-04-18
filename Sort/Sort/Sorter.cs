using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sort
{
    public class Sorter
    {
        private readonly IIntSorter _intSorter;

        public Sorter(IIntSorter intSorter)
        {
            _intSorter = intSorter;
        }

        public List<int> Sort(List<int> list)
        {
            return _intSorter.Sort(list, 0, list.Count - 1);
        }
    }
}

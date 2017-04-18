using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sort
{
    public interface IIntSorter
    {
        List<int> Sort(List<int> list, int left, int right);
    }
}

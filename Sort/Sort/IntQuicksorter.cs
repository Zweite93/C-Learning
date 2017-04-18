using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sort
{
    public class IntQuicksorter : IIntSorter
    {
        public List<int> Sort(List<int> list)
        {
            return Quicksort(list, 0, list.Count - 1);
        }

        private List<int> Quicksort(List<int> list, int left, int right)
        {
            if (left >= right)
                return list;

            int temp;

            int i = left;
            int j = right;

            var pivot = list[left + (right - left) / 2];

            while (i <= j)
            {
                while (list[i] < pivot)
                    i++;
                while (list[j] > pivot)
                    j--;
                if (i <= j)
                {
                    temp = list[i];
                    list[i] = list[j];
                    list[j] = temp;
                    i++;
                    j--;
                }
            }
            if (i < right)
                Quicksort(list, i, right);
            if (left < j)
                Quicksort(list, left, j);
            return list;
        }
    }
}

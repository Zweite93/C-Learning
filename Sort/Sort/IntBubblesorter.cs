using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sort
{
    public class IntBubblesorter : IIntSorter
    {
        public List<int> Sort(List<int> list)
        {
            return Bubblesort(list);
        }

        private List<int> Bubblesort(List<int> list)
        {
            if (list.Count == 0)
                return list;

            int temp;

            for (int i = 0; i < list.Count; i++)
                for (int j = 0; j < list.Count; j++)
                    if (list[i] < list[j])
                    {
                        temp = list[i];
                        list[i] = list[j];
                        list[j] = temp;
                    }
            return list;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sort
{
    class Program
    {
        static void Main(string[] args)
        {
            MyList<int> list = new MyList<int>();
            list.Add(4);
            list.Add(1);
            list.Add(3);
            list.Add(2);
            list.Add(-1);
            list.Add(3);

            list.Display();
        }
    }

    class MyList<T> where T : IComparable<T>
    {
        private List<T> _list;

        public MyList()
        {
            _list = new List<T>();
        }

        public void Add(T value)
        {
            int index = (_list.FindLastIndex(r => r.CompareTo(value) <= 0));
            index++;
            _list.Insert(index, value);
        }

        public void Display()
        {
            foreach (var item in _list)
            {
                Console.WriteLine(item);
            }
        }
    }
}

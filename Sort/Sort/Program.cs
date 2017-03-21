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
            MyList list = new MyList();
            list.Add(4);
            list.Add(1);
            list.Add(3);
            list.Add(2);
            list.Add(-1);

            list.Display();
        }
    }

    class MyList
    {
        private List<int> _list;

        public MyList()
        {
            _list = new List<int>();
        }

        public void Add(int value)
        {
            int index = (_list.FindLastIndex(r => r <= value));
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

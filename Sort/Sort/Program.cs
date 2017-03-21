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
            UseList();
        }

        static void UseList()
        {
            var list = new MyList<MyClass>();
            var rand = new Random();
            for (int i = 0; i < 10; i++)
                list.Add(new MyClass() { Value = rand.Next(-100, 100) });

            list.Display();
        }
    }

    class MyList<T> where T : IComparable<T>
    {
        private List<T> _list;
        const int firstItem = 0;

        public MyList()
        {
            _list = new List<T>();
        }

        public void Add(T value)
        {
            if (_list.Count == 0)
            {
                _list.Add(value);
                return;
            }

            if (_list[_list.Count - 1].CompareTo(value) <= 0)
            {
                _list.Add(value);
                return;
            }

            if (_list[firstItem].CompareTo(value) >= 0)
            {
                _list.Insert(firstItem, value);
                return;
            }

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

    class MyClass : IComparable<MyClass>
    {
        public int Value { get; set; }
        public MyClass()
        {

        }

        public int CompareTo(MyClass other)
        {
            return Value.CompareTo(other.Value);
        }

        public override string ToString()
        {
            return Value.ToString();
        }
    }
}

using System;

namespace lab_6
{
    class IntQueue
    {
        private int[] _arr;
        private int _last = -1;
        private int _first = 0;
        private int _count = 0;
        public IntQueue(int size)
        {
            _arr = new int[size];
        }

        public bool Insert(int value)
        {
            if (IsFull()) 
                return false;

            _last = ++_last % _arr.Length;
            _arr[_last] = value;
            _count++;
            return true;
        }
        public int Remove()
        {
            if (IsEmpty())
                throw new Exception();

            int removed = _arr[_first];
            _first = ++_first % _arr.Length;
            _count--;
            return removed;
        }
        public int Count()
        {
            return _count;
        }
        public bool IsEmpty()
        {
            return Count() == 0;
        }
        public bool IsFull()
        {
            return Count() == _arr.Length;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            IntQueue queue = new IntQueue(5);
            queue.Insert(4);
            queue.Insert(8);
            queue.Insert(2);
            if (queue.Count() == 3)
            {
                Console.WriteLine("OK");
            }
            if (queue.Remove() == 4)
            {
                Console.WriteLine("OK");
            }
            if(queue.Count() == 2)
            {
                Console.WriteLine("OK");
            }
            queue.Insert(7);
            queue.Insert(9);
            queue.Insert(11);
            if (queue.Count() == 5)
            {
                Console.WriteLine("OK");
            }
            Console.WriteLine("IsFull : " + queue.IsFull());
            Console.WriteLine( queue.Remove() == 8);
        }
    }
}

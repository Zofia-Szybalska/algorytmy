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
    class PriorityQueue
    {
        public int[] _arr;
        private int _last = -1;
        public PriorityQueue(int size)
        {
            _arr = new int[size];
        }
        public bool Insert(int value)
        {
            if (IsFull())
                return false;

            _arr[++_last] = value;
            RebuildUp(_last);
            return true;
        }
        private void RebuildUp(int node)
        {
            while (node > 0)
            {
                int parentValue = _arr[Parent(node)];
                int nodeValue = _arr[node];
                if (nodeValue > parentValue)
                {
                    (_arr[Parent(node)], _arr[node]) = (_arr[node], _arr[Parent(node)]);
                    node = Parent(node);
                }
                else
                {
                    break;
                }
            }
        }
        public int Remove()
        {
            if (IsEmpty())
                throw new Exception();

            int removed = _arr[0];
            _arr[0] = _arr[_last--];
            RebuildDown();
            return removed;
        }
        private void RebuildDown()
        {
            int node = 0;
            while (node <= _last)
            {
                int leftChildValue = _arr[Left(node)];
                int rightChildValue = _arr[Right(node)];
                int nodeValue = _arr[node];
                if (nodeValue >= leftChildValue && nodeValue >= rightChildValue)
                    break;

                if (leftChildValue >= rightChildValue)
                {
                    (_arr[node], _arr[Left(node)]) = (_arr[Left(node)], _arr[node]);
                    node = Left(node);
                }
                else
                {
                    (_arr[node], _arr[Right(node)]) = (_arr[Right(node)], _arr[node]);
                    node = Right(node);
                }
            }
        }
        public int Count()
        {
            return _last + 1;
        }
        public bool IsEmpty()
        {
            return Count() == 0;
        }
        public bool IsFull()
        {
            return Count() == _arr.Length;
        }
        private int Parent(int child)
        {
            return (child - 1) / 2;
        }
        private int Left(int parent)
        {
            return parent * 2 + 1;
        }
        private int Right(int parent)
        {
            return parent * 2 + 2;
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
            PriorityQueue priority = new PriorityQueue(5);
            Console.WriteLine("Kolejka prioretytowa");
            priority.Insert(4);
            priority.Insert(8);
            priority.Insert(9);
            priority.Insert(91);
            Console.WriteLine(priority.Remove() == 91);
            Console.WriteLine(priority.Remove() == 9);
            Console.WriteLine(priority.Remove() == 8);
            Console.WriteLine(priority.Remove() == 4);
            Console.WriteLine(priority.Count() == 0);
        }
    }
}

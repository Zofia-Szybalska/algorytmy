using System;
using System.Collections;
using System.Collections.Generic;

namespace lab_9
{
    class Program
    {
        class StringHashTab : IEnumerable<string>
        {
            static readonly int Capacity = 101;
            private List<string>[] _arr = new List<string>[Capacity];
            public bool Add(string value)
            {
                int i = HashCode(value);
                if (Contains(value))
                    return false;
                if (_arr[i] == null)
                {
                    _arr[i] = new List<string>();
                }
                _arr[i].Add(value);
                return true;
            }

            private static int HashCode(string value)
            {
                int hash = Math.Abs(value.GetHashCode() % Capacity);
                //Console.WriteLine(hash);
                return hash;
            }

            public bool Remove(string value)
            {
                int i = HashCode(value);
                if (_arr[i] != null)
                    return _arr[i].Remove(value);
                return false;
            }
            public bool Contains(string value)
            {
                if (_arr[HashCode(value)] == null)
                    return false;
                return _arr[HashCode(value)].Contains(value);
            }

            public IEnumerator<string> GetEnumerator()
            {
                foreach (var l in _arr)
                {
                    if (l != null)
                    {
                        Console.WriteLine("Długość listy: " + l.Count);
                        foreach (var item in l)
                        {
                            yield return item;
                        }
                    }
                }
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                return GetEnumerator();
            }
        }
        static void Main(string[] args)
        {
            StringHashTab tab = new StringHashTab();
            Console.WriteLine(tab.Add("asa"));
            Console.WriteLine(tab.Add("aas"));
            Console.WriteLine(tab.Contains("asa"));
            Console.WriteLine(tab.Remove("asa"));
            Console.WriteLine(tab.Contains("asa"));
            int count = 1000;
            Random random = new Random();
            while (count-- > 0)
            {
                int len = 3 + random.Next(10);
                string str = "";
                for (int i = 0; i < len; i++)
                {
                    str += (char)(random.Next(25) + 'a');
                }
                tab.Add(str);
            }
            foreach (var item in tab)
            {
                Console.WriteLine(item);
            }
        }
    }
}

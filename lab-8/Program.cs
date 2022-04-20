using System;
using System.Diagnostics;

namespace lab_8
{
    class TreeNode<T>
    {
        public T Value { get; set; }
        public TreeNode<T> Left { get; set; }
        public TreeNode<T> Right { get; set; }

    }
    class BinarySearchTree<T> where T : IComparable<T>
    {
        private TreeNode<T> _root;

        public BinarySearchTree(TreeNode<T> root)
        {
            _root = root;
        }
        public bool Contains(T value)
        {
            return Search(_root, value);
        }
        private bool Search(TreeNode<T> root, T value)
        {
            if (root == null)
                return false;

            if (root.Value.Equals(value))
                return true;

            if (root.Value.CompareTo(value) < 0)
                return Search(root.Right, value);
            else
                return Search(root.Left, value);

        }
        public void Insert(T value)
        {
            TreeNode<T> node = _root;
            while(node != null)
            {
                if (node.Value.Equals(value)) 
                    return;

                if (node.Value.CompareTo(value) > 0)
                {
                    if (node.Left == null)
                    {
                        node.Left = new TreeNode<T> { Value = value };
                        return;
                    }
                    node = node.Left; 
                }

                else
                {
                    if (node.Right == null)
                    {
                        node.Right = new TreeNode<T> { Value = value };
                        return;
                    }
                    node = node.Right;
                }
                    
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            TreeNode<int> root = new TreeNode<int> { Value = 10 };
            root.Left = new TreeNode<int> { Value = 5 };
            root.Right = new TreeNode<int> { Value = 15 };
            root.Left.Left = new TreeNode<int> { Value = 3 };
            root.Left.Right = new TreeNode<int> { Value = 7 };
            root.Right.Left = new TreeNode<int> { Value = 12 };
            root.Right.Right = new TreeNode<int> { Value = 18 };
            BinarySearchTree<int> binarySearchTree = new BinarySearchTree<int>(root);
            Console.WriteLine(binarySearchTree.Contains(7));
            Console.WriteLine(binarySearchTree.Contains(11));
            binarySearchTree.Insert(8);
            binarySearchTree.Insert(18);
            binarySearchTree.Insert(11);
            binarySearchTree.Insert(4);
            Console.WriteLine(binarySearchTree.Contains(4));
            Console.WriteLine(binarySearchTree.Contains(11));


            #region przykład
            int[] arr = new int[1000];
            Random random = new Random();
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = random.Next(100);
            }
            Array.Sort(arr);
            int index = Array.BinarySearch(arr, 5);
            Console.WriteLine(index);
            Console.WriteLine(arr[index] + "\n");
            #endregion

            #region zadanie1
            int[] testArr = new int[1000000];
            Random rand = new Random();
            for (int i = 0; i < testArr.Length; i++)
            {
                testArr[i] = rand.Next(1000);
            }
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            for (int i = 0; i < testArr.Length; i++)
            {
                if (testArr[i] == 111) break;
            }
            stopwatch.Stop();
            Console.WriteLine("Czas LinearSearch dla tablicy 1 000 000 elementowej: " + stopwatch.Elapsed + "\n");
            stopwatch.Restart();
            Array.Sort(testArr);
            Array.BinarySearch(testArr, 111);
            stopwatch.Stop();
            Console.WriteLine("Czas BinarySearch dla tablicy 1 000 000 elementowej: " + stopwatch.Elapsed);
            

            testArr = new int[100000];
            for (int i = 0; i < testArr.Length; i++)
            {
                testArr[i] = rand.Next(1000);
            }
            stopwatch.Restart();
            for (int i = 0; i < testArr.Length; i++)
            {
                if (testArr[i] == 111) break;
            }
            stopwatch.Stop();
            stopwatch.Restart();
            Array.Sort(testArr);
            Array.BinarySearch(testArr, 111);
            stopwatch.Stop();
            Console.WriteLine("Czas BinarySearch dla tablicy 100 000 elementowej: " + stopwatch.Elapsed);
            
            Console.WriteLine("Czas LinearSearch dla tablicy 100 000 elementowej: " + stopwatch.Elapsed + "\n");

            testArr = new int[10000];
            for (int i = 0; i < testArr.Length; i++)
            {
                testArr[i] = rand.Next(1000);
            }
            Array.Sort(testArr);
            stopwatch.Restart();
            Array.BinarySearch(testArr, 111);
            stopwatch.Stop();
            Console.WriteLine("Czas BinarySearch dla tablicy 10 000 elementowej: " + stopwatch.Elapsed);
            stopwatch.Restart();
            for (int i = 0; i < testArr.Length; i++)
            {
                if (testArr[i] == 111) break;
            }
            stopwatch.Stop();
            Console.WriteLine("Czas LinearSearch dla tablicy 10 000 elementowej: " + stopwatch.Elapsed + "\n");

            testArr = new int[1000];
            for (int i = 0; i < testArr.Length; i++)
            {
                testArr[i] = rand.Next(1000);
            }
            Array.Sort(testArr);
            stopwatch.Restart();
            Array.BinarySearch(testArr, 111);
            stopwatch.Stop();
            Console.WriteLine("Czas BinarySearch dla tablicy 1000 elementowej: " + stopwatch.Elapsed);
            stopwatch.Restart();
            for (int i = 0; i < testArr.Length; i++)
            {
                if (testArr[i] == 111) break;
            }
            stopwatch.Stop();
            Console.WriteLine("Czas LinearSearch dla tablicy 1000 elementowej: " + stopwatch.Elapsed + "\n");

            testArr = new int[100];
            for (int i = 0; i < testArr.Length; i++)
            {
                testArr[i] = rand.Next(1000);
            }
            Array.Sort(testArr);
            stopwatch.Restart();
            Array.BinarySearch(testArr, 111);
            stopwatch.Stop();
            Console.WriteLine("Czas BinarySearch dla tablicy 100 elementowej: " + stopwatch.Elapsed);
            stopwatch.Restart();
            for (int i = 0; i < testArr.Length; i++)
            {
                if (testArr[i] == 111) break;
            }
            stopwatch.Stop();
            Console.WriteLine("Czas LinearSearch dla tablicy 100 elementowej: " + stopwatch.Elapsed);
            #endregion
        }
    }
}

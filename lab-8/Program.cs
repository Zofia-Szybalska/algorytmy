using System;

namespace lab_8
{
    class TreeNode<T>
    {
        public T Value { get; set; }
        public TreeNode<T> Left { get; set; }
        public TreeNode<T> Right { get; set; }

    }
    class BinarySearchTree<T>
    {
        private TreeNode<T> _root;
    }
    class Program
    {
        static void Main(string[] args)
        {
            TreeNode<int> root = new TreeNode<int> { Value = 10 };
            root.Left = new TreeNode<int> { Value = 5 };
            root.Right = new TreeNode<int> { Value = 15 };

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
            Console.WriteLine(arr[index]);
            #endregion
        }
    }
}

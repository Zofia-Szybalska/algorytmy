using System;
using System.Collections;
using System.Collections.Generic;

namespace lab_10
{
    class Node<T>
    {
        public T Value { get; set; }
        public Node<T> Left { get; set; }
        public Node<T> Right { get; set; }
        //public List<Node<T>> Children { get; set; }

    }
    class BinaryTree<T>
    {
        public Node<T> Root { get; set; }
        public static BinaryTree<T> Build(T[] array)
        {
            return new BinaryTree<T>() { Root = BuildRecursive(array, 0) };
        }
        private static Node<T> BuildRecursive(T[] array, int index)
        {
            var node = new Node<T>() { Value = array[index] };
            if (Left(index) < array.Length)
            {
                node.Left = BuildRecursive(array, Left(index));
            }
            if(Right(index) < array.Length)
            {
                node.Right = BuildRecursive(array, Right(index));
            }
            return node;
        }
        public void PreorderTraversal(Action<Node<T>> action)
        {
            PreorderTraversalRecursive(Root, action);
        }
        private void PreorderTraversalRecursive(Node<T> node, Action<Node<T>> action)
        {
            if (node == null)
                return;
            action.Invoke(node);
            PreorderTraversalRecursive(node.Left, action);
            PreorderTraversalRecursive(node.Right, action);
        }
        public void PostorderTraversal(Action<Node<T>> action)
        {
            PostorderTraversalRecursive(Root, action);
        }
        private void PostorderTraversalRecursive(Node<T> node, Action<Node<T>> action)
        {
            if (node == null)
                return;
            PostorderTraversalRecursive(node.Left, action);
            PostorderTraversalRecursive(node.Right, action);
            action.Invoke(node);
        }
        private static int Left(int index)
        {
            return index * 2 + 1;
        }
        private static int Right(int index)
        {
            return index * 2 + 2;
        }
        public void LevelTraversal(Action<Node<T>> action)
        {
            Queue<Node<T>> queue = new Queue<Node<T>>();
            queue.Enqueue(Root);
            while (queue.Count > 0)
            {
                var node = queue.Dequeue();
                action.Invoke(node);

                if (node.Left != null)
                    queue.Enqueue(node.Left);
                if(node.Right != null)
                    queue.Enqueue(node.Right);
            }
        }
        public List<T[]> GetPaths()
        {
            List<T[]> paths = new List<T[]>();
            Stack<T> stack = new Stack<T>();
            GetPathsRecursive(Root, stack, paths);
            return paths;
        }
        private void GetPathsRecursive(Node<T> node, Stack<T> stack, List<T[]> patchs)
        {
            if(node == null)
            {
                return;
            }
            stack.Push(node.Value);
            if(node.Left == null && node.Right == null)
            {
                patchs.Add(stack.ToArray());
                stack.Pop();
                return;
            }
            GetPathsRecursive(node.Left, stack, patchs);
            GetPathsRecursive(node.Right, stack, patchs);
            stack.Pop();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = { 1, 3, 6, 8, 9, 10 };
            var tree = BinaryTree<int>.Build(arr);
            Console.WriteLine("         " + tree.Root.Value);
            Console.Write("   " + tree.Root.Left.Value);
            Console.WriteLine("          " + tree.Root.Right.Value);
            int sum = 0;
            tree.PreorderTraversal(n => sum += n.Value);
            Console.WriteLine(sum);
            tree.PreorderTraversal(n => Console.Write(n.Value + " "));
            Console.WriteLine();
            tree.PostorderTraversal(n => Console.Write(n.Value + " "));
            Console.WriteLine();
            tree.LevelTraversal(n => Console.Write(n.Value + " "));
            foreach (var item in tree.GetPaths()) {
                Console.Write(item);
            };
        }
    }
}

using System;
using System.Collections.Generic;

namespace lab_7
{
    class Queue<T>
    {
        private Node<T> _head;
        private Node<T> _tail;
        public void Insert(T value)
        {
            _tail.Next = new Node<T> { Value = value };
            _tail = _tail.Next;
        }
        public T Remove()
        {
            if (IsEmpty())
                throw new Exception("Queue is empty");
            T result = _head.Value;
            _head = _head.Next;
            return result;
        }
        public bool IsEmpty()
        {
            return _head == null;
        }
    }
    class Stack<T>
    {
        private Node<T> _head;
        public void Push(T value)
        {
            Node<T> node = new Node<T> {Value = value};
            node.Next = _head;
            _head = node;
        }
        public T Pop()
        {
            if (IsEmpty()) 
                throw new Exception("Stack is empty");
            T result = _head.Value;
            _head = _head.Next;
            return result;
        }
        public bool IsEmpty()
        {
            return _head == null;
        }
        #region Zadanie2
        public void Reverse()
        {
            Stack<T> reversedStack = new Stack<T>();
            Node<T> node = _head;
            while (node != null)
            {
                reversedStack.Push(node.Value);
                node = node.Next;
            }
        }
        #endregion
    }
    class Node<T>
    {
        public T Value { get; set; }
        public Node<T> Next { get; set; }
    }
    #region Zadanie1
    class LinkedStack<T>
    {
        private LinkedList<T> _list = new LinkedList<T>();
        public void Push(T value)
        {
            _list.AddLast(value);
        }
        public T Pop()
        {
            if (IsEmpty()) throw new Exception("Stack is empty.");
            T result =_list.Last.Value;
            _list.RemoveLast();
            return result;
        }
        public bool IsEmpty()
        {
            return _list.Count == 0;
        }
    }
    class LinkedQueue<T>
    {
        private LinkedList<T> _list = new LinkedList<T>();
        public void Insert(T value)
        {
            _list.AddFirst(value);
        }
        public T Remove()
        {
            if (IsEmpty())
                throw new Exception("Queue is empty");
            T result = _list.Last.Value;
            _list.RemoveLast();
            return result;
        }
        public bool IsEmpty()
        {
            return _list.Count == 0;
        }
    }
    #endregion
    class Program
    {
        static void Main(string[] args)
        {
            /*Node<string> node = new Node<string> { Value = "adam"};
            node.Next = new Node<string> { Value = "ewa" };
            node.Next.Next = new Node<string> { Value = "karol" };
            Node<string> head = node;
            while (node != null)
            {
                Console.WriteLine(node.Value);
                node = node.Next;
            }
            Stack<int> stack = new Stack<int>();
            stack.Push(3);
            stack.Push(11);
            stack.Push(30);
            stack.Push(9);
            stack.Push(37);
            while (!stack.IsEmpty())
            {
                Console.WriteLine(stack.Pop());
            }*/
            Console.WriteLine(Zadanie4("[(2 + 5)*(3n - 8)] - {[(2n -9)*(3 + 6)]}"));
            Console.WriteLine(Zadanie4("([(2 + 5)*(3n - 8)] - {[(2n -9)*(3 + 6)]}"));
            Console.WriteLine(Zadanie4("([(2 + 5)*(3n - 8)] - {[(2n -9)*(3 + 6)])}"));
            Console.WriteLine(Zadanie4("([(2 + 5)*(3n - 8)] - {[(2n -9)*(3 + 6)])"));
        }
        static bool Zadanie4(string sentenceToCheck)
        {
            Stack<char> bracketsStack = new Stack<char>();
            for (int i = 0; i < sentenceToCheck.Length; i++)
            {
                if (sentenceToCheck[i] == '{' || sentenceToCheck[i] == '[' || sentenceToCheck[i] == '(')
                {
                    bracketsStack.Push(sentenceToCheck[i]);
                }
                else if (sentenceToCheck[i] == '}')
                {
                    if (bracketsStack.IsEmpty() || bracketsStack.Pop() != '{')
                    {
                        return false;
                    }
                }
                else if (sentenceToCheck[i] == ']')
                {
                    if (bracketsStack.IsEmpty() || bracketsStack.Pop() != '[')
                    {
                        return false;
                    }
                }
                else if (sentenceToCheck[i] == ')')
                {
                    if (bracketsStack.IsEmpty() || bracketsStack.Pop() != '(')
                    {
                        return false;
                    }
                }
            }
            return bracketsStack.IsEmpty();
        }
    }
    
}

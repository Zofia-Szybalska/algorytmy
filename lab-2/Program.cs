using System;

namespace lab_2
{
    class Program
    {
        static void Main(string[] args)
        {
            //var result = silnia(5);
            //Console.WriteLine("KONIEC " + result);
            int[] test1 = new int[] { 0,6,4,8,2,-1,5,7};
            //Console.WriteLine(arraySum(test1,0,0));
            int[] test2 = new int[] { 0, 6, 4, 8, 2, 6, 5, 7 };
            Console.WriteLine(zadanie2(test2,6,0,0));
            //FizzBuzz(18,1,1);
            //Console.WriteLine(max(test2,0,test2.Length-1));
        }
        static long silnia(int n)
        {
            if (n == 0)
            {
                return 1;
            }
            Console.WriteLine("n = {0}", n);
            return n * silnia(n-1);
        }
        static long arraySum(int[] arr, int index, long sum)
        {
            if (index == arr.Length)
            {
                return sum;
            }
            sum += arr[index] + arraySum(arr, index + 1, sum);
            return sum;
        }
        static int zadanie2(int[] arr, int element, int index, int count)
        {
            if (index == arr.Length)
            {
                return count;
            }
            if (arr[index] == element)
            {
                count++;
            }
            return zadanie2(arr, element, index + 1, count);

        }
        static int max(int[] arr, int left, int right)
        {
            if (left == right)
            {
                return arr[left];
            }
            int mid = (left + right) / 2;
            int currMax = Math.Max(max(arr, left, mid), max(arr, mid+1, right));
            return currMax;

        }
        static void FizzBuzz(int number, int n, int index)
        {
            if (index == number+1)
            {
                return;
            }
            if (n == 3 || n == 6 || n == 9 || n == 12)
            {
                Console.WriteLine("Fizz");
                FizzBuzz(number, n+1, index+1);
            }
            else if (n == 5 || n == 10)
            {
                Console.WriteLine("Buzz");
                FizzBuzz(number, n + 1, index + 1);
            }
            else if (n == 15)
            {
                Console.WriteLine("FizzBuzz");
                FizzBuzz(number, 1, index + 1);
            }
            else
            {
                Console.WriteLine(index);
                FizzBuzz(number, n + 1, index + 1);
            }
        }
        static int zadanie4(int S, int n)
        {
            if (n == 0)
            {
                return S;
            }
            S = (int)Math.Round((0.5)*((zadanie4(S, n - 1) + (S / zadanie4(S, n - 1)))));
            return S;
        }
    }
}

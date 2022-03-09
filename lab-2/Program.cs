using System;

namespace lab_2
{
    class Program
    {
        static void Main(string[] args)
        {
            var result = silnia(5);
            Console.WriteLine("KONIEC " + result);
            int[] test1 = new int[] { 0,6,4,8,2,-1,5,7};
            Console.WriteLine(zadanie1(test1,0,0));
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
        static long zadanie1(int[] arr, int index, long sum)
        {
            if (index == arr.Length)
            {
                return sum;
            }
            sum += arr[index] + zadanie1(arr, index + 1, sum);
            return sum;
        }
    }
}

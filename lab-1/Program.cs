using System;
using System.Collections.Generic;

namespace lab_1{
    class Program{
        static void Main(string[] args){
            int[] test1 = new int[] {10, 12, 99, 100, 4 ,-10};
            Console.WriteLine("Zadanie 1: " + zadanie1(test1));
            int[] test2 = new int[] { 1, 234, 2345, 2 };
            Console.WriteLine("Zadanie 2: " + zadanie2(test2,3));
            int[] test3 = new int[] {1, 6, 4, 5 , 0};
            Console.WriteLine("Zadanie 3: " + zadanie3(test3, 2));
            int[] test4 = new int[] { 1, 2, 2, 4, 7,9,10,11,13,15};
            Console.WriteLine("Zadanie 4: " + zadanie4(test4));
            int[] test5 = new int[] { 0, 2, 0, 2, 8, 4};
            Console.WriteLine("Zadanie 5: " + zadanie5(test5));
            int[] test6 = new int[] { 1, 2, 5, 3, 2, 3, 8, 2 };
            Console.WriteLine("Zadanie 6: " + zadanie6(test6));
        }

        static int zadanie1(int[] arr){
            int indeks = -1;
            int min = 100;
            for (int i = 0; i < arr.Length; i++) {
                if (arr[i]/100 == 0 && Math.Abs(arr[i]/10) > 0) {
                    if (min > arr[i]) {
                        min = arr[i];
                        indeks = i;
                    }
                }
            }
            return indeks;
        }

        static int zadanie2(int[] arr, int k) {
            int suma = 0;
            int srednia = 0;
            for (int i = 0; i < arr.Length; i++) {
                srednia += arr[i] / arr.Length;
            }
            int max = (int)Math.Pow(10, k);
            int min = (int)Math.Pow(10, k-1);
            for (int i = 0; i < arr.Length; i++) {
                if (arr[i] / max == 0 && Math.Abs(arr[i] / min) > 0 && arr[i] < srednia) {
                    suma += arr[i];
                }
            }
            return suma;
        }

        static int? zadanie3(int[] arr, int k) {
            int? wynik = null;
            int[] pomocnicza = new int[10000];
            foreach  (int number in arr) {
                pomocnicza[number] = 1;
            }
            int j = 0;
            for (int i = 0; i < pomocnicza.Length;i++) {
                if (pomocnicza[i] == 1) {
                    j++;
                }
                if (j == k) {
                    wynik = i;
                    break;
                }
            }
            return wynik;
        }
        static int zadanie4(int[] arr) {
            int sum = 0;
            int maxLength = 0, q = arr[1] - arr[0], length = 0, currSum = 0;
            for (int i = 0; i < arr.Length; i++) {
                if (( i+1 < arr.Length && arr[i+1] - arr[i] == q) || (0 <= i-1 && arr[i] - arr[i-1] == q)) {
                    currSum += arr[i];
                    length++;
                }
                else if (0 <= i - 1 && arr[i] - arr[i - 1] == arr[i+1] - arr[i]) {
                    q = arr[i] - arr[i - 1];
                    length = 2;
                    currSum = arr[i] + arr[i - 1];
                }
                else if(maxLength < length){
                    maxLength = length;
                    sum = currSum;
                    currSum = 0;
                    length = 0;
                    q = arr[i + 1] - arr[i];
                }
                else {
                    currSum = 0;
                    length = 0;
                    q = arr[i + 1] - arr[i];
                }
            }
            if (maxLength < length) {
                sum = currSum;
            }
            return sum;
        }
        static int zadanie5(int[] arr) {
            int index = -1;
            int sum = 0;
            foreach (int number in arr) {
                sum += number;
            }
            for (int i = 0; i < arr.Length; i++) {
                if (sum - arr[i] == arr[i]) {
                    index = i;
                    break;
                }
            }
            return index;
        }
        static int zadanie6(int[] arr) {
            int max = 0;
            Dictionary<int, int> counter = new Dictionary<int, int>();
            foreach  (int number in arr) {
                if (counter.ContainsKey(number)) {
                    counter[number]++;
                }
                else {
                    counter.Add(number, 1);
                }
            }
            foreach (var item in counter) {
                if (item.Value > max) {
                    max = item.Value;
                }
            }
            return max;
        }
    }
}

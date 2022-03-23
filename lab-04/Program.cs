using System;

namespace lab_04
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] test = new int[] { 2, 9, 8, 5, 6, 1 };
            QuickSort(test, test.Length);
            foreach (var item in test)
            {
                Console.Write(item + ", ");
            }
        }

        static void QuickSort(int[] arr, int arrLength, int arrayBeg = 0)
        {
            if (arrLength <= 1) return;
            int elementOsiowy = arr[arrayBeg];
            int indexPrawy = -1;
            int arrLengthCount = arrLength;
            for (int i = arrayBeg; 0 < arrLengthCount; i++, arrLengthCount--)
            {
                if (arr[i] >= elementOsiowy)
                {
                    if (indexPrawy == -1)
                    {
                        indexPrawy = i;
                    }
                }
                else if (arr[i] < elementOsiowy && indexPrawy != -1)
                {
                    int temp, curr = arr[i];
                    for (int j = indexPrawy; j <= i; j++)
                    {
                        temp = arr[j];
                        arr[j] = curr;
                        curr = temp;
                    }
                    indexPrawy++;
                }
            }
            if (indexPrawy < 1)
            {
                QuickSort(arr, arrLength - 1, arrayBeg + 1);
            }
            else
            {
                int temp2 = arr[0];
                arr[0] = arr[indexPrawy - 1];
                arr[indexPrawy - 1] = temp2;
                QuickSort(arr, indexPrawy, arrayBeg);
                QuickSort(arr, arrLength - indexPrawy, indexPrawy - 1);
            }
        }
    }
}

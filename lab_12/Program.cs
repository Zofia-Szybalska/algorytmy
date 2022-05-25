using System;

namespace lab_12
{
    class Program
    {
        static void Main(string[] args)
        {
            if(Zadanie1("zakaz") == true && Zadanie1("robot") == false && Zadanie1("a") == true)
                Console.WriteLine("Zadanie1 poprawne");
            else
                Console.WriteLine("Zadanie1 niepoprawne");

            if (Zadanie2("abccca").Equals("ccc") && Zadanie2("abcccaddd").Equals("ccc") && Zadanie2("abcd").Equals("a"))
                Console.WriteLine("Zadanie2 poprawne");
            else
                Console.WriteLine("Zadanie2 niepoprawne");

            if(Zadanie3("abc","cab") == true && Zadanie3("abc","caba") != true && Zadanie3("","") == true && Zadanie3("a","a") && Zadanie3("aabbcc","abcabc") && Zadanie3("abc", "adc") != true)
                Console.WriteLine("Zadanie3 poprawne");
            else
                Console.WriteLine("Zadanie3 niepoprawne");
        }
        //czy łańcuch wejściowy jest palindromem
        //input zawsze ma conajmiej jeden znak
        public static bool Zadanie1(string input) {
            for (int i = 0; i < input.Length/2; i++) {
                if (input[i] != input[input.Length - i -1])
                    return false;
            }
            return true;
        }
        //Znajdź i zwróć pierwszy najdłuższy fragment złożony z jednakowych znaków
        //input ma conajmiej jeden znak
        public static string Zadanie2(string input)
        {
            string result = "" + input[0];
            string max = "";
            for (int i = 1; i < input.Length; i++)
            {
                char current = input[i];
                char prev = input[i - 1];
                if (prev == current)
                {
                    result += current;
                }
                else
                {
                    if (max.Length < result.Length)
                        max = result;
                    result = "" + current;
                }
            }
            return max.Length == 0 ? input[0] + "" : max;
        }
        //czy str1 jest anagramem str2
        public static bool Zadanie3(string str1, string str2) {
            if (str1.Length != str2.Length)
                return false;
            var str1array = str1.ToCharArray();
            Array.Sort(str1array);
            var str2array = str2.ToCharArray();
            Array.Sort(str2array);
            for (int i = 0; i < str1array.Length; i++) {
                if (str1array[i] != str2array[i] )
                    return false;
            }
            return true;
        }
    }
}

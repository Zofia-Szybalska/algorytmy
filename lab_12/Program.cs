using System;
using System.Text.RegularExpressions;

namespace lab_12 {
    class Program {
        static void Main(string[] args) {
            if (Zadanie1("zakaz") == true && Zadanie1("robot") == false && Zadanie1("a") == true)
                Console.WriteLine("Zadanie1 poprawne");
            else
                Console.WriteLine("Zadanie1 niepoprawne");

            if (Zadanie2("abccca").Equals("ccc") && Zadanie2("abcccaddd").Equals("ccc") && Zadanie2("abcd").Equals("a"))
                Console.WriteLine("Zadanie2 poprawne");
            else
                Console.WriteLine("Zadanie2 niepoprawne");

            if (Zadanie3("abc", "cab") == true && Zadanie3("abc", "caba") != true && Zadanie3("", "") == true && Zadanie3("a", "a") && Zadanie3("aabbcc", "abcabc") && Zadanie3("abc", "adc") != true)
                Console.WriteLine("Zadanie3 poprawne");
            else
                Console.WriteLine("Zadanie3 niepoprawne");
            if (Zadanie4("10000000000", "1111111111").Equals("11111111111"))
                Console.WriteLine("Zadanie4 poprawne");
            else
                Console.WriteLine("Zadanie4 niepoprawne");
            string test = Zadanie4("10000000000", "1111111111");
            Console.WriteLine(Zadanie5("trzy jej działa jej", 3));
        }

        //czy łańcuch wejściowy jest palindromem
        //input zawsze ma conajmiej jeden znak
        public static bool Zadanie1(string input) {
            for (int i = 0; i < input.Length / 2; i++) {
                if (input[i] != input[input.Length - i - 1])
                    return false;
            }
            return true;
        }

        //Znajdź i zwróć pierwszy najdłuższy fragment złożony z jednakowych znaków
        //input ma conajmiej jeden znak
        public static string Zadanie2(string input) {
            string result = "" + input[0];
            string max = "";
            for (int i = 1; i < input.Length; i++) {
                char current = input[i];
                char prev = input[i - 1];
                if (prev == current) {
                    result += current;
                }
                else {
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
                if (str1array[i] != str2array[i])
                    return false;
            }
            return true;
        }

        //Dodawanie dwóch liczb całkowitych, dodatnich zapianych w łańcuchu
        //Dodawanie w słupku
        public static string Zadanie4(string s1, string s2) {
            string result = "";
            int reszta = 0;
            if (s1.Length != s2.Length) {
                int zeros = Math.Abs(s1.Length - s2.Length);
                string zerosString = "";
                for (int i = zeros; i > 0; i--) {
                    zerosString += "0";
                }
                if (s1.Length < s2.Length) s1 = zerosString + s1;
                else s2 = zerosString + s2;
            }
            for (int i = s1.Length - 1; i > -1; i--) {
                int sum = (s1[i] - '0') + (s2[i]-'0') + reszta;
                if (sum > 10) reszta = 1;
                else reszta = 0;
                result += sum;
            }
            return result;
        }

        //Fromatowanie do łańcuchów o długości nie większej od n
        //Znak nowego wiersza tak, żeby wiersze nie były dłuższe od n
        // dla "abbcd edfg ijkl" n =5
        // abcd \nedfg \nijkl
        //bez łamania słów (dzielenia między wiersze) (jeśli chcesz ambitnie), wyświetlane w nowym wierszy, założenie n wieksze niż długość najdłuższego słowa
        public static string Zadanie5(string input, int n) {

            if (input.Length < n) return input;
            int j = 0;
            for (int i = n; i < input.Length; i+=n+1) 
                input =  input.Substring(0, i) + "\n" + input.Substring(i);
            return input;
        }
    }
}

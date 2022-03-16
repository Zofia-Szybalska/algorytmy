using System;
using System.Collections.Generic;
using System.Linq;

namespace lab_3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
        static int zadanie1(int n)
        {
            int n1 = 1, n2 = 1;
            int wynik = 0;
            if (n <= 2)
            {
                return 1;
            }
            for (int i = 0; i < n; i++)
            {
                wynik += n1 + n2;
                n1 = n2;
                n2 = wynik;
            }
            return wynik;
        }
        class Item
        {
            public int wartosc { get; set; }
            public int liczbaPrzegrodek { get; set; }
        }
        static int zadanie2(Item[] przedmioty, int liczbaPrzegrodekWPlecaku)
        {
            //funkcja nie gotowa
            int suma = 0;
            //int[] wartoscNaPrzegrodke = new int[przedmioty.Length];
            Dictionary<int, int> wartosci = new Dictionary<int, int>();
            //List<int> wartoscNaPrzegrodke = new List<int>();
            for (int i = 0; i < przedmioty.Length; i++)
            {
                wartosci.Add(i, przedmioty[i].wartosc / przedmioty[i].liczbaPrzegrodek);
                //wartoscNaPrzegrodke.Add(przedmioty[i].wartosc / przedmioty[i].liczbaPrzegrodek);
                //wartoscNaPrzegrodke = przedmioty[i].wartosc / przedmioty[i].liczbaPrzegrodek);
            }
            var wartosciPosortowane = wartosci.ToList();
            wartosciPosortowane.Sort((pair1, pair2) => pair1.Value.CompareTo(pair2.Value));
            for (int i = 0; i < przedmioty.Length; i++)
            {
                if (przedmioty[wartosciPosortowane[i].Key].liczbaPrzegrodek < liczbaPrzegrodekWPlecaku)
                {
                    liczbaPrzegrodekWPlecaku -= przedmioty[wartosciPosortowane[i].Key].liczbaPrzegrodek;
                    przedmioty[wartosciPosortowane[i].Key] = null;
                    suma += przedmioty[wartosciPosortowane[i].Key].wartosc;
                }
            }
            if (liczbaPrzegrodekWPlecaku > 0)
            {

            }
            return suma;
        }
        class CasheRegister
        {
            int[] stan { get; set; }
            int[] Payment(int[] income, int amount)
            {
                int[] change = new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0 };
                long sum = income[0] * 1 + income[1] * 2 + income[2] * 5 + income[3] * 10 + income[4] * 20 + income[5] * 50 + income[6] * 100 + income[7] * 200 + income[8] * 500;
                int diff = (int)(sum - amount);
                while (diff > 0)
                {
                    if (diff % 500 == 0)
                    {
                        if (stan[8] < 0 + change[8])
                        {
                            return Array.Empty<int>();
                        }
                        diff -= 500;
                        change[8]++;
                    }
                    else if (diff % 200 == 0)
                    {
                        if (stan[7] < 0 + change[7])
                        {
                            return Array.Empty<int>();
                        }
                        diff -= 200;
                        change[7]++;
                    }
                    else if (diff % 100 == 0)
                    {
                        if (stan[6] < 0 + change[6])
                        {
                            return Array.Empty<int>();
                        }
                        diff -= 100;
                        change[6]++;
                    }
                    else if (diff % 50 == 0)
                    {
                        if (stan[5] < 0 + change[5])
                        {
                            return Array.Empty<int>();
                        }
                        diff -= 50;
                        change[5]++;
                    }
                    else if (diff % 20 == 0)
                    {
                        if (stan[4] < 0 + change[4])
                        {
                            return Array.Empty<int>();
                        }
                        diff -= 20;
                        change[4]++;
                    }
                    else if (diff % 10 == 0)
                    {
                        if (stan[3] < 0 + change[3])
                        {
                            return Array.Empty<int>();
                        }
                        diff -= 10;
                        change[3]++;
                    }
                    else if (diff % 5 == 0)
                    {
                        if (stan[2] < 0 + change[2])
                        {
                            return Array.Empty<int>();
                        }
                        diff -= 5;
                        change[2]++;
                    }
                    else if (diff % 2 == 0)
                    {
                        if (stan[1] < 0 + change[1])
                        {
                            return Array.Empty<int>();
                        }
                        diff -= 2;
                        change[1]++;
                    }
                    else
                    {
                        if (stan[0] < 0 + change[0])
                        {
                            return Array.Empty<int>();
                        }
                        diff -= 1;
                        change[0]++;
                    }
                }
                for (int i = 0; i < stan.Length; i++)
                {
                    stan[i] = stan[i] - change[i] + income[i];
                }
                return change;
            }
        }
        static int[] zadanie5(bool fight, int maxHealth, int currentHealth, int[] inventory){
            int[] wypiteFiolki = new int[inventory.Length];
            int roznica = maxHealth - currentHealth;
            while (roznica > 0)
            {
                if (roznica%100 == 0 && inventory[4] > wypiteFiolki[4])
                {
                    wypiteFiolki[4] += 1;
                    roznica -= 100;
                    if (fight && roznica < 100 && roznica > 50)
                    {
                        roznica = 0;
                        wypiteFiolki[4] += 1;
                    }
                }
                else if (roznica%50 == 0 && inventory[3] > wypiteFiolki[3])
                {
                    wypiteFiolki[3] += 1;
                    roznica -= 50;
                    if (fight && roznica < 50 && roznica > 20)
                    {
                        roznica = 0;
                        wypiteFiolki[3] += 1;
                    }
                }
                else if (roznica % 20 == 0 && inventory[2] > wypiteFiolki[2])
                {
                    wypiteFiolki[2] += 1;
                    roznica -= 20;
                    if (fight && roznica < 20 && roznica > 10)
                    {
                        roznica = 0;
                        wypiteFiolki[2] += 1;
                    }
                }
                else if (roznica % 10 == 0 && inventory[1] > wypiteFiolki[1])
                {
                    wypiteFiolki[1] += 1;
                    roznica -= 10;
                    if (fight && roznica < 10 && roznica > 5)
                    {
                        roznica = 0;
                        wypiteFiolki[1] += 1;
                    }
                }
                else if (roznica % 5 == 0 && inventory[0] > wypiteFiolki[0])
                {
                    wypiteFiolki[0] += 1;
                    roznica -= 5;
                }
                else if (inventory[0] > wypiteFiolki[0])
                {
                    wypiteFiolki[0] += 1;
                    roznica = 0;
                }
                else {
                    break;
                }
            }
            return wypiteFiolki;
        }
    }
}

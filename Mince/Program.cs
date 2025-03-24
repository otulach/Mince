using System;
using System.Collections.Generic;

namespace Mince
{
    class Program
    {
        static void Main(string[] args)
        {
            // Načtení mincí a cílové částky
            int[] mince = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
            int soucet = int.Parse(Console.ReadLine());

            List<List<int>> vysledek = new List<List<int>>();
            // Volání první rekurze
            Pocitej(mince, soucet, new List<int>(), 0, vysledek);

            // Výpis výsledků
            foreach (var radekVysledku in vysledek)
            {
                Console.WriteLine(string.Join(" ", radekVysledku));
            }
        }

        static void Pocitej(int[] listMinci, int Soucet, List<int> Soucasny, int Index, List<List<int>> Vysledek)
        {
            if (Soucet == 0) // Pokud jsme dosáhli cílové částky, uložíme kombinaci
            {
                Vysledek.Add(new List<int>(Soucasny));
                return;
            }

            for (int i = Index; i < listMinci.Length; i++)
            {
                if (listMinci[i] <= Soucet) // Použitelná mince
                {
                    Soucasny.Add(listMinci[i]);
                    Pocitej(listMinci, Soucet - listMinci[i], Soucasny, i, Vysledek);
                    Soucasny.RemoveAt(Soucasny.Count - 1); // Vrácení stavu
                }
            }
        }
    }
}

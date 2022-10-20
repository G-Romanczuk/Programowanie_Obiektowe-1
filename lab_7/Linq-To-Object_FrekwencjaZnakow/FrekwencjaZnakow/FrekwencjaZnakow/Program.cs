using System;
using System.Collections.Generic;
using System.Linq;

namespace FrekwencjaLiter
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            var input = int.Parse(Console.ReadLine());
            string[] zdaniaTabela = new string[input];
            string[] zapytaniaTabela = new string[input];
            for (int i = 0; i < input; i++)
            {
                zdaniaTabela[i] = Console.ReadLine()
                                .Replace("!", "")
                                .Replace("?", "")
                                .Replace(",", "")
                                .Replace(".", "")
                                .Replace("-", "")
                                .Replace(":", "")
                                .Replace(";", "")
                                .Replace("(", "")
                                .Replace(")", "")
                                .Replace("%", "")
                                .Replace("/", "")
                                .Replace("1", "")
                                .Replace("2", "")
                                .Replace("3", "")
                                .Replace("4", "")
                                .Replace("5", "")
                                .Replace("6", "")
                                .Replace("7", "")
                                .Replace("8", "")
                                .Replace("9", "")
                                .Replace("0", "")
                                .Replace("\'", "")
                                .Replace("\"", "")
                                .Replace("\\", "")
                                .Replace(" ", "")
                                .Replace("  ", "")
                                .Replace("   ", "")
                                .ToLower();
                zapytaniaTabela[i] = Console.ReadLine()
                                .ToLower();
            }
           

            for (int i = 0; i < input; i++)
            {
                var zapytanie = zapytaniaTabela[i].Split(' ');
                var iloscSlow = int.Parse(zapytanie[1]);
                var listaLiter = new List<char>();
                listaLiter.AddRange(zdaniaTabela[i]);
                var listaWyniki = listaLiter.GroupBy(x => x).Select(y => new { letter = y.Key, amount = y.Count() }).ToList();

                if (zapytanie.Length < 5)
                    switch (zapytanie[2])
                    {
                        case "byfreq":
                            {
                                if (zapytanie[3] == "asc")
                                    listaWyniki = listaWyniki.OrderBy(x => x.amount).ToList();
                                else if (zapytanie[3] == "desc")
                                    listaWyniki = listaWyniki.OrderByDescending(x => x.amount).ToList();
                            }
                            break;
                        case "byletter":
                            {
                                if (zapytanie[3] == "asc")
                                    listaWyniki = listaWyniki.OrderBy(x => x.letter).ToList();
                                else if (zapytanie[3] == "desc")
                                    listaWyniki = listaWyniki.OrderByDescending(x => x.letter).ToList();
                            }
                            break;
                    }
                else if (zapytanie.Length >= 5)
                    switch (zapytanie[2])
                    {
                        case "byfreq":
                            {
                                if (zapytanie[3] == "asc" && zapytanie[5] == "asc")
                                    listaWyniki = listaWyniki.OrderBy(x => x.amount).ThenBy(y => y.letter).ToList();
                                if (zapytanie[3] == "desc" && zapytanie[5] == "desc")
                                    listaWyniki = listaWyniki.OrderByDescending(x => x.amount).ThenByDescending(y => y.letter).ToList();
                                if (zapytanie[3] == "asc" && zapytanie[5] == "desc")
                                    listaWyniki = listaWyniki.OrderBy(x => x.amount).ThenByDescending(y => y.letter).ToList();
                                if (zapytanie[3] == "desc" && zapytanie[5] == "asc")
                                    listaWyniki = listaWyniki.OrderByDescending(x => x.amount).ThenBy(y => y.letter).ToList();
                            }
                            break;
                        case "byletter":
                            {
                                if (zapytanie[3] == "asc" && zapytanie[5] == "asc")
                                    listaWyniki = listaWyniki.OrderBy(x => x.letter).ThenBy(y => y.amount).ToList();
                                if (zapytanie[3] == "desc" && zapytanie[5] == "desc")
                                    listaWyniki = listaWyniki.OrderByDescending(x => x.letter).ThenByDescending(y => y.amount).ToList();
                                if (zapytanie[3] == "asc" && zapytanie[5] == "desc")
                                    listaWyniki = listaWyniki.OrderBy(x => x.letter).ThenByDescending(y => y.amount).ToList();
                                if (zapytanie[3] == "desc" && zapytanie[5] == "asc")
                                    listaWyniki = listaWyniki.OrderByDescending(x => x.letter).ThenBy(y => y.amount).ToList();
                            }
                            break;
                    }

                var wyniki = listaWyniki.Take(listaWyniki.Count);
                switch(zapytanie[0])
                {
                    case "first":
                        {
                            wyniki = listaWyniki.Take(iloscSlow);
                            
                        }break;
                    case "last":
                        {
                            wyniki = listaWyniki.Skip(listaWyniki.Count - iloscSlow);
                        }
                        break;
                }

                foreach (var wynik in wyniki)
                {
                    Console.WriteLine($"{wynik.letter} {wynik.amount}");
                }

                if (input > i)
                    Console.WriteLine();
            }
        }
    }
}
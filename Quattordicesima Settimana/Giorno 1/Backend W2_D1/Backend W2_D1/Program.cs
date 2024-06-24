using System;
using System.Collections.Generic;

namespace ConsoleAppMenu
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            var vociMenu = new Dictionary<int, (string, decimal)>
            {
                { 1, ("Coca Cola 150 ml", 2.50m) },
                { 2, ("Insalata di pollo", 5.20m) },
                { 3, ("Pizza Margherita", 10.00m) },
                { 4, ("Pizza 4 Formaggi", 12.50m) },
                { 5, ("Pz patatine fritte", 3.50m) },
                { 6, ("Insalata di riso", 8.00m) },
                { 7, ("Frutta di stagione", 5.00m) },
                { 8, ("Pizza fritta", 5.00m) },
                { 9, ("Piadina vegetariana", 6.00m) },
                { 10, ("Panino Hamburger", 7.90m) }
            };

            var elementiSelezionati = new List<(string, decimal)>();
            bool ordinazioneInCorso = true;

            while (ordinazioneInCorso)
            {
                Console.Clear();
                Console.WriteLine("==============MENU==============\n");
                foreach (var voce in vociMenu)
                {
                    Console.WriteLine($"{voce.Key}: {voce.Value.Item1} (€ {voce.Value.Item2})");
                }
                Console.WriteLine("\n11: Stampa conto finale e conferma");
                Console.WriteLine("\n==============MENU==============\n");
                Console.Write("Seleziona un'opzione: ");

                if (int.TryParse(Console.ReadLine(), out int scelta) && scelta >= 1 && scelta <= 11)
                {
                    if (scelta == 11)
                    {
                        ordinazioneInCorso = false;
                        StampaConto(elementiSelezionati);
                    }
                    else
                    {
                        elementiSelezionati.Add(vociMenu[scelta]);
                        Console.WriteLine($"\nHai aggiunto: {vociMenu[scelta].Item1}");
                        Console.WriteLine("Premi un tasto per continuare...");
                        Console.ReadKey();
                    }
                }
                else
                {
                    Console.WriteLine("Selezione non valida. Premi un tasto per continuare...");
                    Console.ReadKey();
                }
            }
        }

        static void StampaConto(List<(string, decimal)> elementi)
        {
            Console.Clear();
            Console.WriteLine("==============CONTO FINALE==============\n");
            decimal totale = 3.00m;
            foreach (var elemento in elementi)
            {
                Console.WriteLine($"{elemento.Item1}:          € {elemento.Item2}");
                totale += elemento.Item2;
            }
            Console.WriteLine("\n========================================");
            Console.WriteLine($"\nServizio al tavolo: € 3.00");
            Console.WriteLine($"Totale: € {totale}\n");
            Console.WriteLine("Grazie per il tuo ordine. Premi un tasto per uscire.");
            Console.ReadKey();
        }
    }
}

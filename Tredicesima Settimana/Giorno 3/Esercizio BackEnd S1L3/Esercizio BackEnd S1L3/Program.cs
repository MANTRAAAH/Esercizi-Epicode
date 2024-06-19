namespace Esercizio_BackEnd_S1L3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ContoCorrente conto = new ContoCorrente();
            conto.AttivaConto(1000);
            conto.Versa(500);
            conto.Preleva(200);
            conto.Preleva(300);
            conto.visualizzaSaldo();


            string[]nomi = {"Mario", "Luigi", "Giovanni", "Paolo", "Francesco", "Sara", "Michela", "Chiara", "Pia", "Lorena"};
            Console.WriteLine("ricerca un nome:");
            string? nomeDaCercare = Console.ReadLine();
            bool trovato = false;
            foreach (string nome in nomi)
            {
                if (nome.Equals(nomeDaCercare,StringComparison.OrdinalIgnoreCase))
                {
                    trovato = true;
                    break;
                }
            } if (trovato)
            {
                Console.WriteLine($"il nome {nomeDaCercare} è stato trovato,premi un tasto per continuare");
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine($"il nome {nomeDaCercare} non è stato trovato,premi un tasto per continuare");
                Console.ReadLine();
            }


            Console.WriteLine("Inserisci dimensione array");
            if (!int.TryParse(Console.ReadLine(), out int input))
            {
                Console.WriteLine("Input non valido. Impostazione del valore di default a 10.");
                input = 10; // Imposta un valore di default o gestisci l'errore come preferisci
            }

            // Console.WriteLine("Inserisci moltiplicazione");
            // int moltiplicazione = int.Parse(Console.ReadLine());

            int[] numeri = new int[input];

            for (int i = 0; i < input; i++)
            {
                numeri[i] = i+1;
            //  numeri[i] = i * moltiplicazione;
                Console.WriteLine(numeri[i]);
            }

             void somma_media(int[] numeri)
            {
                int somma = 0;
                for (int i = 0; i < numeri.Length; i++)
                {
                    somma += numeri[i];
                }
                Console.WriteLine($"La somma è: {somma}; la media è {somma/numeri.Length}.");
            }

            somma_media(numeri);
        }
    }
}

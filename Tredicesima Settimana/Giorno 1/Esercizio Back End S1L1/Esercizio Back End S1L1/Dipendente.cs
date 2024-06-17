using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esercizio_Back_End_S1L1
{
    internal class Dipendente
    {
        public string? Nome { get; set; }
        public string? Cognome { get; set; }
        public string? Ruolo { get; set; }
        public int Età { get; set; }

        public void Lavora()
        {
            Console.WriteLine($"Il dipendente {Nome} {Cognome},di anni {Età}, sta svolgendo il ruolo di {Ruolo}");
        }

        public override string ToString()
        {
            return $"Nome: {Nome}, Cognome: {Cognome}, Ruolo: {Ruolo}, Età: {Età}";
        }
    }
}

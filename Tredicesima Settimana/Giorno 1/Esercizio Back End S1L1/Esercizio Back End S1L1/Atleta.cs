using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esercizio_Back_End_S1L1
{
    internal class Atleta
    {
        public string? Nome { get; set; }
        public string? Sport { get; set; }
        public int Età { get; set; }

        public void Allenamento()
        {
            Console.WriteLine($"L'atleta {Nome},di anni {Età}, si sta allenando per il {Sport}");
        }

        public override string ToString()
        {
            return $"Nome: {Nome}, Sport: {Sport}, Età: {Età}";
        }
    }
}

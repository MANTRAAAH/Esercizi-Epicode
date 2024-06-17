using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esercizio_Back_End_S1L1
{
    internal class Animale
    {
        public string? Nome { get; set; }
        public string? Specie { get; set; }
        public int Età { get; set; }

        public void Mangia()
        {
            Console.WriteLine($"L'animale {Nome},un {Specie},di anni {Età}, sta mangiando");
        }

        public override string ToString()
        {
            return $"Nome: {Nome}, Specie: {Specie}, Età: {Età}";
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esercizio_Back_End_S1L1
{
    internal class Veicolo
    {
        public string? Marca { get; set; }
        public string? Modello { get; set; }
        public string? Colore { get; set; }
        public int Anno { get; set; }

        public void Guida()
            {
            Console.WriteLine($"Il veicolo {Marca} {Modello} di colore {Colore},anno {Anno},è in movimento.");
        }
        public override string ToString()
        {
            return $"Marca: {Marca}, Modello: {Modello},Colore:{Colore}, Anno: {Anno}";
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esercizio_BackEnd_S1L2
{
    internal class Persona
    {
        public string Nome { get; set; }
        public string Cognome { get; set; }
        public int Eta { get; set; }

        public Persona(string nome, string cognome, int eta)
        {
            Nome = nome;
            Cognome = cognome;
            Eta = eta;
        }
        public string GetNome()
        {
            return Nome;
        }
        public string GetCognome()
        {
            return Cognome;
        }
        public int GetEta()
        {
            return Eta;
        }

        public string getDetails()
        {
            return $"Nome: {Nome},Cognome:{Cognome},Età:{Eta}";
        }
    }
}

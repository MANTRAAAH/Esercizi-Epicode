using Esercizio_Back_End_S1L1;
using System;

namespace ConsoleApplication
{
    class Program
    {
        public static void Main(string[] args)
        {
            Atleta calciatore = new Atleta(); //new Atleta{Nome="Sandro",Età=19,Sport="Calcio"};
            calciatore.Età = 19;
            calciatore.Nome = "Sandro";
            calciatore.Sport = "Calcio";

            Dipendente cameriere = new Dipendente(); //new Dipendente{Nome="Michela",Cognome="Rossi",Età=25,Ruolo="Cameriera"};
            cameriere.Nome = "Michela";
            cameriere.Cognome = "Rossi";
            cameriere.Età = 25;
            cameriere.Ruolo = "Cameriera";


            Animale cane = new Animale(); //new Animale{Nome="Fido",Età=5,Specie="Cane"};
            cane.Età = 5;
            cane.Nome = "Fido";
            cane.Specie = "Cane";


            Veicolo auto = new Veicolo(); //new Veicolo{Marca="Fiat",Modello="Panda",Colore="Grigio",Anno=2010};
            auto.Anno = 2010;
            auto.Marca = "Fiat";
            auto.Modello = "Panda";
            auto.Colore= "Grigio";


            Console.WriteLine(calciatore); 
            calciatore.Allenamento();
            Console.WriteLine(cameriere);
            cameriere.Lavora();
            Console.WriteLine(cane);
            cane.Mangia();
            Console.WriteLine(auto);
            auto.Guida();
        }
    }
}

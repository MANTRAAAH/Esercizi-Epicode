using System;
using CvApp.Models;
using System.Collections.Generic;

namespace CVApp
{
    class Program
    {
        static void Main(string[] args)
        {
            cv mioCV = new cv();

           
            Console.WriteLine("Inserisci le tue informazioni personali:");
            Console.Write("Nome: ");
            mioCV.InformazioniPersonali.Nome = Console.ReadLine();
            Console.Write("Cognome: ");
            mioCV.InformazioniPersonali.Cognome = Console.ReadLine();
            Console.Write("Telefono: ");
            mioCV.InformazioniPersonali.Telefono = Console.ReadLine();
            Console.Write("Email: ");
            mioCV.InformazioniPersonali.Email = Console.ReadLine();

           
            Console.WriteLine("\nInserisci gli studi effettuati:");
            bool aggiungiAltriStudi = true;
            while (aggiungiAltriStudi)
            {
                Studi studi = new Studi();
                Console.Write("Qualifica: ");
                studi.Qualifica = Console.ReadLine();
                Console.Write("Istituto: ");
                studi.Istituto = Console.ReadLine();
                Console.Write("Tipo: ");
                studi.Tipo = Console.ReadLine();
                Console.Write("Dal (gg/MM/aaaa): ");
                studi.Dal = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy", null);
                Console.Write("Al (gg/MM/aaaa): ");
                studi.Al = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy", null);

                mioCV.StudiEffettuati.Add(studi);

                Console.Write("Vuoi aggiungere altri studi? (s/n): ");
                aggiungiAltriStudi = Console.ReadLine().ToLower() == "s";
            }

           
            Console.WriteLine("\nInserisci le esperienze lavorative:");
            bool aggiungiAltreEsperienze = true;
            while (aggiungiAltreEsperienze)
            {
                Esperienza esperienza = new Esperienza();
                Console.Write("Azienda: ");
                esperienza.Azienda = Console.ReadLine();
                Console.Write("Job Title: ");
                esperienza.JobTitle = Console.ReadLine();
                Console.Write("Dal (gg/MM/aaaa): ");
                esperienza.Dal = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy", null);
                Console.Write("Al (gg/MM/aaaa): ");
                esperienza.Al = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy", null);
                Console.Write("Descrizione: ");
                esperienza.Descrizione = Console.ReadLine();
                Console.Write("Compiti: ");
                esperienza.Compiti = Console.ReadLine();

                mioCV.Impieghi.Esperienze.Add(esperienza);

                Console.Write("Vuoi aggiungere altre esperienze? (s/n): ");
                aggiungiAltreEsperienze = Console.ReadLine().ToLower() == "s";
            }

            StampaDettagliCVSuSchermo(mioCV);
        }

        static void StampaDettagliCVSuSchermo(cv cv)
        {
            Console.WriteLine("\n=== INFORMAZIONI PERSONALI ===");
            Console.WriteLine($"Nome: {cv.InformazioniPersonali.Nome}");
            Console.WriteLine($"Cognome: {cv.InformazioniPersonali.Cognome}");
            Console.WriteLine($"Telefono: {cv.InformazioniPersonali.Telefono}");
            Console.WriteLine($"Email: {cv.InformazioniPersonali.Email}");
            Console.WriteLine();

            Console.WriteLine("=== STUDI EFFETTUATI ===");
            foreach (var studi in cv.StudiEffettuati)
            {
                Console.WriteLine($"Qualifica: {studi.Qualifica}");
                Console.WriteLine($"Istituto: {studi.Istituto}");
                Console.WriteLine($"Tipo: {studi.Tipo}");
                Console.WriteLine($"Dal: {studi.Dal.ToString("dd/MM/yyyy")} Al: {studi.Al.ToString("dd/MM/yyyy")}");
                Console.WriteLine();
            }

            Console.WriteLine("=== IMPIEGHI ===");
            foreach (var esperienza in cv.Impieghi.Esperienze)
            {
                Console.WriteLine($"Azienda: {esperienza.Azienda}");
                Console.WriteLine($"Job Title: {esperienza.JobTitle}");
                Console.WriteLine($"Dal: {esperienza.Dal.ToString("dd/MM/yyyy")} Al: {esperienza.Al.ToString("dd/MM/yyyy")}");
                Console.WriteLine($"Descrizione: {esperienza.Descrizione}");
                Console.WriteLine($"Compiti: {esperienza.Compiti}");
                Console.WriteLine();
            }
        }
    }
}

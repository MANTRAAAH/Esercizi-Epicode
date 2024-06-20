using System;
using System.Collections.Generic;

namespace Esercizio_BackEnd
{
    public static class Utente
    {
        public static bool isLoggedIn { get; private set; } = false;
        public static string CurrentUsername { get; private set; } 
        public static DateTime? LoginTime { get; private set; }
       
        public static List<(DateTime, string)> AccessHistory { get; private set; } = new List<(DateTime, string)>();

        public static void Login(string username, string password, string confirmPassword)
        {
            if (!string.IsNullOrEmpty(username) && password == confirmPassword)
            {
                isLoggedIn = true;
                CurrentUsername = username; 
                LoginTime = DateTime.Now;
                AccessHistory.Add((LoginTime.Value, username)); 
                Console.WriteLine("Login effettuato con successo");
            }
            else
            {
                Console.WriteLine("Errore: username o password non validi");
            }
        }

        public static void Logout()
        {
            if (isLoggedIn)
            {
                isLoggedIn = false;
                Console.WriteLine("Logout effettuato con successo");
            }
            else
            {
                Console.WriteLine("Nessun utente loggato");
            }
        }

        public static void CheckLoginTime()
        {
            if (isLoggedIn && LoginTime.HasValue)
            {
                Console.WriteLine($"L'utente {CurrentUsername} è loggato dal {LoginTime.Value}");
            }
            else
            {
                Console.WriteLine("Nessun utente loggato");
            }
        }

        public static void CheckAccessHistory()
        {
            if (AccessHistory.Count > 0)
            {
                Console.WriteLine("Storico accessi:");
                foreach (var (accessTime, username) in AccessHistory)
                {
                    Console.WriteLine($"{username}: {accessTime}");
                }
            }
            else
            {
                Console.WriteLine("Nessun accesso effettuato");
            }
        }
    }
}

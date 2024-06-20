namespace Esercizio_BackEnd
{
    class Program
    {
        static void Main(string[] args)
        {
            bool exit = false;
            while (!exit)
            {
                Console.WriteLine("\n===============OPERAZIONI==============\n");
                Console.WriteLine("Scegli l'operazione da effettuare:\n");
                Console.WriteLine("1.: Login\n");
                Console.WriteLine("2.: Logout\n");
                Console.WriteLine("3.: Verifica ora e data di login\n");
                Console.WriteLine("4.: Lista degli accessi\n");
                Console.WriteLine("5.: Esci\n");
                Console.WriteLine("========================================\n");

                switch (Console.ReadLine())
                {
                    case "1":
                        Console.WriteLine("Inserisci username:");
                        var username = Console.ReadLine();
                        Console.WriteLine("Inserisci password:");
                        var password = Console.ReadLine();
                        Console.WriteLine("Conferma password:");
                        var confirmPassword = Console.ReadLine();
                        Utente.Login(username, password, confirmPassword);
                        break;
                    case "2":
                        Utente.Logout();
                        break;
                    case "3":
                        Utente.CheckLoginTime();
                        break;
                    case "4":
                        Utente.CheckAccessHistory();
                        break;
                    case "5":
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Scelta non valida.");
                        break;
                }
            }
        }
    }
}

namespace Esercizio_BackEnd_S1L2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Persona p = new Persona("Mario", "Rossi", 30);


            Console.WriteLine("Nome:" + p.GetNome());
            Console.WriteLine("Cognome:" + p.GetCognome());
            Console.WriteLine("Età:" + p.GetEta());

            Console.WriteLine(p.getDetails());

        }
    }
}

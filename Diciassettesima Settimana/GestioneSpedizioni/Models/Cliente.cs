namespace GestioneSpedizioni.Models
{
    public class Cliente
    {
        public int IDCliente { get; set; }
        public string Nome { get; set; }
        public string Cognome { get; set; }
        // Combinato CodiceFiscale e PartitaIVA in un unico campo per allinearsi con la struttura della tabella
        public string CodiceFiscalePartitaIVA { get; set; }
    }
}

namespace GestioneSpedizioni.Models
{
    public class Spedizione
    {
        public int Id { get; set; }
        public string NumeroSpedizione { get; set; }
        public DateTime DataSpedizione { get; set; }
        public decimal Peso { get; set; }
        public string CittaDestinataria { get; set; }
        public string IndirizzoDestinatario { get; set; }
        public string NominativoDestinatario { get; set; }
        public decimal CostoSpedizione { get; set; }
        public DateTime DataConsegnaPrevista { get; set; }

        // Proprietà di navigazione
        public int ClienteId { get; set; }
        public Cliente Cliente { get; set; }
    }
}

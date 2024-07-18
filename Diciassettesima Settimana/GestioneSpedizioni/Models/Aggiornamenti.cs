namespace GestioneSpedizioni.Models
{
    public class Aggiornamenti
    {
        public int Id { get; set; }
        public string Stato { get; set; }
        public string Luogo { get; set; }
        public string Descrizione { get; set; }
        public DateTime DataOraAggiornamento { get; set; }
        public int SpedizioneId { get; set; }
    }
}

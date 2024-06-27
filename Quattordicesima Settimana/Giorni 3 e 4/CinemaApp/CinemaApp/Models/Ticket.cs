using System.ComponentModel.DataAnnotations;

namespace CinemaApp.Models
{
    public class Ticket
    {
        [Display(Name ="Nome:")]
        public string Nome { get; set; }
        [Display(Name = "Cognome:")]
        public string Cognome { get; set; }
        [Display(Name = "Scegli la sala:")]
        public string Sala { get; set; }
        [Display(Name = "Scegli tipo di biglietto:")]
        public string TipoBiglietto { get; set; }
    }
}

using System.Collections.Generic;

namespace CvApp.Models
{
    class cv
    {
        public InformazioniPersonali InformazioniPersonali { get; set; } = new InformazioniPersonali();
        public List<Studi> StudiEffettuati { get; set; } = new List<Studi>();
        public Impiego Impieghi { get; set; } = new Impiego();
    }
}

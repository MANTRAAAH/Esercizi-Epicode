using Microsoft.AspNetCore.Mvc;
using CvWebApp.Models;

namespace CvWebApp.Controllers
{
    public class CVController : Controller
    {
        public IActionResult Index()
        {
            CV mioCV = new CV
            {
                InformazioniPersonali = new InformazioniPersonali
                {
                    Nome = "Antonio Massimo",
                    Cognome = "Annunziata",
                    Telefono = "3287012###",
                    Email = "ant.annunz@example.com",
                    imgUrl = "https://via.placeholder.com/150"
                },
                StudiEffettuati = new List<Studi>
    {
        new Studi
        {
            Qualifica = "Diploma Alberghiero",
            Istituto = "San Giuseppe",
            Tipo = "Scuola Secondaria",
            Dal = new DateTime(2016, 9, 1),
            Al = new DateTime(2021, 7, 15)
        },
    },
                Impieghi = new List<Impiego>
    {
        new Impiego
        {
            Esperienza = new Esperienza
            {
                Azienda = "Tesj Coffe And Drink",
                JobTitle = "Barman e Cameriere",
                Dal = new DateTime(2021, 8, 1),
                Al = new DateTime(2022, 05, 31),
                Descrizione = "Barman,Banconista e Cameriere",
                Compiti = "Preparazione bevande, servizio al tavolo e al banco"
            }
        },
        new Impiego
        {
            Esperienza = new Esperienza
            {
                Azienda = "Rocce Rosse ",
                JobTitle = "Barman",
                Dal = new DateTime(2022, 06, 1),
                Al =new  DateTime(2022,08,5),
                Descrizione = "Barman di discoteca",
                Compiti = "Preparazione e servizio di bevande alcoliche al banco"
            }
        },
                new Impiego
        {
            Esperienza = new Esperienza
            {
                Azienda = "Revolution DiscoClub",
                JobTitle = "Barman e Cameriere",
                Dal = new DateTime(2022, 08, 15),
                Al = new DateTime(2023,11,16),
                Descrizione = "Barman di discoteca",
                Compiti = "Preparazione e servizio di bevande alcoliche al banco, servizio al tavolo per cerimonie"
            }
        },
                               new Impiego
        {
            Esperienza = new Esperienza
            {
                Azienda = "Re.Ma. Plast SRL",
                JobTitle = "Addetto alla stampa flessografica",
                Dal = new DateTime(2023, 11, 19),
                Al = new DateTime(2024,03,22),
                Descrizione = "Addetto stampa per imballaggi flessibili",
                Compiti = "Controllo qualità stampa, manutenzione macchinari, gestione lavorativa"
            }
        }
    }
            };


            return View(mioCV);
        }
    }
}

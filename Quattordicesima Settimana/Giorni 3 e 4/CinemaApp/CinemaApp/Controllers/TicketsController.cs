using CinemaApp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace CinemaApp.Controllers
{

    public class TicketsController : Controller
    {
        private static List<Ticket> tickets = new List<Ticket>();
        private static Dictionary<string, int> salaCapienza = new Dictionary<string, int>
        {
            { "SALA NORD", 0 },
            { "SALA EST", 0 },
            { "SALA SUD", 0 }
        };
        private static Dictionary<string, int> salaRidotti = new Dictionary<string, int>
        {
            { "SALA NORD", 0 },
            { "SALA EST", 0 },
            { "SALA SUD", 0 }
        };

        private const int maxCapienza = 120;

        public IActionResult Index()
        {
            ViewBag.Tickets = tickets;
            ViewBag.SalaCapienza = salaCapienza;
            ViewBag.SalaRidotti = salaRidotti;
            return View();
        }

        [HttpPost]
        public IActionResult Prenota(Ticket ticket)
        {
            if (salaCapienza[ticket.Sala] < maxCapienza)
            {
                tickets.Add(ticket);
                salaCapienza[ticket.Sala]++;

                if (ticket.TipoBiglietto == "Ridotto")
                {
                    salaRidotti[ticket.Sala]++;
                }
            }
            else
            {
                TempData["Errore"] = "Capienza massima della sala raggiunta.";
            }

            return RedirectToAction("Index");
        }
    }
}


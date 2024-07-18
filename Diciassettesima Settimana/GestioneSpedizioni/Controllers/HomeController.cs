using GestioneSpedizioni.Controllers;
using GestioneSpedizioni.Models;
using GestioneSpedizioni.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace GestioneSpedizioni.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ISpedizioneService _spedizioneService; // Change to ISpedizioneService

        public HomeController(ILogger<HomeController> logger, ISpedizioneService spedizioneService)
        {
            _logger = logger;
            _spedizioneService = spedizioneService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public async Task<IActionResult> Dashboard()
        {
            // Richiamo delle azioni del SpedizioneService per il dashboard
            ViewData["SpedizioniInConsegnaOggi"] = await _spedizioneService.GetSpedizioniInConsegnaOggiAsync();
            ViewData["NumeroSpedizioniInAttesaConsegna"] = await _spedizioneService.GetNumeroSpedizioniInAttesaConsegnaAsync();
            var spedizioniPerCitta = await _spedizioneService.GetSpedizioniPerCittaDestinatariaAsync();
            ViewBag.SpedizioniPerCitta = spedizioniPerCitta;

            return View();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

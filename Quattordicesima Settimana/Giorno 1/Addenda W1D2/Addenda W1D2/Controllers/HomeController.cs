using Addenda_W1D2.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Addenda_W1D2.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            var menu = new Menu();
            menu.AddItem(new MenuItem("Coca Cola 150 ml", 2.50));
            menu.AddItem(new MenuItem("Insalata di pollo", 5.20));
            menu.AddItem(new MenuItem("Pizza Margherita", 10.00));
            menu.AddItem(new MenuItem("Pizza 4 Formaggi", 12.50));
            menu.AddItem(new MenuItem("Pz patatine fritte", 3.50));
            menu.AddItem(new MenuItem("Insalata di riso", 8.00));
            menu.AddItem(new MenuItem("Frutta di stagione", 5.00));
            menu.AddItem(new MenuItem("Pizza fritta", 5.00));
            menu.AddItem(new MenuItem("Piadina vegetariana", 6.00));
            menu.AddItem(new MenuItem("Panino Hamburger", 7.90));

            return View(menu);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

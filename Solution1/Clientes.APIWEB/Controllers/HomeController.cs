using Clientes.APIWEB.Models;
using Clientes.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Clientes.APIWEB.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

       // [BindProperty]
        // public CreacionClienteDTO creacionDTO { get; set; }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Cliente()
        {
            return View();
        }

        public IActionResult GetALL()
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

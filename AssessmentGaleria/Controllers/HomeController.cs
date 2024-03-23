using AssessmentGaleria.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace AssessmentGaleria.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly GaleriaDBContext _context;

        public HomeController(ILogger<HomeController> logger, GaleriaDBContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            var carros = _context.Carros.ToList();

            ViewBag.Carros = carros;

            return View();
        }

        public IActionResult Search([FromQuery] int? id)
        {
            List<Carro> carros;

            if (id == null)
            {
                ViewBag.Carros = _context.Carros.ToList();
                return View();
            }

            ViewBag.Carros = _context.Fabricantes
                                     .Include(x => x.Carros)
                                     .FirstOrDefault(f => f.Id == id).Carros;

            ViewBag.FabricanteNome = _context.Fabricantes.FirstOrDefault(f => f.Id == id).Nome;
            return View();

        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

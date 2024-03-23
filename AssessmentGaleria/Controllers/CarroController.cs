using AssessmentGaleria.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace AssessmentGaleria.Controllers
{

    public class CarroController : Controller
    {
        private readonly GaleriaDBContext _context;

        public CarroController(GaleriaDBContext context)
        {
            _context = context;
        }
        public IActionResult Detail(int id)
        {
            var carro = _context.Carros.FirstOrDefault(x => x.Id == id);

            if (carro == null)
                return NotFound();

            return View(carro);
        }

        public IActionResult Create()
        {
            var fabricantes = _context.Fabricantes.ToList();

            ViewBag.fabricantes = fabricantes;

            return View();
        }

        [HttpPost]
        public IActionResult Create([FromForm] Carro carro, [Bind("fabricanteId")] int fabricanteId)
        {
            var fabricante = this._context.Fabricantes.FirstOrDefault(x => x.Id == fabricanteId);
            if (fabricante == null)
            {
                ModelState.AddModelError("fabricanteId", "Por favor, selecione um fabricante");
                var fabricantes = _context.Fabricantes.ToList();
                ViewBag.fabricantes = fabricantes;
                return View(carro);
            }

            var image = Request.Form.Files.GetFile("imageFile");
            if (image == null)
            {
                ModelState.AddModelError("imageFile", "Por favor, selecione uma imagem.");
                var fabricantes = _context.Fabricantes.ToList();
                ViewBag.fabricantes = fabricantes;
                return View(carro);
            }

            if (!image.ContentType.StartsWith("image/"))
            {
                ModelState.AddModelError("imageFile", "Apenas arquivos de imagem são permitidos.");
                var fabricantes = _context.Fabricantes.ToList();
                ViewBag.fabricantes = fabricantes;
                return View(carro);
            }

            var fileName = image.FileName;
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/imagens_carros", fileName);
            using (System.IO.Stream fs = new FileStream(filePath, FileMode.Create))
            {
                image.CopyTo(fs);
                fs.Flush();
            }

            carro.Imagem = $"/imagens_carros/{image.FileName}";

            fabricante.Carros.Add(carro);
            this._context.Fabricantes.Update(fabricante);
            this._context.SaveChanges();

            return Redirect("/fabricante");
        }
    }
}


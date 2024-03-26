using AssessmentGaleria.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace AssessmentGaleria.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly GaleriaDBContext _context;

        public UsuarioController(GaleriaDBContext context)
        {
            _context = context;
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(Usuario usuario) 
        {
            ModelState.Remove("Nome");
            if (!ModelState.IsValid)
            {
                return View(usuario);
            }

            var user = _context.Usuarios.FirstOrDefault(x => x.Email == usuario.Email && x.Senha == usuario.Senha);
            if (user == null)
            {
                ModelState.AddModelError("erro_login", "Usuário ou senha inválidos");
                return View(usuario);
            }

            var id = new ClaimsIdentity(IdentityConstants.ApplicationScheme);
            id.AddClaim(new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()));
            id.AddClaim(new Claim(ClaimTypes.Name, user.Nome.ToString()));

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id));

            return RedirectToAction("Index", "Home");
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Usuario usuario)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            if (this._context.Usuarios.Any(x => x.Email == usuario.Email))
            {
                ModelState.AddModelError("duplicated_email", "Email já cadastrado");
                return View();
            }

            this._context.Add(usuario);
            this._context.SaveChanges();

            return RedirectToAction("Login");
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login", "Usuario");
        }
    }
}

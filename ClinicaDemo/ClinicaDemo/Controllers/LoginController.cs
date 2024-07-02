using ClinicaDemo.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace ClinicaDemo.Controllers
{
    public class LoginController : Controller
    {
        private readonly DataContext _context;

        public LoginController(DataContext context)
        {
            _context = context;
        }


        public IActionResult IniciarSesion()
        {           
            return View();
        }

        [HttpPost]
        public IActionResult IniciarSesion(Usuario usuario)
        {
            return RedirectToAction("Index", "Home");
        }

        public IActionResult Registro()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Registro(Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                _context.Add(usuario);
                await _context.SaveChangesAsync();
                TempData["Message"] = "Usuario registrado exitosamente!!!";
                return RedirectToAction("IniciarSesion", "Login");
            }
            return View();                              
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}

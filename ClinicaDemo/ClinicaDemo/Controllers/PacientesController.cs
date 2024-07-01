using Microsoft.AspNetCore.Mvc;

namespace ClinicaDemo.Controllers
{
    public class PacientesController : Controller
    {
        public IActionResult Lista()
        {
            return View();
        }
    }
}

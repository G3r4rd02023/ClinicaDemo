using ClinicaDemo.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace ClinicaDemo.Controllers
{
    public class IngresosController : Controller
    {
        private readonly DataContext _context;

        public IngresosController(DataContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var ingresos = _context.Pagos.Include(i => i.Cita).ToList();
            return View(ingresos);
        }
    }
}

using ClinicaDemo.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ClinicaDemo.Controllers
{
    public class PacientesController : Controller
    {

        private readonly DataContext _context;

        public PacientesController(DataContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Lista()
        {
            return View(await _context.Pacientes.ToListAsync());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Paciente paciente)
        {
            if (ModelState.IsValid)
            {
                paciente.FechaNacimiento = DateTime.Now.AddYears(-25);
                _context.Add(paciente);
                await _context.SaveChangesAsync();
                TempData["AlertMessage"] = "Paciente creado exitosamente!!!";
                return RedirectToAction("Lista");
            }
            return View(paciente);
        }

        public IActionResult Detalles(int? id)
        {
            var paciente = _context.Pacientes
                .Include(p => p.HistorialClinico)
                .OrderByDescending(p => p.Id)
                .FirstOrDefault(p => p.Id == id);

            if (paciente == null)
            {
                return NotFound();
            }

            return View(paciente);
        }



        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Pacientes == null)
            {
                return NotFound();
            }

            var evento = await _context.Pacientes.FirstOrDefaultAsync(e => e.Id == id);

            if (evento == null)
            {
                return NotFound();
            }

            _context.Pacientes.Remove(evento);
            await _context.SaveChangesAsync();
            TempData["AlertMessage"] = "Paciente eliminado exitosamente!!!";
            return RedirectToAction("Lista");
        }
    }
}


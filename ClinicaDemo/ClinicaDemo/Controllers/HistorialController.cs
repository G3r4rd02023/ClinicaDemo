using ClinicaDemo.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace ClinicaDemo.Controllers
{
    public class HistorialController : Controller
    {

        private readonly DataContext _context;

        public HistorialController(DataContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index(int? idPaciente)
        {
            List<SelectListItem> list = await _context.Pacientes.OrderBy(p => p.Nombre).Select(x => new SelectListItem
            {
                Text = x.FullName,
                Value = x.Id.ToString()
            })           
            .ToListAsync();

            list.Insert(0, new SelectListItem
            {
                Text = "[Seleccione un paciente...]",
                Value = "0"
            });

            idPaciente ??= 0;

            var historialClinico = await _context.HistorialClinico
                .Where(h => h.Paciente!.Id == idPaciente)
                .ToListAsync();

            var viewModel = new HistorialClinicoViewModel
            {
                IdPaciente = idPaciente.Value,
                HistorialesClinicos = historialClinico
            };

            ViewBag.Pacientes = list;
            return View(viewModel);
        }

        public IActionResult Create(int id)
        {

            var paciente = _context.Pacientes.FirstOrDefault(p => p.Id == id);
            
            if(paciente == null)
            {
                return NotFound();
            }

            var viewModel = new HistorialClinicoViewModel
            {
                IdPaciente = id,
                Paciente = paciente
            };

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(HistorialClinicoViewModel viewModel)
        {
            
            var paciente = _context.Pacientes.FirstOrDefault(p => p.Id == viewModel.Paciente!.Id);


            if (ModelState.IsValid)
            {
                var historialClinico = new HistorialClinico
                {
                    Paciente = paciente,                    
                    FechaConsulta = DateTime.Now,
                    Diagnostico = viewModel.Diagnostico,
                    Tratamiento = viewModel.Tratamiento,
                    Notas = viewModel.Notas
                };
                _context.HistorialClinico.Add(historialClinico);
                await _context.SaveChangesAsync();

                TempData["AlertMessage"] = "Registro creado exitosamente.";
                return RedirectToAction(nameof(Index), new { id = viewModel.IdPaciente });
            }
            return View(viewModel);
        }

    }
}

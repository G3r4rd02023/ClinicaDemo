using ClinicaDemo.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace ClinicaDemo.Controllers
{
    public class CitasController : Controller
    {
        private readonly DataContext _context;

        public CitasController(DataContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Citas
                .Include(c => c.Paciente)
                .Include(c => c.Medico)
                .ToListAsync());
        }

        public async Task<IActionResult> Create()
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
            
            List<SelectListItem> listDoctores = await _context.Medicos.OrderBy(p => p.Nombre).Select(x => new SelectListItem
            {
                Text = x.FullName,
                Value = x.Id.ToString()
            })
           .ToListAsync();

            listDoctores.Insert(0, new SelectListItem
            {
                Text = "[Seleccione un doctor...]",
                Value = "0"
            });

            ViewBag.Pacientes = list;
            ViewBag.Medicos = listDoctores;
            
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Cita cita)
        {
            if (ModelState.IsValid)
            {
                var medico = _context.Medicos.FirstOrDefault(c => c.Id == cita.IdDoctor);
                var paciente = _context.Pacientes.FirstOrDefault(c => c.Id == cita.IdPaciente);
                var nuevaCita = new Cita()
                {
                    IdDoctor = cita.IdDoctor,
                    Medico = medico,
                    IdPaciente = cita.IdPaciente,
                    Paciente = paciente,
                    Motivo = cita.Motivo,
                    FechaCita = cita.FechaCita,
                    HoraCita = cita.HoraCita
                };
                _context.Add(nuevaCita);
                await _context.SaveChangesAsync();
                TempData["AlertMessage"] = "Cita creada exitosamente!!!";
                return RedirectToAction("Index");
            }
            return View(cita);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Citas == null)
            {
                return NotFound();
            }

            var evento = await _context.Citas.FirstOrDefaultAsync(e => e.Id == id);

            if (evento == null)
            {
                return NotFound();
            }

            _context.Citas.Remove(evento);
            await _context.SaveChangesAsync();
            TempData["AlertMessage"] = "Cita eliminada exitosamente!!!";
            return RedirectToAction("Index");
        }

        public IActionResult Calendar()
        {
            List<Cita> eventos = _context.Citas.ToList();
            List<object> items = new List<object>();

            foreach (Cita evento in eventos)
            {
                var item = new
                {
                    id = evento.Id,
                    title = evento.Motivo,
                    start = evento.FechaCita.AddHours(10), 
                    end = evento.FechaCita.AddHours(11)               
                };
                items.Add(item);
            }

            ViewBag.Eventos = JsonConvert.SerializeObject(items);
            return View();
        }

        public IActionResult Pagar()
        {
            return View();
        }
    }
}

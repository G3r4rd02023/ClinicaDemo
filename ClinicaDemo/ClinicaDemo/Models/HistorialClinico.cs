using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace ClinicaDemo.Models
{
    public class HistorialClinico
    {
        public int Id { get; set; }

        [ValidateNever]
        public Paciente? Paciente { get; set; }

        public DateTime FechaConsulta { get; set; }

        public string Diagnostico { get; set; } = null!;

        public string Tratamiento { get; set; } = null!;

        public string Notas { get; set; } = null!;
       

    }
}

namespace ClinicaDemo.Models
{
    public class HistorialClinico
    {
        public int Id { get; set; }
        
        public Paciente? Paciente { get; set; } = null!;

        public DateTime FechaConsulta { get; set; }

        public string Diagnostico { get; set; } = null!;

        public string Tratamiento { get; set; } = null!;

        public string Notas { get; set; } = null!;


    }
}

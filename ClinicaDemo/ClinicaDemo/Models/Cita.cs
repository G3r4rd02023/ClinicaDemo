namespace ClinicaDemo.Models
{
    public class Cita
    {
        public int Id { get; set; }

        public int IdPaciente {  get; set; }

        public int IdMedico { get; set; }

        public Paciente? Paciente { get; set; }
        
        public Medico? Medico { get; set; }

        public DateTime FechaCita { get; set; }

        public DateTime HoraCita { get; set; }

        public string Motivo { get; set; } = null!;
    }
}

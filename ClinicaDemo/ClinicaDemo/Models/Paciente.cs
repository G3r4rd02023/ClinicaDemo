namespace ClinicaDemo.Models
{
    public class Paciente
    {
        public int Id { get; set; }

        public string Nombre { get; set; } = null!;

        public string Apellidos { get; set; } = null!;

        public DateTime FechaNacimiento { get; set; }

        public string Genero { get; set; } = null!;

        public string Direccion { get; set;} = null!;

        public string Telefono { get; set; } = null!;

        public string Email { get; set; } = null!;

        public string FullName => $"{Nombre} {Apellidos}";

        public ICollection<HistorialClinico>? HistorialClinico { get; set; } 

    }
}

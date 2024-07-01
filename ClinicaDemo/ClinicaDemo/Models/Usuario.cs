namespace ClinicaDemo.Models
{
    public class Usuario
    {
        public int Id { get; set; }

        public string NombreUsuario { get; set; } = null!;

        public string Contraseña { get; set; } = null!;

        public string Rol { get; set; } = null!;

    }
}

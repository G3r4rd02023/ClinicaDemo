using Microsoft.EntityFrameworkCore;

namespace ClinicaDemo.Models
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<Paciente> Pacientes { get; set; }

        public DbSet<Cita> Citas { get; set; }

        public DbSet<Usuario> Usuarios { get; set; }

        public DbSet<Pago>  Pagos { get; set; }

        public DbSet<Medico> Medicos { get; set; }

        public DbSet<HistorialClinico> HistorialClinico { get; set; }



    }
}

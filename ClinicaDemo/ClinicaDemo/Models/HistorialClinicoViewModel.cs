namespace ClinicaDemo.Models
{
    public class HistorialClinicoViewModel : HistorialClinico
    {
        public int IdPaciente { get; set; }
        public IEnumerable<HistorialClinico> HistorialesClinicos { get; set; } = new List<HistorialClinico>();
    }
}

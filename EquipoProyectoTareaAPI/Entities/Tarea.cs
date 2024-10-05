
using System.ComponentModel.DataAnnotations;


namespace EquipoProyectoTareaAPI.Entities
{
    public class Tarea
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Nombre { get; set; }

        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }

        public int ProyectoId { get; set; }
        public Proyecto Proyecto { get; set; }

        public string Estado { get; set; }

        public bool IsValid()
        {
            if (string.IsNullOrEmpty(Nombre))
            {
                return false;
            }

            if (FechaInicio >= FechaFin)
            {
                return false;
            }

            if (ProyectoId == 0)
            {
                return false;
            }

            if (Estado != "Pendiente" && Estado != "En progreso" && Estado != "Completada")
            {
                return false;
            }

            return true;
        }
    }
}

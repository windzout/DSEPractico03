using System.ComponentModel.DataAnnotations;

namespace EquipoProyectoTareaAPI.Entities
{
    public class Proyecto
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Nombre { get; set; }

        public int EquipoId { get; set; }
        public Equipo Equipo { get; set; }

        public ICollection<Miembro> Miembros { get; set; }

        public ICollection<Tarea> Tareas { get; set; }

        public ICollection<Dueño> Dueños { get; set; }

        public void AgregarTarea(Tarea tarea)
        {
            if (tarea == null)
            {
                throw new ArgumentNullException(nameof(tarea));
            }

            Tareas.Add(tarea);
        }

        public void EliminarTarea(Tarea tarea)
        {
            if (tarea == null)
            {
                throw new ArgumentNullException(nameof(tarea));
            }

            Tareas.Remove(tarea);
        }

        public bool IsValid()
        {
            if (string.IsNullOrEmpty(Nombre))
            {
                return false;
            }

            if (Nombre.Length > 50)
            {
                return false;
            }

            if (Miembros == null || Miembros.Count == 0)
            {
                return false;
            }

            return true;
        }
    }
}
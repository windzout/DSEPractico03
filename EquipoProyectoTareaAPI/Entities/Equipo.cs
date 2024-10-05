using System.ComponentModel.DataAnnotations;

namespace EquipoProyectoTareaAPI.Entities
{

    public class Equipo
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Nombre { get; set; }

        public ICollection<Miembro> Miembros { get; set; }
        public ICollection<Proyecto> Proyectos { get; set; }

        public void AgregarMiembro(Miembro miembro)
        {
            if (miembro == null)
            {
                throw new ArgumentNullException(nameof(miembro));
            }

            Miembros.Add(miembro);
        }

        public void EliminarMiembro(Miembro miembro)
        {
            if (miembro == null)
            {
                throw new ArgumentNullException(nameof(miembro));
            }

            Miembros.Remove(miembro);
        }

        public void AgregarProyecto(Proyecto proyecto)
        {
            if (proyecto == null)
            {
                throw new ArgumentNullException(nameof(proyecto));
            }

            Proyectos.Add(proyecto);
        }

        public void EliminarProyecto(Proyecto proyecto)
        {
            if (proyecto == null)
            {
                throw new ArgumentNullException(nameof(proyecto));
            }

            Proyectos.Remove(proyecto);
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
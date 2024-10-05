using System.ComponentModel.DataAnnotations;

namespace EquipoProyectoTareaAPI.Entities
{
    public class Miembro
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Nombre { get; set; }

        [Required]
        [StringLength(50)]
        public string Apellido { get; set; }

        [Required]
        [EmailAddress]
        public string Correo { get; set; }

        public int EquipoId { get; set; }
        public Equipo Equipo { get; set; }

        public bool IsValid()
        {
            if (string.IsNullOrEmpty(Nombre))
            {
                return false;
            }

            if (string.IsNullOrEmpty(Apellido))
            {
                return false;
            }

            if (string.IsNullOrEmpty(Correo))
            {
                return false;
            }

            return true;
        }
    }
}
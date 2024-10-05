using EquipoProyectoTareaAPI.Data;

namespace EquipoProyectoTareaAPI.Entities
{
    public class MiModelo
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }

        private readonly MyDbContext _contexto;

        public bool ValidarInformacion(MiModelo modelo)
        {
            if (modelo.Nombre == null || modelo.Descripcion == null)
            {
                return false;
            }
            return true;
        }

        public async Task Crear(MiModelo modelo)
        {
            if (ValidarInformacion(modelo))
            {
                _contexto.MiModelos.Add(modelo);
                await _contexto.SaveChangesAsync();
            }
            else
            {
                throw new Exception("La información no es válida");
            }
        }

        public async Task Actualizar(MiModelo modelo)
        {
            if (ValidarInformacion(modelo))
            {
                _contexto.MiModelos.Update(modelo);
                await _contexto.SaveChangesAsync();
            }
            else
            {
                throw new Exception("La información no es válida");
            }
        }

        public async Task Eliminar(int id)
        {
            var modelo = await _contexto.MiModelos.FindAsync(id);
            if (modelo != null)
            {
                _contexto.MiModelos.Remove(modelo);
                await _contexto.SaveChangesAsync();
            }
            else
            {
                throw new Exception("El registro no existe");
            }
        }
    }
}

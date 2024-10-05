using EquipoProyectoTareaAPI.Data;
using EquipoProyectoTareaAPI.Entities;
using Microsoft.EntityFrameworkCore;

namespace EquipoProyectoTareaAPI.Services
{
    public class MiServicio
    {
        private readonly MyDbContext _contexto;

        public MiServicio(MyDbContext contexto)
        {
            _contexto = contexto;
        }

        public async Task<List<MiModelo>> ObtenerTodos()
        {
            return await _contexto.MiModelos.ToListAsync();
        }

        public async Task<MiModelo> ObtenerPorId(int id)
        {
            return await _contexto.MiModelos.FindAsync(id);
        }

        public async Task Crear(MiModelo modelo)
        {
            _contexto.MiModelos.Add(modelo);
            await _contexto.SaveChangesAsync();
        }

        public async Task Actualizar(MiModelo modelo)
        {
            _contexto.MiModelos.Update(modelo);
            await _contexto.SaveChangesAsync();
        }

        public async Task Eliminar(int id)
        {
            var modelo = await _contexto.MiModelos.FindAsync(id);
            if (modelo != null)
            {
                _contexto.MiModelos.Remove(modelo);
                await _contexto.SaveChangesAsync();
            }
        }
    }
}
using EquipoProyectoTareaAPI.Entities;
using EquipoProyectoTareaAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace EquipoProyectoTareaAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MiModeloController : ControllerBase
    {
        private readonly MiServicio _servicio;

        public MiModeloController(MiServicio servicio)
        {
            _servicio = servicio;
        }

        [HttpGet]
        public async Task<ActionResult<List<MiModelo>>> ObtenerTodos()
        {
            return await _servicio.ObtenerTodos();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<MiModelo>> ObtenerPorId(int id)
        {
            return await _servicio.ObtenerPorId(id);
        }

        [HttpPost]
        public async Task<ActionResult<MiModelo>> Crear(MiModelo modelo)
        {
            await _servicio.Crear(modelo);
            return CreatedAtAction(nameof(ObtenerPorId), new { id = modelo.Id }, modelo);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Actualizar(MiModelo modelo)
        {
            await _servicio.Actualizar(modelo);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Eliminar(int id)
        {
            await _servicio.Eliminar(id);
            return NoContent();
        }
    }
}
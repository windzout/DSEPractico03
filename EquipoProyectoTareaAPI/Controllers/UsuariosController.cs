using EquipoProyectoTareaAPI.Data;
using EquipoProyectoTareaAPI.Entities;
using Microsoft.AspNetCore.Mvc;


namespace EquipoProyectoTareaAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuariosController : ControllerBase
    {
        private readonly MyDbContext _context;

        public UsuariosController(MyDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<ActionResult<Usuario>> CrearUsuario(Usuario usuario)
        {
            _context.Usuarios.Add(usuario);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(CrearUsuario), new { id = usuario.Id }, usuario);
        }
    }
}
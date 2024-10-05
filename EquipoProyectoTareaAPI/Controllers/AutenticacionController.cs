using EquipoProyectoTareaAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace EquipoProyectoTareaAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AutenticacionController : ControllerBase
    {
        private readonly AutenticacionService _autenticacionService;

        public AutenticacionController(AutenticacionService autenticacionService)
        {
            _autenticacionService = autenticacionService;
        }

        [HttpPost]
        public async Task<ActionResult> IniciarSesion(string username, string password)
        {
            var result = await _autenticacionService.IniciarSesion(username, password);
            if (result.Succeeded)
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
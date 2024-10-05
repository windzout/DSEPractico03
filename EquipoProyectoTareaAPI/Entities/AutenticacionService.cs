using EquipoProyectoTareaAPI.Entities;
using Microsoft.AspNetCore.Identity;

namespace EquipoProyectoTareaAPI.Services
{
    public class AutenticacionService
    {
        private readonly SignInManager<Usuario> _signInManager;
        private readonly UserManager<Usuario> _userManager;

        public AutenticacionService(SignInManager<Usuario> signInManager, UserManager<Usuario> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }

        public async Task<SignInResult> IniciarSesion(string username, string password)
        {
            var user = await _userManager.FindByNameAsync(username);
            if (user != null)
            {
                var result = await _signInManager.PasswordSignInAsync(user, password, false, false);
                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(user, "Usuario");
                }
                return result;
            }
            return SignInResult.Failed;

        }
    }
}
using Microsoft.AspNetCore.Authorization;

namespace EquipoProyectoTareaAPI.Entities
{
    public class AutorizacionService
    {
        public AuthorizationPolicy AdministradorPolicy()
        {
            return new AuthorizationPolicyBuilder()
                .RequireRole("Administrador")
                .Build();
        }

        public AuthorizationPolicy UsuarioPolicy()
        {
            return new AuthorizationPolicyBuilder()
                .RequireRole("Usuario")
                .Build();
        }
    }
}

﻿using Microsoft.AspNetCore.Identity;

namespace EquipoProyectoTareaAPI.Entities
{
    public class Usuario : IdentityUser
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }
    }
}
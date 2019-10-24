using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity;

namespace Andamios.Core.Data.Entities
{
    public class Usuario : IdentityUser
    {

        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Imagen { get; set; }
        public string Role { get; set; }
        public bool Estado { get; set; }

        public string RefreshToken { get; set; }

    }
}

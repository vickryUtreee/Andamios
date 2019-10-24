using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Andamios.API.Models
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Es necesario el nombre")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "Es necesario el Apellido")]
        public string Apellido { get; set; }
        [Required(ErrorMessage = "Es necesario el Correo electrónico")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Es necesario suministrar una contraseña válida")]
        public string Password { get; set; }
        public string UserName { get; set; }
        public string Role { get; set; }
        public string Imagen { get; set; }
    }

    public class LoginViewModel
    {
        public string Email { get; set; }
        public string UserName {get; set;}
        public string Password { get; set; }
    }

    public class ResetPasswordViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        public string Code { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Andamios.API.Models
{
    public class AutorViewModel
    {
        [Required(ErrorMessage = "El nombre es requerido")]
        public string Name { get; set; }
    }
}

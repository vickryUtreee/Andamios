using System;
using System.Collections.Generic;

namespace Andamios.Core.Data.Entities
{
    public partial class Ddproyecto
    {
        public int ProId { get; set; }
        public int ProClienteId { get; set; }
        public string ProVendedorId { get; set; }
        public string ProNombre { get; set; }
        public string ProDireccion { get; set; }
        public string ProContacto { get; set; }
        public string ProTelContacto { get; set; }
        public string ProCorreoContacto { get; set; }
        public DateTime? ProFechaProyecto { get; set; }
        public decimal? ProDescuentoGlobal { get; set; }
        public string ProUsuarioCreacion { get; set; }
        public DateTime? ProFechaCreacion { get; set; }
        public string ProUsuarioModifica { get; set; }
        public DateTime? ProFechaModifica { get; set; }
    }
}

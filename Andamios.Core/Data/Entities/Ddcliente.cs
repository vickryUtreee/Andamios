using System;
using System.Collections.Generic;

namespace Andamios.Core.Data.Entities
{
    public partial class Ddcliente
    {
        public int ClienteId { get; set; }
        public string ClienteTipo { get; set; }
        public int? ClienteTipoId { get; set; }
        public int? ClienteTipoComprobante { get; set; }
        public string ClienteDescripcion { get; set; }
        public int? ClienteSector { get; set; }
        public string ClienteDireccion { get; set; }
        public int? ClienteRegion { get; set; }
        public string ClienteTelOf1 { get; set; }
        public string ClienteTelOf2 { get; set; }
        public string ClienteTelFax { get; set; }
        public string ClienteCorreoElec { get; set; }
        public string ClienteGestorCobros { get; set; }
        public string ClienteCodigoVendedor { get; set; }
        public string ClienteUsuarioRegistro { get; set; }
        public string ClienteUsuarioModifica { get; set; }
        public DateTime? ClienteFechaCreacion { get; set; }
        public DateTime? ClienteFechaModifica { get; set; }
        public string ClienteGerente { get; set; }
        public string ClienteContacto { get; set; }
        public string ClienteContactoCel1 { get; set; }
        public string ClienteContactoCel2 { get; set; }
        public string ClienteEstatus { get; set; }
        public bool ClienteIsActive { get; set; } = true;

        //public override string ToString()
        //{
            
        //}
    }
}

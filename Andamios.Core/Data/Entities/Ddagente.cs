using System;
using System.Collections.Generic;

namespace Andamios.Core.Data.Entities
{
    public partial class Ddagente
    {
        public int AgenteId { get; set; }
        public string AgenteDescripcion { get; set; }
        public string AgentePais { get; set; }
        public string AgenteDireccion { get; set; }
        public string AgenteTelOficina1 { get; set; }
        public string AgenteTelOficina2 { get; set; }
        public string AgenteTelFax1 { get; set; }
        public string AgenteCorreoElec { get; set; }
        public string AgenteUsuRegistro { get; set; }
        public DateTime? AgenteFechaCreacion { get; set; }
        public DateTime? AgenteFechaModifica { get; set; }
        public string AgenteContacto { get; set; }
        public string AgenteContactoTelCel { get; set; }
        public string AgenteEstatus { get; set; }
    }
}

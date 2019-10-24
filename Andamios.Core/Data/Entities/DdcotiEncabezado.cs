using System;
using System.Collections.Generic;

namespace Andamios.Core.Data.Entities
{
    public partial class DdcotiEncabezado
    {
        public int CotiEnId { get; set; }
        public string CotiEnTipo { get; set; }
        public string CotiEnClas { get; set; }
        public int? CotiEnClienteId { get; set; }
        public int? CotiEnProyectoId { get; set; }
        public string CotiEnOrden { get; set; }
        public string CotiEnUsuarioVendedor { get; set; }
        public string CotiEnUsuarioCreacion { get; set; }
        public string CotiEnUsuarioAnulacion { get; set; }
        public string CotiEnUsuarioActivacion { get; set; }
        public DateTime? CotiEnFechaCreacion { get; set; }
        public DateTime? CotiEnFechaAnulacion { get; set; }
        public DateTime? CotiEnFechaActivacion { get; set; }
        public short? CotiEnDias { get; set; }
        public string CotiEnDescripcion { get; set; }
        public string CotiEnImpuesto { get; set; }
        public string CotiEnCondicionPago { get; set; }
        public string CotiEnTransporte { get; set; }
        public decimal? CotiEnDescuento { get; set; }
        public string CotiEnEstatus { get; set; }
    }
}

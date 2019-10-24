using System;
using System.Collections.Generic;

namespace Andamios.Core.Data.Entities
{
    public partial class DdconteoDevoEnc
    {
        public int ContDevoEncId { get; set; }
        public int? ContDevoEncCoti { get; set; }
        public int? ContDevoEncClienteId { get; set; }
        public int? ContDevoEncProyectoId { get; set; }
        public int? ContDevoEncOrden { get; set; }
        public DateTime? ContDevoEncFechaCreacion { get; set; }
        public string ContDevoEncUsuCreacion { get; set; }
        public DateTime? ContDevoEncFechaModifica { get; set; }
        public string ContDevoEncUsuModifica { get; set; }
        public string ContDevoEncEstatus { get; set; }
    }
}

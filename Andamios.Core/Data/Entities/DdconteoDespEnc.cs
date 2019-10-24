using System;
using System.Collections.Generic;

namespace Andamios.Core.Data.Entities
{
    public partial class DdconteoDespEnc
    {
        public int ContDespEncId { get; set; }
        public int? ContDespEncCotiId { get; set; }
        public int? ContDespEncClienteId { get; set; }
        public int? ContDespEncProyectoId { get; set; }
        public string ContDespEncOrden { get; set; }
        public DateTime? ContDespEncFechaCreacion { get; set; }
        public string ContDespEncUserCrea { get; set; }
        public DateTime? ContDespEncFechaModifica { get; set; }
        public string ContDespEncUserModifica { get; set; }
        public string ContDespEncEstatus { get; set; }
    }
}

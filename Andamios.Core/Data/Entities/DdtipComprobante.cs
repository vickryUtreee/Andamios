using System;
using System.Collections.Generic;

namespace Andamios.Core.Data.Entities
{
    public partial class DdtipComprobante
    {
        public int TcompId { get; set; }
        public string TcompDesc { get; set; }
        public string TcompImpuesto { get; set; }
        public string TcompUsuCrea { get; set; }
        public DateTime? TcompFechaCrea { get; set; }
        public string TcompUsuModi { get; set; }
        public DateTime? TcompFechaModi { get; set; }
        public string TcompEstatus { get; set; }
    }
}

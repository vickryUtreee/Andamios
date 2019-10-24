using System;
using System.Collections.Generic;

namespace Andamios.Core.Data.Entities
{
    public partial class DdconteoDevoDet
    {
        public int ContDevoDetId { get; set; }
        public int? ContDevoDetEncId { get; set; }
        public string ContDevoProdId { get; set; }
        public int? ContDevoCantProdOrd { get; set; }
        public int? ContDevoCantProyecto { get; set; }
    }
}

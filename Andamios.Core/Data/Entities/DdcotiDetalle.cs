using System;
using System.Collections.Generic;

namespace Andamios.Core.Data.Entities
{
    public partial class DdcotiDetalle
    {
        public int CotiDeId { get; set; }
        public int? CotiEnDeId { get; set; }
        public string CotiProdId { get; set; }
        public int? CotiCantProd { get; set; }
        public decimal? CotiPrecioProd { get; set; }
        public decimal? CotiValorProd { get; set; }
    }
}

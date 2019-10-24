using System;
using System.Collections.Generic;

namespace Andamios.Core.Data.Entities
{
    public partial class DdfactDet
    {
        public int FactDetId { get; set; }
        public int? FactEnDetId { get; set; }
        public string FactDetProdId { get; set; }
        public int? FactDetCantProd { get; set; }
        public decimal? FactDetMonto { get; set; }
    }
}

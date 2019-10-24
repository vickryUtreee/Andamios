using System;
using System.Collections.Generic;

namespace Andamios.Core.Data.Entities
{
    public partial class DdconDespDet
    {
        public int ConDespDetId { get; set; }
        public int? ConDespEnDetId { get; set; }
        public string ConDespDetProdId { get; set; }
        public int? ConDespDetCantOrd { get; set; }
    }
}

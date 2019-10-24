using System;
using System.Collections.Generic;

namespace Andamios.Core.Data.Entities
{
    public partial class DdingInvEnc
    {
        public int TraEnIngId { get; set; }
        public int? TraEnCodSupId { get; set; }
        public int? TraEnCodAgeId { get; set; }
        public string TraEnNumEmbarque { get; set; }
        public string TraEnFactAge { get; set; }
        public DateTime? TraEnFecFactAge { get; set; }
        public string TraEnOrdenCompra { get; set; }
        public DateTime? TraEnFecCrea { get; set; }
        public string TraEnUsuCrea { get; set; }
    }
}

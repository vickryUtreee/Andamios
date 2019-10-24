using System;
using System.Collections.Generic;

namespace Andamios.Core.Data.Entities
{
    public partial class DdconDevoEnc
    {
        public int ConDevoEnId { get; set; }
        public int? ConDevoEnContId { get; set; }
        public string ConDevoEnTipo { get; set; }
        public int? ConDevoEnProyectoId { get; set; }
        public int? ConDevoEnCliId { get; set; }
        public string ConDevoOrdenC { get; set; }
        public DateTime? ConDevoFechaEmision { get; set; }
        public string ConDevoUsuarioCrea { get; set; }
        public string ConDevoEnEstatus { get; set; }
    }
}

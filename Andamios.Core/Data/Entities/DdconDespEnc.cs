using System;
using System.Collections.Generic;

namespace Andamios.Core.Data.Entities
{
    public partial class DdconDespEnc
    {
        public int ConDespEnId { get; set; }
        public int? ConDespEnConteoId { get; set; }
        public string ConDespEnCotiId { get; set; }
        public string ConDespEnTipo { get; set; }
        public int? ConDespEnProyectoId { get; set; }
        public int? ConDespEnCliId { get; set; }
        public string ConDespEnOrdenC { get; set; }
        public DateTime? ConDespEnFechaEmision { get; set; }
        public string ConDespEnUsuarioCrea { get; set; }
        public string ConDespEnEstatus { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace Andamios.Core.Data.Entities
{
    public partial class DdtipoTraAju
    {
        public int TraTipoId { get; set; }
        public string TraTipoDesc { get; set; }
        public string TraTipoAjuste { get; set; }
        public DateTime? TraTipoFechaCrea { get; set; }
        public string TratipoUsuCrea { get; set; }
        public string TraTipoEstatus { get; set; }
    }
}

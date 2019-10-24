using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Andamios.API.Helpers
{
    public class ApplicationSettings
    {
        public ApplicationSettings()
        {
            
        }
        public string JWT_Secrete { get; set; }
        public string Origins_Url { get; set; }
        public string DI { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sapphire.Entities.ConfigurationModel
{
    public class JwtConfig
    {

        public string Section { get; set; } = "JwtConfig";
        public string? ValidIssuer { get; set; }
        public string? ValidAudience { get; set; }
        public string? Expires { get; set; }
    }
}

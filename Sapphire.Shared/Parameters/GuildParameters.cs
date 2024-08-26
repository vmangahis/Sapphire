using Sapphire.Shared.RequestFeatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sapphire.Shared.Parameters
{
    public class GuildParameters : RequestParameters
    {
        public GuildParameters() {
            OrderBy = "guildname";
        }
        public string? SearchTerm { get; set; }
        public bool InviteOnly { get; set; }

    }
}

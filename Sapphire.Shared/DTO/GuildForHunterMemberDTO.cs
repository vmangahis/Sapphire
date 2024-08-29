using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Sapphire.Shared.DTO
{
    public record GuildForHunterMemberDTO
    {
        public string? GuildName { get; set; } = string.Empty;
    }
}

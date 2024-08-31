using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Sapphire.Shared.DTO
{
    public record GuildDTO
    {
        public string GuildName { get; init; }
        public ICollection<HunterMemberDTO> HunterMembers { get; init; }

    }
}

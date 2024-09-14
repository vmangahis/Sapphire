using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using Sapphire.Shared.DTO.Hunter;

namespace Sapphire.Shared.DTO.Guild
{
    public record GuildDTO
    {
        public string GuildName { get; init; }
        public ICollection<HunterMemberDTO> HunterMembers { get; init; }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sapphire.Shared.DTO.Hunter;

namespace Sapphire.Shared.DTO.Guild
{
    public record GuildMembersDTO(ICollection<HunterMemberDTO> HunterMembers);
}

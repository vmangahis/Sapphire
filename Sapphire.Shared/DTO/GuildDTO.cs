using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sapphire.Shared.DTO
{
    public record GuildDTO(Guid GuildId, string GuildName, ICollection<HunterDTO> HunterMembers);
}

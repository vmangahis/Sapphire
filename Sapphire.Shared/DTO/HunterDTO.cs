using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sapphire.Shared.DTO
{
    
    public record HunterDTO {
        public Guid Id { get; init; }
        public string HunterName { get; init; }
        public int Rank { get; init; }
        public GuildForHunterMemberDTO Guild { get; init; }
    }
}

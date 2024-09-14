using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Sapphire.Shared.DTO.Guild;

namespace Sapphire.Shared.DTO.Hunter
{
    public record HunterDTO
    {
        public Guid Id { get; init; }
        public string HunterName { get; init; }
        public int Rank { get; init; }
        public GuildForHunterMemberDTO Guild { get; init; }
    }
}

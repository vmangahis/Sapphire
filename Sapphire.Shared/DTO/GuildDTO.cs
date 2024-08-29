using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Sapphire.Shared.DTO
{
    [DataContract]
    public record GuildDTO
    {
        [DataMember]
        public string GuildName { get; init; }
        [DataMember]
        public ICollection<HunterMemberDTO> HunterMembers { get; init; }

    }
}

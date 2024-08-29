using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Sapphire.Shared.DTO
{
    [DataContract]
    public record HunterMemberDTO
    {
        [DataMember]
        public Guid Id { get; init; }
        [DataMember]
        public string HunterName { get; init; }
        [DataMember]
        public int Rank { get; init; }
     }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Sapphire.Shared.DTO.Hunter
{
    public record HunterMemberDTO
    {
        public Guid Id { get; init; }
        public string HunterName { get; init; }
        public int Rank { get; init; }
    }
}

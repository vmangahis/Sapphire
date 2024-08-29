using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Sapphire.Shared.DTO
{
    public record HunterDTO
    {
        public Guid Id { get; set; } = Guid.Empty;
        public string HunterName { get; set;}
        public int Rank { get; set; }
        [XmlElement(IsNullable = true)]
        public GuildForHunterMemberDTO Guild { get; set; }
    }
}

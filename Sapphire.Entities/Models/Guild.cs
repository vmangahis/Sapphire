using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sapphire.Entities.Models
{
    public class Guild
    {
        public Guid GuildId { get; set; }
        public string GuildName { get; set; } = "Test";
        public bool IsInviteOnly { get; set; }
        public ICollection<Hunters>? HunterMembers { get; set; }

    }
}

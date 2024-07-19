using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sapphire.Entities.Models
{
    [Table("T_guild")]
    public class Guild
    {
        [Column("GuildId")]
        public Guid GuildId { get; set; }
        public string? GuildName { get; set; }
        public bool IsInviteOnly { get; set; }
        public ICollection<Hunters>? HunterMembers { get; set; }

    }
}

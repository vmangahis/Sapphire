using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sapphire.Entities.Models
{
    [Table("T_hunters")]
    public class Hunters
    {
        [Column("HunterId")]
        public Guid Id { get; set; }
        public string HunterName { get; set; } = string.Empty;
        public int Rank { get; set; } = 1;
        public double ZennyAmount { get; set; } = 0.0;
        [ForeignKey(nameof(Guild))]
        public Guid? GuildId { get; set; }
        public Guild? Guild { get; set; }
    }
}

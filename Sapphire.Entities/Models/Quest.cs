using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sapphire.Entities.Models
{
    public class Quest
    {
        public Guid QuestId { get; set; }
        public string? QuestTitle { get; set; }
        public string? QuestDescription { get; set; }
        [ForeignKey(nameof(SapphireUser))]
        public Guid  SapphireId { get; set; }
        public double ZennyReward { get; set; }

    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sapphire.Entities.Models
{
    public class Character
    {
        public Guid CharacterId { get; set; }
        public string? CharacterName { get; set; }
        public virtual required SapphireUser User { get; set; }
    }
}

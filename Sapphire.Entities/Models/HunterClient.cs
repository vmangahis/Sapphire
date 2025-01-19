using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sapphire.Entities.Models
{
    public class HunterClient
    {
        public Guid ClientId { get; set; }
        public string? ClientName { get; set; }
        public int ClientRank { get; set; } = 1;
        public double ZennyBalance { get; set; } = 1000;
        public required SapphireUser SapphireUser { get; set; }
        public Guild? Guild { get; set; }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sapphire.Entities.Models;

namespace Sapphire.Contracts
{
    public interface IGuildRepository
    {
        IEnumerable<Guild> GetAllGuild(bool track);
        Guild GetGuild(Guid guildId, bool track);
        Guild GetGuildMembers(Guid guildId, bool track);
    }
}

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
        Task<IEnumerable<Guild>> GetAllGuildAsync(bool track);
        Task<Guild> GetGuildAsync(Guid guildId, bool track);
        Task<Guild> GetGuildByNameAsync(string GuildName, bool track);
        Task<Guild> GetGuildMembersAsync(Guid guildId, bool track);
        void CreateGuild(Guild gd);
        void UpdateGuild(Guild gd);
        void DeleteGuild(Guild gd);
    }
}

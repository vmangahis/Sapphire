using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sapphire.Entities.Models;
using Sapphire.Shared.Parameters;
using Sapphire.Shared.RequestFeatures;

namespace Sapphire.Contracts
{
    public interface IGuildRepository
    {
        Task<PagedList<Guild>> GetAllGuildAsync(bool track, GuildParameters guildParams);
        Task<Guild> GetGuildAsync(Guid guildId, bool track);
        Task<Guild> GetGuildByNameAsync(string GuildName, bool track);
        Task<Guild> GetGuildMembersAsync(Guid guildId, bool track);
        void CreateGuild(Guild gd);
        void UpdateGuild(Guild gd);
        void DeleteGuild(Guild gd);
    }
}

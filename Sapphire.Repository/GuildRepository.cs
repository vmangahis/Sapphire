using Microsoft.EntityFrameworkCore;
using Sapphire.Contracts;
using Sapphire.Entities.Models;
using Sapphire.Shared.Parameters;
using Sapphire.Shared.RequestFeatures;
using Sapphire.Repository.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sapphire.Repository
{
    public class GuildRepository : RepositoryBase<Guild>,IGuildRepository
    {
        public GuildRepository(RepositoryContext cont) : base(cont) {  }

        
        
        public async Task<PagedList<Guild>> GetAllGuildAsync(bool track, GuildParameters guildParams)
        {
            var guild = await GetThroughCondition((e => e.IsInviteOnly == guildParams.InviteOnly), track)
                .FilterGuildNames(guildParams.SearchTerm ?? "")
                .Sort(guildParams.OrderBy ?? "")
                .Include(x => x.HunterMembers)
                .ToListAsync();
            return PagedList<Guild>.ToPagedList(guild, guildParams.PageNumber, guildParams.PageSize);
        }
            
        

        public async Task<Guild> GetGuildAsync(Guid guildId, bool track) => await GetThroughCondition(x => x.GuildId.Equals(guildId), track).Include(e => e.HunterMembers).FirstOrDefaultAsync();

        public async Task<Guild> GetGuildByNameAsync(string gname, bool track) => await GetThroughCondition(x => x.GuildName.Equals(gname), track).FirstOrDefaultAsync();
        public async Task<Guild> GetGuildMembersAsync(Guid guildId, bool track) => await GetThroughCondition(x => x.GuildId.Equals(guildId), track).Include(y => y.HunterMembers).FirstOrDefaultAsync();

        public void CreateGuild(Guild gd) => Create(gd);
        public void UpdateGuild(Guild gd) => Update(gd);
        public void DeleteGuild(Guild gd) => Delete(gd);
    }
}

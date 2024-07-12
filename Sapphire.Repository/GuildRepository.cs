using Microsoft.EntityFrameworkCore;
using Sapphire.Contracts;
using Sapphire.Entities.Models;
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

        
        
        public IEnumerable<Guild> GetAllGuild(bool track) => GetAll(track).OrderBy(x => x.GuildName).Include(x => x.HunterMembers).ToList();
        

        public Guild GetGuild(Guid guildId, bool track) => GetThroughCondition(x => x.GuildId.Equals(guildId), track).Include(e => e.HunterMembers).FirstOrDefault();

        public Guild GetGuildByName(string gname, bool track) => GetThroughCondition(x => x.GuildName.Equals(gname), track).FirstOrDefault();
        public Guild GetGuildMembers(Guid guildId, bool track) => GetThroughCondition(x => x.GuildId.Equals(guildId), track).Include(y => y.HunterMembers).FirstOrDefault();

        public void CreateGuild(Guild gd) => Create(gd);
        public void UpdateGuild(Guild gd) => Update(gd);
        public void DeleteGuild(Guild gd) => Delete(gd);
    }
}

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
        public IEnumerable<Guild> GetAllGuild(bool track)
        {
            return GetAll(track).OrderBy(x => x.GuildName).ToList();
        }

        public Guild GetGuild(Guid guildId, bool track)
        {
            return GetThroughCondition(x => x.GuildId.Equals(guildId), track).FirstOrDefault();
        }
        //public Guild GetGuildMembers(Guid guildId, bool track) { 
            
        //}
    }
}

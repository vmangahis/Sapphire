using Sapphire.Entities.Models;
using Sapphire.Repository.Extensions.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;

namespace Sapphire.Repository.Extensions
{
    public static class GuildRepositoryExtension
    {
        public static IQueryable<Guild> FilterGuildNames(this IQueryable<Guild> guildList, string guildName)
        {
            if (string.IsNullOrWhiteSpace(guildName))
            {
                return guildList;
            }

            string lowercaseGuildName = guildName.ToLower();

            return guildList.Where(e => e.GuildName.ToLower().Contains(lowercaseGuildName));
        }

        public static IQueryable<Guild> Sort(this IQueryable<Guild> guildList, string orderByString)
        {
            if (string.IsNullOrWhiteSpace(orderByString))
                return guildList.OrderBy(e => e.GuildName);

            var query = OrderByQueryBuilder.CreateOrderByQuery<Guild>(orderByString);

            if (query is null)
                return guildList.OrderBy(e => e.GuildName);

            return guildList.OrderBy(query);

        }
    }
}

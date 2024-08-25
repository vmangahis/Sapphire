using Sapphire.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
using Sapphire.Repository.Extensions.Utility;

namespace Sapphire.Repository.Extensions
{
    public static class HunterRepositoryExtensions
    {
        public static IQueryable<Hunters> FilterHuntersRanks(this IQueryable<Hunters> hunters, uint MinRank, uint MaxRank) {
            return hunters.Where(e => (e.Rank >= MinRank && e.Rank <= MaxRank));
        }

        public static IQueryable<Hunters> Search(this IQueryable<Hunters> hunters, string SearchTerm)
        {
            if (string.IsNullOrWhiteSpace(SearchTerm))
            {
                return hunters;
            }

            string lowerCaseSearchTerm = SearchTerm.ToLower();

            return hunters.Where(e => e.HunterName.ToLower().Contains(lowerCaseSearchTerm));

        }
        public static IQueryable<Hunters> Sort(this IQueryable<Hunters> hunters, string orderBy)
        {
            if (string.IsNullOrWhiteSpace(orderBy))
            {
                return hunters.OrderBy(e => e.HunterName);
            }

            var orderString = OrderByQueryBuilder.CreateOrderByQuery<Hunters>(orderBy);
           

            if (string.IsNullOrWhiteSpace(query))
                return hunters.OrderBy(e => e.HunterName);
            
            return hunters.OrderBy(query);

        }
    }
}

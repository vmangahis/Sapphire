using Sapphire.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}

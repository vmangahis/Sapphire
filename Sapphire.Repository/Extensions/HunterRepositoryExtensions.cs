using Sapphire.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq.Dynamic.Core;
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
        public static IQueryable<Hunters> Sort(this IQueryable<Hunters> hunters, string orderBy)
        {
            if (string.IsNullOrWhiteSpace(orderBy))
            {
                return hunters.OrderBy(e => e.HunterName);
            }

            //Get the entity Hunters
            var hunterType = typeof(Hunters);

            //Split the string of the parameter by their ","
            var orderByParameter = orderBy.Trim().Split(",");

            var propertyInfo = hunterType.GetProperties(System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance);

            // String to be used to build the query through append
            var orderByBuilder = new StringBuilder();


            //iterate through the split string
            foreach (var order in orderByParameter)
            {
                if (string.IsNullOrWhiteSpace(order))
                    continue;

               //get the property name ("rank desc" would be evaluated to "rank")
                var propertyFromQueryName = order.Split(" ")[0];

                //get the property with the name of propertyFromQueryname
                var objectProp = propertyInfo.FirstOrDefault(p => p.Name.Equals(propertyFromQueryName, StringComparison.InvariantCultureIgnoreCase));

                if (objectProp is null)
                    continue;

                var direction = order.EndsWith(" desc") ? "descending" : "ascending";

                orderByBuilder.Append($"{objectProp.Name.ToString()} {direction}, ");
            }
            var query = orderByBuilder.ToString().TrimEnd(',', ' ');

            if (string.IsNullOrWhiteSpace(query))
                return hunters.OrderBy(e => e.HunterName);
            
            return hunters.OrderBy(query);

        }
    }
}

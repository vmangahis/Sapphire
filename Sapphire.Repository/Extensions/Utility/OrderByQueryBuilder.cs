using Sapphire.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sapphire.Repository.Extensions.Utility
{
    internal class OrderByQueryBuilder
    {
        public static string CreateOrderByQuery<T>(string orderByString)
        {
            //Get entity type
            var entityType = typeof(T);

            //Split the string of the parameter by their ","
            var orderByParameter = orderByString.Trim().Split(",");

            var propertyInfo = entityType.GetProperties(System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance);

            // String to be used to build the query through append
            var orderByBuilder = new StringBuilder();


            //iterate through the split string
            foreach (var order in orderByParameter)
            {
                if (string.IsNullOrWhiteSpace(order))
                    continue;

                //get the property name (e.g "rank desc" would be evaluated to "rank")
                var propertyFromQueryName = order.Split(" ")[0];

                //get the property with the name of propertyFromQueryname
                var objectProp = propertyInfo.FirstOrDefault(p => p.Name.Equals(propertyFromQueryName, StringComparison.InvariantCultureIgnoreCase));

                if (objectProp is null)
                    continue;

                var direction = order.EndsWith(" desc") ? "descending" : "ascending";

                orderByBuilder.Append($"{objectProp.Name.ToString()} {direction}, ");
            }
            var query = orderByBuilder.ToString().TrimEnd(',', ' ');
            return query;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sapphire.Shared.RequestFeatures
{
    public class PagedList<T> : List<T>
    {
        public MetaData MetaData { get; set; }
        public PagedList(List<T> Items, int Count, int PageNumber, int pageSize) {
            MetaData = new MetaData
            {
                TotalCount = Count,
                CurrentPage = PageNumber,
                PageSize = pageSize,
                TotalPages = (int)Math.Ceiling(Count/ (double) pageSize)
            };
            AddRange(Items);
        }

        public static PagedList<T> ToPagedList(IEnumerable<T> sourcedata, int pageNumber, int pageSize)
        {
            var count = sourcedata.Count();
            var items = sourcedata
                        .Skip((pageNumber - 1) * pageSize)
                        .Take(pageSize)
                        .ToList();

            return new PagedList<T>(items, count, pageNumber, pageSize);
        }
    }
}

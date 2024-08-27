using Sapphire.Contracts;
using Sapphire.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sapphire.Repository
{
    public class LocaleRepository : RepositoryBase<Locale>, ILocaleRepository
    {
        public LocaleRepository(RepositoryContext cont) : base(cont) { }
        public IEnumerable<Locale> GetAllHuntingLocale(bool track) {
            return Enumerable.Empty<Locale>();
        }

    }
}

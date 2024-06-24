using Sapphire.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sapphire.Contracts
{
    public interface ILocaleRepository
    {
         IEnumerable<Locale> GetAllHuntingLocale(bool track);
    }
}

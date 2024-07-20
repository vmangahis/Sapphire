using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sapphire.Entities.Models;

namespace Sapphire.Contracts
{
    public interface IHunterRepository
    {
         Task<IEnumerable<Hunters>> GetAllHuntersAsync(bool track);
         Task<Hunters> GetHunterAsync(Guid huntId, bool track);
         Task<Hunters> GetHunterByNameAsync(string hunterName, bool track);
         void CreateHunter(Hunters hunter);
         void DeleteHunter(Hunters hunter);
         void UpdateHunter(Hunters hunter);
    }
}

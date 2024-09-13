using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sapphire.Entities.Models;
using Sapphire.Shared;
using Sapphire.Shared.Parameters;
using Sapphire.Shared.RequestFeatures;

namespace Sapphire.Contracts
{
    public interface IHunterRepository
    {
         Task<PagedList<Hunters>> GetAllHuntersAsync(bool track, HunterParameters HunterParams);
         Task<Hunters> GetHunterAsync(Guid huntId, bool track);
         Task<Hunters> GetHunterByNameAsync(string hunterName, bool track);
         Task <IEnumerable<Hunters>> GetMultipleHuntersByNameAsync(IEnumerable<string> HunterNameList, bool TrackChanges);
        Task<IEnumerable<Hunters>> GetHuntersBySapphireUser(SapphireUser sapphireUser);
         void CreateHunter(Hunters hunter);
         void DeleteHunter(Hunters hunter);
         void UpdateHunter(Hunters hunter);
    }
}

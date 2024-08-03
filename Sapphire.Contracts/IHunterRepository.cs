using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sapphire.Entities.Models;
using Sapphire.Shared;
using Sapphire.Shared.DTO;

namespace Sapphire.Contracts
{
    public interface IHunterRepository
    {
         Task<IEnumerable<Hunters>> GetAllHuntersAsync(bool track, HunterParameters HunterParams);
         Task<Hunters> GetHunterAsync(Guid huntId, bool track);
         Task<Hunters> GetHunterByNameAsync(string hunterName, bool track);
        Task <IEnumerable<Hunters>> GetMultipleHuntersByNameAsync(IEnumerable<string> HunterNameList, bool TrackChanges);
         void CreateHunter(Hunters hunter);
         void DeleteHunter(Hunters hunter);
         void UpdateHunter(Hunters hunter);
    }
}

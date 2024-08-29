using Sapphire.Entities.Models;
using Sapphire.Shared.DTO;
using Sapphire.Shared.Parameters;
using Sapphire.Shared.RequestFeatures;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sapphire.Service.Contracts
{
    public interface IHunterService
    {
        Task<(IEnumerable<Entity> Hunters, MetaData metadata)> GetAllHuntersAsync(bool track, HunterParameters HunterParams);
        Task<(IEnumerable<HunterDTO> HunterLists, string HunterNames)> CreateMultipleHuntersAsync(IEnumerable<HunterCreationDTO> HunterListCreation);
        Task<IEnumerable<HunterDTO>> GetMultipleHuntersByNameAsync(IEnumerable<string> HunterNames, bool TrackChanges);
        Task<HunterDTO> GetHunterAsync(Guid huntId, bool track);
        Task<HunterDTO> CreateHunterAsync(HunterCreationDTO hunter);
        Task<HunterDTO> GetHunterByNameAsync(string HunterName, bool track);    
        Task<(HunterUpdateDTO hud, Hunters hunt)> GetHunterPatchAsync(string CurrentHunterName, bool TrackChanges);
        Task SaveHunterChangesPatchAsync(HunterUpdateDTO hud, Hunters hunt);
        Task DeleteHunterAsync(string HunterName, bool Track);
        Task DeleteHunterByIdAsync(Guid HunterId, bool Track);
        Task CheckDuplicateHunterAsync(string? HunterName, bool Track);
        Task UpdateHunterAsync(string CurrentHunterName, HunterUpdateDTO hud, bool TrackChanges);
    }
}

using Sapphire.Entities.Models;
using Sapphire.Shared.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sapphire.Service.Contracts
{
    public interface IHunterService
    {
        Task<IEnumerable<HunterDTO>> GetAllHuntersAsync(bool track);
        Task<HunterDTO> GetHunterAsync(Guid huntId, bool track);
        Task<HunterDTO> CreateHunterAsync(HunterCreationDTO hunter);
        Task<HunterDTO> GetHunterByNameAsync(string HunterName, bool track);    
        Task<(HunterUpdateDTO hud, Hunters hunt)> GetHunterPatchAsync(string CurrentHunterName, bool TrackChanges);
        Task SaveHunterChangesPatchAsync(HunterUpdateDTO hud, Hunters hunt);
        Task DeleteHunterAsync(string HunterName, bool Track);
        Task CheckDuplicateHunterAsync(string HunterName, bool Track);
        Task UpdateHunterAsync(string CurrentHunterName, HunterUpdateDTO hud, bool TrackChanges);
    }
}

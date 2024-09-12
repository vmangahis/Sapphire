using Sapphire.Entities.Models;
using Sapphire.Shared.DTO;
using Sapphire.Shared.Parameters;
using Sapphire.Shared.RequestFeatures;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Sapphire.Service.Contracts
{
    public interface IHunterService
    {
        Task<(IEnumerable<HunterDTO> Hunters, MetaData metadata)> GetAllHuntersAsync(bool trackChanges, HunterParameters HunterParams);
        Task<(IEnumerable<HunterDTO> HunterLists, string HunterNames)> CreateMultipleHuntersAsync(IEnumerable<HunterCreationDTO> HunterListCreation);
        Task<IEnumerable<HunterDTO>> GetMultipleHuntersByNameAsync(IEnumerable<string> HunterNames, bool trackChanges);
        Task<HunterDTO> GetHunterAsync(Guid huntId, bool trackChanges);
        Task<HunterDTO> CreateHunterAsync(HunterCreationDTO hunter, ClaimsPrincipal claimUser);
        Task<HunterDTO> GetHunterByNameAsync(string HunterName, bool trackChanges);    
        Task<(HunterUpdateDTO hud, Hunters hunt)> GetHunterPatchAsync(string CurrentHunterName, bool trackChanges);
        Task SaveHunterChangesPatchAsync(HunterUpdateDTO hud, Hunters hunt);
        Task DeleteHunterAsync(string HunterName, bool trackChanges);
        Task DeleteHunterByIdAsync(Guid HunterId, bool trackChanges);
        Task CheckDuplicateHunterAsync(string? HunterName, bool trackChanges);
        Task UpdateHunterAsync(string CurrentHunterName, HunterUpdateDTO hud, bool trackChanges);
        Task UpdateHunterByIdAsync(Guid hunterId, HunterUpdateDTO hud, bool trackChanges);
    }
}

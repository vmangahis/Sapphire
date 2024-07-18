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
        IEnumerable<HunterDTO> GetAllHunters(bool track);
        HunterDTO GetHunter(Guid huntId, bool track);
        HunterDTO CreateHunter(HunterCreationDTO hunter);
        HunterDTO GetHunterByName(string HunterName, bool track);    
        void DeleteHunter(string HunterName);
        void CheckDuplicateHunter(string HunterName, bool Track);
        void UpdateHunter(string CurrentHunterName, HunterUpdateDTO hud, bool TrackChanges);
        (HunterUpdateDTO hud, Hunters hunt) GetHunterPatch(string CurrentHunterName, bool TrackChanges);
        void SaveHunterChangesPatch(HunterUpdateDTO hud, Hunters hunt);
    }
}

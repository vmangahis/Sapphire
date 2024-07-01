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

        // should be username upon further implementations
        HunterDTO GetHunterByName(string hunterName, bool track);    
        void DeleteHunter(string huntername);
        void UpdateHunter(string CurrentHunterName, HunterUpdateDTO hud);
    }
}

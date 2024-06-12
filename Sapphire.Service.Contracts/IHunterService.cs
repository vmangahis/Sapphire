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
    }
}

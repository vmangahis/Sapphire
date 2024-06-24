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
         IEnumerable<Hunters> GetAllHunters(bool track);
         Hunters GetHunter(Guid huntId, bool track);
         Hunters GetHunterByName(string hunterName, bool track);
         void CreateHunter(Hunters hunter);
         void DeleteHunter(Hunters hunter);
         void UpdateHunter(Hunters hunter);
    }
}

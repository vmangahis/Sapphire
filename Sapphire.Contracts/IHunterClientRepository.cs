using Sapphire.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sapphire.Contracts
{
    public interface IHunterClientRepository
    {
        Task<HunterClient> GetHunterClientById(Guid hcId);
        void CreateHunterClient(HunterClient hc); 
    }
}

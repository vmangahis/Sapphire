using Sapphire.Contracts;
using Sapphire.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sapphire.Repository
{
    public class HunterClientRepository : RepositoryBase<HunterClient>,IHunterClientRepository
    {
       
        public HunterClientRepository(RepositoryContext repoCont): base(repoCont) { 
        
        }

        public void CreateHunterClient(HunterClient hc)
        {
            Create(hc);
        }
    }
}

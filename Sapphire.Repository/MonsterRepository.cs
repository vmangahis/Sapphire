using Sapphire.Contracts;
using Sapphire.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Sapphire.Repository
{
    public class MonsterRepository : RepositoryBase<Monsters>, IMonsterRepository
    {
        public MonsterRepository(RepositoryContext repContext) : base(repContext)
        {

        }
    }
}

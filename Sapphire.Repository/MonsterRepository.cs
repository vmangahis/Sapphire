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

        public IEnumerable<Monsters> GetAllMonsters(bool track) => GetAll(track).OrderBy(e => e.MonsterName);

        public Monsters GetMonster(Guid monId, bool track) => GetThroughCondition(x => x.Id.Equals(monId), track).SingleOrDefault();
    }
}

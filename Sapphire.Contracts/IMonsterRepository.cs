using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sapphire.Entities.Models;

namespace Sapphire.Contracts
{
    public interface IMonsterRepository
    {
        public IEnumerable<Monsters> GetAllMonsters(bool track);
    }
}

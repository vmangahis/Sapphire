using Sapphire.Contracts;
using Sapphire.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sapphire.Repository
{
    public class HunterRepository : RepositoryBase<Hunters>, IHunterRepository
    {
        public HunterRepository(RepositoryContext repContext) : base(repContext) { }

        public IEnumerable<Hunters> GetAllHunters(bool track) {
            return GetAll(track).OrderBy(x => x.HunterName).ToList();
        }
    }
}

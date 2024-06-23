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

        public Hunters GetHunter(Guid huntId, bool track) => GetThroughCondition(x => x.Id.Equals(huntId), track).SingleOrDefault();
        public Hunters GetHunterByName(string HunterName, bool track) => GetThroughCondition(x => x.HunterName.Equals(HunterName), track).SingleOrDefault();
        public void CreateHunter(Hunters hunt) => Create(hunt);
        public void DeleteHunter(Hunters hunt) => Delete(hunt);
        public void UpdateHunter(Hunters hunt) => Update(hunt);
    }
}

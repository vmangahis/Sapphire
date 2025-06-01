using Microsoft.EntityFrameworkCore;
using Sapphire.Contracts;
using Sapphire.Entities.Models;
using Sapphire.Repository.Extensions;
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

        public async Task<IEnumerable<Hunters>> GetHuntersBySapphireUser(SapphireUser sapphireUser)
        {
            var hunterSapphireOwner = await GetThroughCondition(e => (e.SapphireUser == sapphireUser), false).ToListAsync();
            return hunterSapphireOwner;
        }

        public async Task<IEnumerable<Hunters>> GetAllHuntersAsync(bool track)
        {
            var hunters = await GetAll(track).ToListAsync();

            return hunters;
        }

        public async Task<Hunters> GetHunterAsync(Guid huntId, bool track) { 
            var hunter = await GetThroughCondition(x => x.Id.Equals(huntId), track).Include(e => e.Guild).SingleOrDefaultAsync();
            return hunter ?? new Hunters { SapphireUser = new SapphireUser { } };
        }
        public async Task<Hunters> GetHunterByNameAsync(string HunterName, bool track) 
        {
            var hunter = await GetThroughCondition(x => x.HunterName.Equals(HunterName), track).FirstOrDefaultAsync();
            return hunter ?? new Hunters { SapphireUser = new SapphireUser { } };
        }
        public async Task<IEnumerable<Hunters>> GetMultipleHuntersByNameAsync(IEnumerable<string> HunterNameList, bool TrackChanges) => await GetThroughCondition(x => HunterNameList.Contains(x.HunterName), TrackChanges).ToListAsync();
        public void CreateHunter(Hunters hunt) => Create(hunt);
        public void DeleteHunter(Hunters hunt) => Delete(hunt);
        public void UpdateHunter(Hunters hunt) => Update(hunt);

        
    }
}

using Microsoft.EntityFrameworkCore;
using Sapphire.Contracts;
using Sapphire.Entities.Models;
using Sapphire.Repository.Extensions;
using Sapphire.Shared.Parameters;
using Sapphire.Shared.RequestFeatures;
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

        public async Task<PagedList<Hunters>> GetAllHuntersAsync(bool track, HunterParameters HunterParams)
        {
            var hunters =  await GetThroughCondition(e => (e.Rank >= HunterParams.MinRank && e.Rank < HunterParams.MaxRank),track)
            .FilterHuntersRanks(HunterParams.MinRank, HunterParams.MaxRank)
            .Search(HunterParams.SearchTerm ?? "")
            .Sort(HunterParams.OrderBy ?? "")
            .Include(e => e.Guild)
            .ToListAsync();

            return PagedList<Hunters>
                   .ToPagedList(hunters, HunterParams.PageNumber, HunterParams.PageSize);
        }

        public async Task<Hunters> GetHunterAsync(Guid huntId, bool track) => await GetThroughCondition(x => x.Id.Equals(huntId), track).Include(e => e.Guild).SingleOrDefaultAsync();
        public async Task<Hunters> GetHunterByNameAsync(string HunterName, bool track) => await GetThroughCondition(x => x.HunterName.Equals(HunterName), track).FirstOrDefaultAsync();
        public async Task<IEnumerable<Hunters>> GetMultipleHuntersByNameAsync(IEnumerable<string> HunterNameList, bool TrackChanges) => await GetThroughCondition(x => HunterNameList.Contains(x.HunterName), TrackChanges).ToListAsync();
        public void CreateHunter(Hunters hunt) => Create(hunt);
        public void DeleteHunter(Hunters hunt) => Delete(hunt);
        public void UpdateHunter(Hunters hunt) => Update(hunt);

        
    }
}

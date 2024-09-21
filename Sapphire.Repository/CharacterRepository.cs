using Microsoft.EntityFrameworkCore;
using Sapphire.Contracts;
using Sapphire.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sapphire.Repository
{
    public class CharacterRepository : RepositoryBase<Character>, ICharacterRepository
    {
        public CharacterRepository(RepositoryContext repoCont): base(repoCont) { }
        public void CreateCharacter(Character character) =>  Create(character);
        public async Task<IEnumerable<Character>> GetCharacterOwnerById(Guid saphUserId) => await GetThroughCondition(e => e.CharacterId == saphUserId, false).ToListAsync();
    }
}

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
        public async Task<IEnumerable<Character>> GetCharacterOwnerById(Guid saphUserId)
        {
           var characterUser =  await GetThroughCondition(e => e.User.Id == saphUserId.ToString(), false).Include(e => e.User).ToListAsync();
            return characterUser;
        }
        public async Task<Character> GetCharacter(Guid characterId) { 
            var character =await GetThroughCondition(e => e.CharacterId == characterId, false).Include(e => e.User).FirstOrDefaultAsync();
            return character ?? new Character {  User = new SapphireUser { } };
        }
    }
}

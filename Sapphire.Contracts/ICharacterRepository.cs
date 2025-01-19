using Sapphire.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sapphire.Contracts
{
    public interface ICharacterRepository
    {
        Task<IEnumerable<Character>> GetCharacterOwnerById(Guid saphUserId);
        Task<Character> GetCharacter(Guid characterId);
        void CreateCharacter(Character c);
    }
}

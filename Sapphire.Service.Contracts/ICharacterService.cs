using Sapphire.Entities.Models;
using Sapphire.Shared.Base;
using Sapphire.Shared.DTO.Character;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sapphire.Service.Contracts
{
    public interface ICharacterService
    {
        Task CreateCharacter(CharacterCreationDTO charDto, SapphireUser saphUser);
        Task<CharacterDTO> GetCharacter(Guid characterId);
        Task<bool> VerifyCharacter(SapphireUser saphUser, string characterId);
        Task<IEnumerable<CharacterDTO>> GetCharacterOfOwner(Guid characterId);
    }
}

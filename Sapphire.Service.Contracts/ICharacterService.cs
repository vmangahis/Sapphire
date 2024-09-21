using Sapphire.Entities.Models;
using Sapphire.Shared.Base;
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
        
    }
}

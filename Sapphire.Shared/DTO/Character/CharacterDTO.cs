using Sapphire.Shared.DTO.CharacterRole;
using Sapphire.Shared.DTO.SapphireUser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sapphire.Shared.DTO.Character
{
    public record CharacterDTO
    {
        public string? CharacterName { get; init; }
        public CharacterRoleDTO Role { get; init; }
        public SapphireUserDTO User { get; init; }
    }
}

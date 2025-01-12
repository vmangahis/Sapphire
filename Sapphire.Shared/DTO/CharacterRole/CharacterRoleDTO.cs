using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sapphire.Shared.DTO.CharacterRole
{
    public record CharacterRoleDTO
    {
        public required string RoleName { get; init; }
    }
}

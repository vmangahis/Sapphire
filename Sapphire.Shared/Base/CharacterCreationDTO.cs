using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sapphire.Shared.Base
{
    public record CharacterCreationDTO
    {
        public string CharacterName { get; init; }
        public Guid RoleId { get; init; }
    }
}

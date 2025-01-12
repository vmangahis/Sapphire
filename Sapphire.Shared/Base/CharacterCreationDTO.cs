using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sapphire.Shared.Base
{
    public record CharacterCreationDTO
    {
        [Required(ErrorMessage = "Please provide a character name.")]
        public required string CharacterName { get; init; }
        public Guid RoleId { get; init; }
    }
}

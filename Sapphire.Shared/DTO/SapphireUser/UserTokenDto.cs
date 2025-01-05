using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sapphire.Shared.DTO.SapphireUser
{
    public record UserTokenDto
    {
        public string? AccessToken { get; init; }
        public string? User { get; init; }

    }
}

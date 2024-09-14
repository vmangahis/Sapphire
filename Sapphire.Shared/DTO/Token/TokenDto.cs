using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sapphire.Shared.DTO.Token
{
    public record TokenDto(string AccessToken, string RefreshToken);
}

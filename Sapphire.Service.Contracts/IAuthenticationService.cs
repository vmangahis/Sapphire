using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Sapphire.Shared.DTO.SapphireUser;
using Sapphire.Shared.DTO.Token;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sapphire.Service.Contracts
{
    public interface IAuthenticationService
    {
        Task<IdentityResult> RegisterSapphireUser(SapphireUserForRegistrationDTO saphUserReg);
        Task<bool> ValidateSapphireUser(SapphireUserForAuthDTO saphUserAuth);
        Task<TokenDto> CreateToken(bool populateExp);
        Task<TokenDto> RefreshToken(TokenDto tokenDto);
        void SetTokenCookie(TokenDto tokenDto, HttpContext context);
    }
}

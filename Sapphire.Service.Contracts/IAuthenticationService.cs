using Microsoft.AspNetCore.Identity;
using Sapphire.Shared.DTO;
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
        Task<string> CreateToken();
    }
}

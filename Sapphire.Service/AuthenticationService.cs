using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Sapphire.Entities.Exceptions.NotFound;
using Sapphire.Entities.Models;
using Sapphire.Service.Contracts;
using Sapphire.Shared.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sapphire.Service
{
    internal sealed class AuthenticationService : IAuthenticationService
    {
        private readonly IMapper _mapper;
        private readonly UserManager<SapphireUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IConfiguration _config;

        public AuthenticationService(IMapper mapper, UserManager<SapphireUser> userManager, IConfiguration config, RoleManager<IdentityRole> roleManager)
        {
            _mapper = mapper;
            _userManager = userManager;
            _config = config;
            _roleManager = roleManager;
        }
        public async Task<IdentityResult> RegisterSapphireUser(SapphireUserForRegistrationDTO saphUserReg)
        {
            var user = _mapper.Map<SapphireUser>(saphUserReg);

            foreach (var role in saphUserReg.Roles)
            {
                var roleExists = await _roleManager.RoleExistsAsync(role);

                if (!roleExists)
                    throw new RoleNotFound(role);
                
            }

            var res = await _userManager.CreateAsync(user);

            if (res.Succeeded)
            {
                await _userManager.AddToRolesAsync(user, saphUserReg.Roles);
            }
            return res;
        }
    }
}

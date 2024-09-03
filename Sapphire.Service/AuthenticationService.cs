using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Sapphire.Entities.Exceptions.NotFound;
using Sapphire.Entities.Models;

using Sapphire.Service.Contracts;
using Sapphire.Shared.DTO;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
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
        private SapphireUser? _saphUser;

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
            var registerRoles = saphUserReg.Roles;              

            foreach (var role in saphUserReg.Roles)
            {
                var roleExists = await _roleManager.RoleExistsAsync(role);

                if (!roleExists)
                    throw new RoleNotFound(role);

            }

            var res = await _userManager.CreateAsync(user, saphUserReg.Password);

            if (res.Succeeded)
            {
                await _userManager.AddToRolesAsync(user, saphUserReg.Roles);
            }
            return res;
        }
        public async Task<bool> ValidateSapphireUser(SapphireUserForAuthDTO saphUserAuth)
        {
            _saphUser = await _userManager.FindByNameAsync(saphUserAuth.Username);

            var res = (_saphUser != null && await _userManager.CheckPasswordAsync(_saphUser, saphUserAuth.Password));
            if (!res)
            {
                Console.WriteLine("Auth Failed");
            }

            return res;
        }

        public async Task<TokenDto> CreateToken(bool populateExp)
        {
            var signCreds = GetSigningCredentials();
            var claims = await GetClaims();
            var tokenOpts = GenerateTokenOptions(signCreds, claims);

            var refreshToken = GenerateRefreshToken();

            _saphUser.RefreshToken = refreshToken;

            if (populateExp)
                _saphUser.RefreshTokenExpiry = DateTime.Now.AddDays(7);

            await _userManager.UpdateAsync(_saphUser);

            var accessToken =  new JwtSecurityTokenHandler().WriteToken(tokenOpts);

            return new TokenDto(accessToken, refreshToken);
        }

        private async Task<List<Claim>> GetClaims()
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, _saphUser.UserName)
            };

            var roles = await _userManager.GetRolesAsync(_saphUser);
            foreach (var role in roles) {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }
            return claims;
        }

        private SigningCredentials GetSigningCredentials()
        {
            var key = Encoding.UTF8.GetBytes(Environment.GetEnvironmentVariable("SUPERSECRET"));
            var secret = new SymmetricSecurityKey(key);

            return new SigningCredentials(secret, SecurityAlgorithms.HmacSha256);
        }
        private JwtSecurityToken GenerateTokenOptions(SigningCredentials signCreds, List<Claim> claims)
        {
            var jwtSets = _config.GetSection("JwtConfig");

            var tokenOpts = new JwtSecurityToken
            (
                issuer : jwtSets["validIssuer"],
                audience: jwtSets["validAudience"],
                claims: claims,
                expires: DateTime.Now.AddMinutes(Convert.ToDouble(jwtSets["expires"])),
                signingCredentials: signCreds

            );
            
            return tokenOpts;
        }
        private string GenerateRefreshToken()
        {
            var randNum = new byte[32];
            using(var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(randNum);
                return Convert.ToBase64String(randNum);
            }
        }
        private ClaimsPrincipal GetPrincipalFromExpiredAccess(string token)
        {
            var jwtSet = _config.GetSection("JwtConfig");

            var tokenValidationParams = new TokenValidationParameters
            {
                ValidateAudience = true,
                ValidateIssuer = true,
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Environment.GetEnvironmentVariable("SUPERSECRET"))),
                ValidateLifetime = true,
                ValidIssuer = jwtSet["validIssuer"],
                ValidAudience = jwtSet["validAudience"]
            };
            List<string> test = new List<string> { "test"};

            var tokenHandler = new JwtSecurityTokenHandler();
            SecurityToken securityToken;
            var principal = tokenHandler.ValidateToken(token, tokenValidationParams, out securityToken);

            var jwtSectToken = securityToken as JwtSecurityToken;
            if (jwtSectToken == null || !jwtSectToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256, StringComparison.InvariantCultureIgnoreCase))
            {
                throw new SecurityTokenException("Invalid token");
            }
            return principal;
        }
    }
}

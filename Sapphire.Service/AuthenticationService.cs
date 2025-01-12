using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Sapphire.Entities.ConfigurationModel;
using Sapphire.Entities.Exceptions.BadRequest;
using Sapphire.Entities.Exceptions.NotFound;
using Sapphire.Entities.Models;
using Sapphire.Service.Contracts;
using Sapphire.Shared.DTO.SapphireUser;
using Sapphire.Shared.DTO.Token;
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
        private readonly JwtConfig _jwtConfig;

        public AuthenticationService(IMapper mapper, UserManager<SapphireUser> userManager, IConfiguration config, RoleManager<IdentityRole> roleManager)
        {
            _mapper = mapper;
            _userManager = userManager;
            _config = config;
            _jwtConfig = new JwtConfig();
            _config.Bind(_jwtConfig.Section, _jwtConfig);
            _roleManager = roleManager;
        }
        public async Task<IdentityResult> RegisterSapphireUser(SapphireUserForRegistrationDTO saphUserReg)
        {
            var user = _mapper.Map<SapphireUser>(saphUserReg);
            var registerRoles = saphUserReg.Roles;              

            foreach (var role in saphUserReg.Roles!)
            {
                var roleExists = await _roleManager.RoleExistsAsync(role);

                if (!roleExists)
                    throw new RoleNotFound(role);

            }

            var res = await _userManager.CreateAsync(user, saphUserReg.Password!);

            if (res.Succeeded)
            {
                await _userManager.AddToRolesAsync(user, saphUserReg.Roles);
            }
            return res;
        }
        public async Task<bool> ValidateSapphireUser(SapphireUserForAuthDTO saphUserAuth)
        {
            _saphUser = await _userManager.FindByNameAsync(saphUserAuth.Username!);
            
            var res = (_saphUser != null && await _userManager.CheckPasswordAsync(_saphUser, saphUserAuth.Password!));
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
            var username = _saphUser!.UserName;

            _saphUser.RefreshToken = refreshToken;


            if (populateExp)
                _saphUser.RefreshTokenExpiry = DateTime.Now.AddDays(7);

            await _userManager.UpdateAsync(_saphUser);

            var accessToken =  new JwtSecurityTokenHandler().WriteToken(tokenOpts);

            return new TokenDto(accessToken, refreshToken, username);
        }
      public async Task<TokenDto> RefreshToken(TokenDto tokenDto)
        {
          /*var principal = GetPrincipalFromExpiredAccess(tokenDto.AccessToken);

            var user = await _userManager.FindByNameAsync(principal.Identity.Name);
            if (user == null || user.RefreshToken != tokenDto.RefreshToken || user.RefreshTokenExpiry <= DateTime.Now)
                throw new RefreshTokenBadRequest();

            _saphUser = user;*/

            return await CreateToken(populateExp: false);
        }

        private async Task<List<Claim>> GetClaims()
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, _saphUser!.UserName!)
            };

            var roles = await _userManager.GetRolesAsync(_saphUser);
            foreach (var role in roles) {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }
            return claims;
        }
        private SigningCredentials GetSigningCredentials()
        {
            var supersecret = Environment.GetEnvironmentVariable("SUPERSECRET");
            if(supersecret == null)
                throw new ArgumentNullException();

            var key = Encoding.UTF8.GetBytes(supersecret);
            var secret = new SymmetricSecurityKey(key);

            return new SigningCredentials(secret, SecurityAlgorithms.HmacSha256);
        }
        private JwtSecurityToken GenerateTokenOptions(SigningCredentials signCreds, List<Claim> claims)
        {

            var tokenOpts = new JwtSecurityToken
            (
                issuer : _jwtConfig.ValidIssuer,
                audience: _jwtConfig.ValidAudience,
                claims: claims,
                expires: DateTime.Now.AddMinutes(Convert.ToDouble(_jwtConfig.Expires)),
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
        /*private ClaimsPrincipal GetPrincipalFromExpiredAccess(string token)
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

            var tokenHandler = new JwtSecurityTokenHandler();
            SecurityToken securityToken;
            var principal = tokenHandler.ValidateToken(token, tokenValidationParams, out securityToken);

            var jwtSectToken = securityToken as JwtSecurityToken;
            if (jwtSectToken == null || !jwtSectToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256, StringComparison.InvariantCultureIgnoreCase))
            {
                throw new SecurityTokenException("Invalid token");
            }
            return principal;
        }*/

        public async Task<UserTokenDto> GetUserToken(SapphireUserForAuthDTO saphUserAuth, string AccessToken)
        {            
            _saphUser = await _userManager.FindByNameAsync(saphUserAuth.Username!);
            return new UserTokenDto { User = _saphUser?.UserName, AccessToken= AccessToken};
        }

        public void SetTokenCookie(TokenDto tokenDto, HttpContext context)
        {
            context.Response.Cookies.Append("sapphireAccess", tokenDto.AccessToken, new CookieOptions
            {
                Expires = DateTimeOffset.UtcNow.AddMinutes(5),
                HttpOnly = false,
                IsEssential = true,
                Secure = true,
                Domain = "localhost",
                SameSite = SameSiteMode.None
            });

            context.Response.Cookies.Append("sapphireRefresh", tokenDto.RefreshToken, new CookieOptions
            {
                Expires = DateTimeOffset.UtcNow.AddDays(7),
                HttpOnly = true,
                IsEssential = true,
                Secure = true,
                Domain = "localhost",
                SameSite = SameSiteMode.None
            });

            context.Response.Cookies.Append("sapphireId", _saphUser!.Id, new CookieOptions
            {
                Expires = DateTimeOffset.UtcNow.AddDays(7),
                HttpOnly = true,
                IsEssential = true,
                Secure = true,
                Domain = "localhost",
                SameSite = SameSiteMode.None
            });
        }

        public async Task<string> ValidateRefreshToken(string rfToken)
        {
            var user =  await _userManager.Users.Where(e => e.RefreshToken == rfToken).FirstOrDefaultAsync();
            var userName = user!.UserName;


            return userName ?? "";
        }

        public async Task<string> RegenerateAccessToken(string UserId)
        {
            _saphUser = await _userManager.FindByIdAsync(UserId);
            var signCreds = GetSigningCredentials();
            var claims = await GetClaims();
            var tokenOpts = GenerateTokenOptions(signCreds, claims);
            var newAccessToken = new JwtSecurityTokenHandler().WriteToken(tokenOpts);
            return newAccessToken;
        }

        public void RefreshAccessToken(string AccessToken, HttpContext cont) => cont.Response.Cookies.Append("sapphireAccess", AccessToken, new CookieOptions
        {
            Expires = DateTimeOffset.UtcNow.AddMinutes(5),
            HttpOnly = false,
            IsEssential = true,
            Secure = true,
            Domain = "localhost",
            SameSite = SameSiteMode.None
        });

        
    }
}

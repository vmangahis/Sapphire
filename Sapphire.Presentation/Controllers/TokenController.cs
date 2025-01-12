using Microsoft.AspNetCore.Mvc;
using Sapphire.Presentation.ActionFilters;
using Sapphire.Service.Contracts;
using Sapphire.Shared.DTO.Token;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sapphire.Presentation.Controllers
{
    [Route("api/token")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        private readonly IServiceManager _serv;

        public TokenController(IServiceManager serv) => _serv = serv;

        [HttpPost("refresh")]
        public async Task<ActionResult> RefreshToken()
        {
            HttpContext.Request.Cookies.TryGetValue("sapphireRefresh", out var refreshToken);
            HttpContext.Request.Cookies.TryGetValue("sapphireId", out string? sapphireUserId);

                //if refresh token is null then user is no longer authorized, needs relogin
            if (refreshToken is null || sapphireUserId is null) {
                    return Unauthorized();
            }
            var refreshTokenUser = await _serv.AuthenticationService.ValidateRefreshToken(refreshToken);

             if (refreshTokenUser is null)
                  return Unauthorized();



            //var tokenDto = new TokenDto(accessToken, refreshToken, null);
            //var tokenDtoVal = await _serv.AuthenticationService.CreateToken(populateExp: false);
            string newAccessToken = await _serv.AuthenticationService.RegenerateAccessToken(sapphireUserId);
            //var tokenDtoVal  = await _serv.AuthenticationService.RefreshToken(tokenDto);
            _serv.AuthenticationService.RefreshAccessToken(newAccessToken, HttpContext);
            return Ok(new {accessToken = newAccessToken, user = refreshTokenUser });
        }
    }
}

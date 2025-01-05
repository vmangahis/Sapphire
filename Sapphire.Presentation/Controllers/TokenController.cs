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
            HttpContext.Request.Cookies.TryGetValue("accessToken", out var accessToken);
            HttpContext.Request.Cookies.TryGetValue("refreshToken", out var refreshToken);

            var tokenDto = new TokenDto(accessToken, refreshToken, null);

            var tokenDtoVal  = await _serv.AuthenticationService.RefreshToken(tokenDto);
            _serv.AuthenticationService.SetTokenCookie(tokenDtoVal, HttpContext);
            return Ok(tokenDtoVal);
        }
    }
}

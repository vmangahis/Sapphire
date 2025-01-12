using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;
using Sapphire.Presentation.ActionFilters;
using Sapphire.Service.Contracts;
using Sapphire.Shared.DTO.SapphireUser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Sapphire.Presentation.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IServiceManager _serv;

        public AuthController(IServiceManager serv) { 
            _serv = serv;
        }

        [HttpPost("register")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<ActionResult> RegisterSapphireUser([FromBody] SapphireUserForRegistrationDTO sapphUser)
        {
            var res = await _serv.AuthenticationService.RegisterSapphireUser(sapphUser);

            if (!res.Succeeded)
            {
                foreach (var err in res.Errors)
                {
                    ModelState.TryAddModelError(err.Code, err.Description);
                }
                return BadRequest(ModelState);
            }

            return StatusCode(201);
            
        }
        [HttpPost("login")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<ActionResult> AuthenticateSapphire([FromBody] SapphireUserForAuthDTO saphAuth)
        {
            if(saphAuth == null)
                return BadRequest(ModelState);
            
            if (!await _serv.AuthenticationService.ValidateSapphireUser(saphAuth))
                return Unauthorized();
            
            var tokenDto = await _serv.AuthenticationService.CreateToken(populateExp: true);
            _serv.AuthenticationService.SetTokenCookie(tokenDto, HttpContext);
            var userTokenDto = await _serv.AuthenticationService.GetUserToken(saphAuth, tokenDto.AccessToken);
            return Ok(userTokenDto);
        }
        

    }
}

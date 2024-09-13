using Microsoft.AspNetCore.Mvc;
using Sapphire.Presentation.ActionFilters;
using Sapphire.Service.Contracts;
using Sapphire.Shared.DTO;
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
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<ActionResult> RefreshToken([FromBody]TokenDto tokenDto)
        {
            var tokenDtoVal  = await _serv.AuthenticationService.RefreshToken(tokenDto);

            return Ok(tokenDtoVal);
        }
    }
}

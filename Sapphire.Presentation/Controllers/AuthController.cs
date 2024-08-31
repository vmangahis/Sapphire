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
    [Route("api/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IServiceManager _serv;
        public AuthController(IServiceManager serv) => _serv = serv;

        [HttpPost]
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
    }
}

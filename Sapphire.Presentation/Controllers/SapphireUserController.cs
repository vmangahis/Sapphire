using Microsoft.AspNetCore.Authorization;
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
    [Route("api/sapphire")]
    [ApiController]
    public class SapphireUserController : ControllerBase
    {
        private readonly IServiceManager _serv;

        public SapphireUserController(IServiceManager serv)
        {
            _serv = serv;
        }
        [HttpPost("purge")]
        [Authorize(Roles = "Administrator")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<ActionResult> PurgeUser([FromBody] SapphireUserForPurgeDTO saphPurgeDto)
        {

            await _serv.SapphireUserService.PurgeUserAsync(saphPurgeDto);
            return NoContent();
        }
    }
}

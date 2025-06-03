using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Sapphire.Presentation.ActionFilters;
using Sapphire.Service.Contracts;
using Sapphire.Shared.Base;
using Sapphire.Shared.DTO.SapphireUser;
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
        [HttpPost("create")]
        public async Task<ActionResult> CreateUser([FromBody] SapphireCreationDTO scd)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Console.WriteLine("This is only a commit change for Wyvern Watch");
            return Ok();
        }
    }
}

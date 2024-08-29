using Asp.Versioning;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Sapphire.Entities.Exceptions.NotFound;
using Sapphire.Presentation.ActionFilters;
using Sapphire.Service.Contracts;
using Sapphire.Shared.DTO;
using Sapphire.Shared.Parameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Sapphire.Presentation.Controllers
{
    [ApiVersion(1.0)]
    [Route("api/[controller]")]
    [ApiController]
    public class HunterController : ControllerBase
    {
        private readonly IServiceManager _serv;

        public HunterController(IServiceManager serv) { 
            _serv = serv;
        }
        [HttpGet]
        public async Task<ActionResult> GetAllHunters([FromQuery] HunterParameters HunterParams) { 
            var huntersPaged = await _serv.HunterService.GetAllHuntersAsync(track: false, HunterParams);
            Console.WriteLine("v1");
            Response.Headers.Append("X-Pagination", JsonSerializer.Serialize(huntersPaged.metadata));
            return Ok(huntersPaged.Hunters);
        }
  
        }
    }

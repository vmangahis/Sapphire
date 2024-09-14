using Asp.Versioning;
using Marvin.Cache.Headers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.SignalR;
using Sapphire.Entities.Exceptions.NotFound;
using Sapphire.Presentation.ActionFilters;
using Sapphire.Service.Contracts;
using Sapphire.Shared.Parameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Security.Claims;
using Sapphire.Entities.Models;
using Sapphire.Shared.DTO.Hunter;

namespace Sapphire.Presentation.Controllers
{
    [Route("api/hunter")]
    [ApiController]
    public class HunterController : ControllerBase
    {
        private readonly UserManager<SapphireUser> _userManager;
        private readonly IServiceManager _serv;

        public HunterController(IServiceManager serv, UserManager<SapphireUser> userManager) { 
            _serv = serv;
            _userManager = userManager;
        }
        [HttpGet(Name = "GetAllHunters")]
        public async Task<ActionResult> GetAllHunters([FromQuery] HunterParameters HunterParams) { 
            var huntersPaged = await _serv.HunterService.GetAllHuntersAsync(trackChanges: false, HunterParams);
            Response.Headers.Append("X-Pagination", JsonSerializer.Serialize(huntersPaged.metadata));
            return Ok(huntersPaged.Hunters);
        }

        [HttpGet("{hnid:guid}", Name="GetHunterById")]
        public async Task<ActionResult> GetSingleHunter(Guid hnid) {
            var hunter = await _serv.HunterService.GetHunterAsync(hnid, trackChanges: false);
            return Ok(hunter);
        }
        [HttpGet("multiple/{HunterNames}", Name = "GetMultipleHunters")]
        public async Task<ActionResult> GetMultipleHunters(IEnumerable<string>HunterNames)
        {
            var HunterList = await _serv.HunterService.GetMultipleHuntersByNameAsync(HunterNames, trackChanges: false);
            return Ok(HunterList);

        }
        [HttpPost("multiple")]
        public async Task<ActionResult> CreateMultipleHunters([FromBody] IEnumerable<HunterCreationDTO> HunterForCreation)
        {
            var res = await _serv.HunterService.CreateMultipleHuntersAsync(HunterForCreation);
            return CreatedAtRoute("GetMultipleHunters", new { res.HunterNames }, res.HunterLists);
        }
        [HttpPost]
        [Authorize]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<ActionResult> AddHunter([FromBody]HunterCreationDTO hn) {
            await _serv.HunterService.CheckDuplicateHunterAsync(hn.HunterName, trackChanges: false);
            var hnObject = await _serv.HunterService.CreateHunterAsync(hn);
           
            return CreatedAtRoute("GetHunterById", new { hnid = hnObject.Id }, hnObject);
        }
        [HttpDelete("{huntername}")]
        public async Task<ActionResult> DeleteHunter(string huntername) {
            await _serv.HunterService.DeleteHunterAsync(huntername, trackChanges: false);
            return NoContent();
        }
        [HttpDelete("{hunterid:guid}")]
        public async Task<ActionResult> DeleteHunterById(Guid hunterid)
        {
            await _serv.HunterService.DeleteHunterByIdAsync(hunterid, trackChanges: false);
            return NoContent();
        }
        [HttpPut("{huntername}")]
        public async Task<ActionResult> UpdateHunter(string huntername,HunterUpdateDTO hud) {
            if (!ModelState.IsValid)
                return UnprocessableEntity(ModelState);

            await _serv.HunterService.UpdateHunterAsync(huntername, hud, trackChanges: true);
            return NoContent();
        }
        [HttpPut("{hunterId:guid}")]
        public async Task<ActionResult> UpdateHunterById(Guid hunterId, HunterUpdateDTO hud)
        {
            if(!ModelState.IsValid)
                return UnprocessableEntity(ModelState);

            await _serv.HunterService.UpdateHunterByIdAsync(hunterId, hud, trackChanges: true);
            return NoContent();
        }

        [HttpPatch("{HunterName}")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<ActionResult> PartialUpdateHunter(string HunterName,[FromBody] JsonPatchDocument<HunterUpdateDTO> patchHunter) {
            
            var res = await _serv.HunterService.GetHunterPatchAsync(HunterName, trackChanges: true);
            var nameValidation = patchHunter.Operations.Where(e => e.path.ToUpper().Equals("/HUNTERNAME"))
                                                       .Where(e => e.op.ToUpper().Equals("REPLACE")).FirstOrDefault();

            if(nameValidation is not null)
                await _serv.HunterService.CheckDuplicateHunterAsync(nameValidation?.value.ToString(), trackChanges: false);

            patchHunter.ApplyTo(res.hud, ModelState);            

            await _serv.HunterService.SaveHunterChangesPatchAsync(res.hud, res.hunt);

            return NoContent();
        }
    }
}

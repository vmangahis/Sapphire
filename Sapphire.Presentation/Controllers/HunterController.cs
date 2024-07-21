using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Sapphire.Entities.Exceptions.NotFound;
using Sapphire.Presentation.ActionFilters;
using Sapphire.Service.Contracts;
using Sapphire.Shared.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Sapphire.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HunterController : ControllerBase
    {
        private readonly IServiceManager _serv;

        public HunterController(IServiceManager serv) { 
            _serv = serv;
        }
        [HttpGet]
        public async Task<ActionResult> GetAllHunters() { 
               var hunters = await _serv.HunterService.GetAllHuntersAsync(track: false);
                return Ok(hunters);
        }

        [HttpGet("{hnid:guid}", Name="GetHunterById")]
        public async Task<ActionResult> GetSingleHunter(Guid hnid) {
            var hunter = await _serv.HunterService.GetHunterAsync(hnid, track: false);
            return Ok(hunter);
        }
        [HttpPost]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<ActionResult> AddHunter([FromBody]HunterCreationDTO hn) {
            await _serv.HunterService.CheckDuplicateHunterAsync(hn.HunterName, Track: false);
            var hnObject = await _serv.HunterService.CreateHunterAsync(hn);

            
            return CreatedAtRoute("GetHunterById", new { hnid = hnObject.Id }, hnObject);
        }
        [HttpDelete("{huntername}")]
        public async Task<ActionResult> DeleteHunter(string huntername) {
            await _serv.HunterService.DeleteHunterAsync(huntername);
            return NoContent();
        }
        [HttpPut("{huntername}")]
        public async Task<ActionResult> UpdateHunter(string huntername,HunterUpdateDTO hud) {
            if (!ModelState.IsValid)
                return UnprocessableEntity(ModelState);

            await _serv.HunterService.CheckDuplicateHunterAsync(hud.HunterName, Track: false);

            await _serv.HunterService.UpdateHunterAsync(huntername, hud, TrackChanges:true);
            return NoContent();
        }

        [HttpPatch("{HunterName}")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<ActionResult> PartialUpdateHunter(string HunterName,[FromBody] JsonPatchDocument<HunterUpdateDTO> patchHunter) {
            
            var res = await _serv.HunterService.GetHunterPatchAsync(HunterName, TrackChanges: true);

            patchHunter.ApplyTo(res.hud, ModelState);

            string newHunterName = res.hud.HunterName;

            await _serv.HunterService.CheckDuplicateHunterAsync(newHunterName, Track: false);

            await _serv.HunterService.SaveHunterChangesPatchAsync(res.hud, res.hunt);

            return NoContent();
        }
    }
}

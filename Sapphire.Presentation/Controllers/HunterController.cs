using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Sapphire.Entities.Exceptions.NotFound;
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
        public ActionResult GetAllHunters() { 
               var hunters = _serv.HunterService.GetAllHunters(track: false);
                return Ok(hunters);
        }

        [HttpGet("{hnid:guid}", Name="GetHunterById")]
        public ActionResult GetSingleHunter(Guid hnid) {
            var hunter = _serv.HunterService.GetHunter(hnid, track: false);
            return Ok(hunter);
        }
        [HttpPost]
        public ActionResult AddHunter([FromBody]HunterCreationDTO hn) {
            if (!ModelState.IsValid)
            {
                return UnprocessableEntity(ModelState);
            }
            var hnObject = _serv.HunterService.CreateHunter(hn);

            
            return CreatedAtRoute("GetHunterById", new { hnid = hnObject.Id }, hnObject);
        }
        [HttpDelete("{huntername}")]
        public ActionResult DeleteHunter(string huntername) {
            _serv.HunterService.DeleteHunter(huntername);
            return NoContent();
        }
        [HttpPut("{huntername}")]
        public ActionResult UpdateHunter(string huntername,HunterUpdateDTO hud) {
            if (!ModelState.IsValid)
                return UnprocessableEntity(ModelState);

            _serv.HunterService.UpdateHunter(huntername, hud, TrackChanges:true);
            return NoContent();
        }

        [HttpPatch("{HunterName}")]
        public ActionResult PartialUpdateHunter(string HunterName,[FromBody] JsonPatchDocument<HunterUpdateDTO> patchHunter) {
            if (patchHunter is null) {
                return BadRequest("Patch request body is null");
            }

            var res = _serv.HunterService.GetHunterPatch(HunterName, TrackChanges: true);

            patchHunter.ApplyTo(res.hud, ModelState);

            if (!ModelState.IsValid)
                return UnprocessableEntity(ModelState);

            string newHunterName = res.hud.HunterName;

            _serv.HunterService.CheckDuplicateHunter(newHunterName, Track: false);

            _serv.HunterService.SaveHunterChangesPatch(res.hud, res.hunt);

            return NoContent();
        }
    }
}

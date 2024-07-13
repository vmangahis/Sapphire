using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Sapphire.Service.Contracts;
using Sapphire.Shared.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sapphire.Presentation.Controllers
{
    [Route("api/guilds/")]
    [ApiController]
    public class GuildController : ControllerBase
    {
        private readonly IServiceManager _serv;
        public GuildController(IServiceManager serv) {
            _serv = serv;
        }

        [HttpGet]
        public ActionResult GetGuild() {
            var gd = _serv.GuildService.GetAllGuild(track: false);
            return Ok(gd);
        }
        [HttpPost]
        public ActionResult CreateGuild([FromBody] GuildCreationDTO gddto) {
  
            var gc = _serv.GuildService.CreateGuild(gddto);
            return Ok(gddto);
        }
        [HttpGet("{gid:guid}")]
        public ActionResult GetSingleGuild(Guid gid) {
            var gd = _serv.GuildService.GetSingleGuild(gid, track: false);
            return Ok(gd);
        
        }
        [HttpGet("{gid:guid}/members")]
        public ActionResult GetGuildMembers(Guid gid)
        {
           var gd = _serv.GuildService.GetGuildMembers(gid, track: false);
           return Ok(gd);
        }
        [HttpPut("{GuildName}/update")]
        public ActionResult UpdateGuild(string GuildName, GuildUpdateDTO gdto) {
            _serv.GuildService.UpdateGuild(GuildName, gdto,track: true);
            return NoContent();
        }
        [HttpPatch("{GuildName}/patch")]
        public ActionResult PartialUpdateGuild(string GuildName, [FromBody] JsonPatchDocument<GuildUpdateDTO> jsonPatchGuild) {
            if (jsonPatchGuild is null) {
                return BadRequest("Guild PATCH requestb body is null");
            }
            var partialUpdateGuild = _serv.GuildService.PartialUpdateGuild(GuildName, track: true);
            jsonPatchGuild.ApplyTo(partialUpdateGuild.gdto);
            _serv.GuildService.SaveGuildPatch(partialUpdateGuild.gdto, partialUpdateGuild.guild);
            return NoContent();
        }
        [HttpDelete("{GuildName}/delete")]
        public ActionResult DeleteGuild(string GuildName) {
            _serv.GuildService.DeleteGuild(GuildName, track: false);
            return NoContent();
        }
        

    }
}

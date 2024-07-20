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
        public async Task<ActionResult> GetGuildAsync() {
            var gd = await _serv.GuildService.GetAllGuildAsync(track: false);
            return Ok(gd);
        }
        [HttpPost]
        public async Task<ActionResult> CreateGuildAsync([FromBody] GuildCreationDTO gddto) {
            if (!ModelState.IsValid) { 
                return UnprocessableEntity(ModelState);
            }
            await _serv.GuildService.CheckDuplicateGuildAsync(gddto.GuildName, track: false);
            var gc = _serv.GuildService.CreateGuildAsync(gddto);
            return Ok(gddto);
        }
        [HttpGet("{gid:guid}")]
        public async Task<ActionResult> GetSingleGuildAsync(Guid gid) {
            var gd = await _serv.GuildService.GetSingleGuildAsync(gid, track: false);
            return Ok(gd);
        
        }
        [HttpGet("{gid:guid}/members")]
        public async Task<ActionResult> GetGuildMembersAsync(Guid gid)
        {
           var gd = await _serv.GuildService.GetGuildMembersAsync(gid, track: false);
           return Ok(gd);
        }
        [HttpPut("{GuildName}/update")]
        public async Task<ActionResult> UpdateGuildAsync(string GuildName, GuildUpdateDTO gdto) {

            if(!ModelState.IsValid)
                return UnprocessableEntity(ModelState);

            await _serv.GuildService.CheckDuplicateGuildAsync(gdto.GuildName, track: false);

            await _serv.GuildService.UpdateGuildAsync(GuildName, gdto,track: true);
            return NoContent();
        }
        [HttpPatch("{GuildName}/patch")]
        public async Task<ActionResult> PartialUpdateGuildAsync(string GuildName, [FromBody] JsonPatchDocument<GuildUpdateDTO> jsonPatchGuild) {
            if (jsonPatchGuild is null) {
                return BadRequest("Guild PATCH request body is null");
            }
            var partialUpdateGuild = await _serv.GuildService.PartialUpdateGuildAsync(GuildName, track: true);
            
            jsonPatchGuild.ApplyTo(partialUpdateGuild.gdto, ModelState);

            if (!ModelState.IsValid)
                return UnprocessableEntity(ModelState);

            string newGuildName = partialUpdateGuild.gdto.GuildName;

            await _serv.GuildService.CheckDuplicateGuildAsync(newGuildName, track: false);

            await _serv.GuildService.SaveGuildPatchAsync(partialUpdateGuild.gdto, partialUpdateGuild.guild);
            return NoContent();
        }
        [HttpDelete("{GuildName}/delete")]
        public async Task<ActionResult> DeleteGuildAsync(string GuildName) {
            await _serv.GuildService.DeleteGuildAsync(GuildName, track: false);
            return NoContent();
        }
        

    }
}

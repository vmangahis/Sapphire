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
        [HttpPut("{guildname}/update")]
        public ActionResult UpdateGuild(string guildname, GuildUpdateDTO gdto) {
            _serv.GuildService.UpdateGuild(guildname, gdto,track: true);
            return NoContent();
        }

    }
}

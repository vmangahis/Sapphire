using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Sapphire.Service.Contracts;
using Sapphire.Service;
using Sapphire.Shared.DTO;
using Sapphire.Presentation.ActionFilters;

namespace Sapphire.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MonsterController : ControllerBase
    {
        private readonly IServiceManager _servmanager;
        public MonsterController(IServiceManager servman) => _servmanager = servman;

        [HttpGet]
        public ActionResult GetAllMonsters()
        {
            var mon = _servmanager.MonsterService.GetAllMonsters(track: false);
            return Ok(mon);
        }
        [HttpGet("{monid:guid}")]
        public ActionResult GetSingleMonster(Guid monid) {
            var mon = _servmanager.MonsterService.GetMonster(monid, track: false);
            return Ok(mon);
        }
        [HttpPost]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<ActionResult> AddSingleMonster([FromBody]MonsterCreationDTO MonsterDTO)
        {
            var monstercreate = await _servmanager.MonsterService.CreateMonster(MonsterDTO);
            return Ok(monstercreate);
        }
    }
}

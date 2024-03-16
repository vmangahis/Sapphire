using Microsoft.AspNetCore.Mvc;
using Sapphire.Data;

namespace Sapphire.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MonstersController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly AppDbContext _monstercont;
        public MonstersController(IConfiguration conf, AppDbContext monstercont)
        {
            _configuration = conf;
            _monstercont = monstercont;
            
        }

        [HttpGet(Name ="AllMonsters")]
        [Route("GetAll")]
        public ActionResult GetAllMonsters() {
            var mons = _monstercont.T_monsters.ToList();
            return Ok(mons);
        }

        [HttpGet(Name ="SingleMonster")]
        [Route("GetSingleMonster")]
        public ActionResult GetSingleMonster([FromQuery(Name ="id")] Guid id) {
            var mon = _monstercont.T_monsters.Find(id);
            return Ok(mon);
        }


        
    }
}

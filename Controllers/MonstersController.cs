using Microsoft.AspNetCore.Mvc;
using Sapphire.Data;
using Sapphire.DTO.Monster;
using Sapphire.Mappers;

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

        [HttpGet]
        [Route("GetAll")]
        public ActionResult GetAllMonsters() {
            var mons = _monstercont.T_monsters.ToList();
            return Ok(mons);
        }

        [HttpGet]
        [Route("GetSingleMonster")]
        public ActionResult GetSingleMonster([FromQuery(Name = "MonsterName")] string MonsterName) {
            var mon = _monstercont.T_monsters.FirstOrDefault(el => el.MonsterName.Equals(MonsterName));
            return Ok(mon);
        }

        [HttpPost]
        [Route("AddMonster")]
        public ActionResult AddMonster([FromBody] AddMonsterDTO addMonDTO) {
            var monModel = addMonDTO.ToMonsterAddMonsterDTO();
            _monstercont.Add(monModel);
            _monstercont.SaveChanges();
            return CreatedAtAction(nameof(GetSingleMonster), new { id = monModel.Id, MonsterName = monModel.MonsterName });
        }

        [HttpPatch]
        [Route("UpdateMonster/{monsterId}")]
        public ActionResult UpdateMonster([FromRoute] Guid monsterId, [FromBody] EditMonsterDTO ed) {
           var existingMonster = _monstercont.T_monsters.FirstOrDefault(el => el.Id == monsterId);
            if (existingMonster == null){
                return NotFound(":(");
            }
            existingMonster.MonsterName = ed.MonsterName;
            existingMonster.HealthPool = ed.HealthPool;
            existingMonster.BaseAttack = ed.BaseAttack;
            existingMonster.BaseDefense = ed.BaseDefense;
            _monstercont.SaveChanges();
            return Ok();
        }

        [HttpDelete]
        [Route("DeleteMonster/{monsterId}")]
        public ActionResult DeleteMonster([FromRoute] Guid monsterId) {
            var monsterModel = _monstercont.T_monsters.FirstOrDefault(s => s.Id == monsterId);
            if(monsterModel == null)
            {
                return NotFound();
            }
            _monstercont.T_monsters.Remove(monsterModel);
            _monstercont.SaveChanges();
            return NoContent();
        }
        


        
    }
}

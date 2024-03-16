using Microsoft.AspNetCore.Mvc;
using Sapphire.Data;

namespace Sapphire.Controllers
{
    [ApiController]
    [Route("[controller]")]
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
        public ActionResult GetAllMonsters() {
            var mons = _monstercont.T_monsters.ToList();
            return Ok(mons);
        }


        
    }
}

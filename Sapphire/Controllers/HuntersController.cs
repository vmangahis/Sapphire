using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Sapphire.Data;
using System.Linq;

namespace Sapphire.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class HuntersController : ControllerBase
    {
        private readonly IConfiguration _conf;
        private readonly AppDbContext _cont;

        public HuntersController(IConfiguration con, AppDbContext cont) {
            _conf = con;
            _cont = cont;
        }

        [HttpGet]
        public ActionResult GetAllHunters() {
            var hunt = _cont.T_hunters.ToList();
            return Ok(hunt);
        }
    }
}

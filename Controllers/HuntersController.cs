using Microsoft.AspNetCore.Mvc;
using Sapphire.Data;

namespace Sapphire.Controllers
{
    public class HuntersController : ControllerBase
    {
        private readonly IConfiguration _conf;
        private readonly AppDbContext _cont;

        public HuntersController(IConfiguration con, AppDbContext cont) {
            _conf = con;
            _cont = cont;
        }
    }
}

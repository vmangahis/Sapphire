using Microsoft.AspNetCore.Mvc;
using Sapphire.Service.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public ActionResult GetAllHunters() {
            try
            {
               var hunters = _serv.HunterService.GetAllHunters(track: false);
                return Ok(hunters);
            }
            catch (Exception ex) {
                Console.WriteLine(ex);
                throw;
            }
        }
    }
}

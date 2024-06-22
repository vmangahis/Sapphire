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
    [Route("api/[controller]")]
    [ApiController]
    public class HunterController : ControllerBase
    {
        private readonly IServiceManager _serv;

        public HunterController(IServiceManager serv) { 
            _serv = serv;
        }
        [HttpGet]
        public ActionResult GetAllHunters() { 
               var hunters = _serv.HunterService.GetAllHunters(track: false);
                return Ok(hunters);
        }

        [HttpGet("{hnid:guid}", Name="GetHunterById")]
        public ActionResult GetSingularHunter(Guid hnid) {
            var hunter = _serv.HunterService.GetHunter(hnid, track: false);
            return Ok(hunter);
        }
        [HttpPost]
        public ActionResult AddHunter([FromBody]HunterCreationDTO hn) {
            var hnObject = _serv.HunterService.CreateHunter(hn);
            return CreatedAtRoute("GetHunterById", new { hnid = hnObject.Id }, hnObject);
        }
    }
}

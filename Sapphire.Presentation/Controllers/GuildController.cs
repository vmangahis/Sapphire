using Microsoft.AspNetCore.Mvc;
using Sapphire.Service.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sapphire.Presentation.Controllers
{
    public class GuildController : ControllerBase
    {
        private readonly IServiceManager _serv;
        public GuildController(IServiceManager serv) { 
            _serv = serv;
        }

        public ActionResult GetGuild() { 
        
        }
    }
}

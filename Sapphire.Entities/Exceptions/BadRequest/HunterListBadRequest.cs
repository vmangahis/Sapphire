using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sapphire.Entities.Exceptions.BadRequest
{
    public sealed class HunterListBadRequest : BadRequestException { 
        public HunterListBadRequest(): base("Hunter list is empty or null.") { }
    }
}

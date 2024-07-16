using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sapphire.Entities.Exceptions.BadRequest
{
    public sealed class HunterNameBlankException : BadRequestException {
        public HunterNameBlankException() : base("Hunter name is blank.") { }
    }
    
}

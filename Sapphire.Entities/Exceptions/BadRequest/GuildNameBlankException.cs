using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sapphire.Entities.Exceptions.BadRequest
{
    public sealed class GuildNameBlankException : BadRequestException { 
    
        public GuildNameBlankException() : base("Guild name is blank or null.") { }
    }
}

using Sapphire.Entities.Exceptions.BadRequest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sapphire.Entities.Exceptions.NotFound
{
    public class SapphireUserNotFound : BadRequestException{
        public SapphireUserNotFound(string user) : base($"User {user} not found") { }
    
    }
}

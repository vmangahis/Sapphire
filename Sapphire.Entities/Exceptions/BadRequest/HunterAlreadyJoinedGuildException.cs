using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sapphire.Entities.Exceptions.BadRequest
{
    public sealed class HunterAlreadyJoinedGuildException : BadRequestException   {
        public HunterAlreadyJoinedGuildException(string huntername) : base($"Hunter \'{huntername}\' already joined a guild.") { }
    }
}

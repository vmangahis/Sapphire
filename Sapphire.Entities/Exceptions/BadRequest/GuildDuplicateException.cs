using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sapphire.Entities.Exceptions.BadRequest
{
    public sealed class GuildDuplicateException : BadRequestException
    {
        public GuildDuplicateException(string gd): base($"The guild \'{gd}\' already exists!") { }
    }
}

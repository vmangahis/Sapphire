using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sapphire.Entities.Exceptions.NotFound
{
    public sealed class GuildNotFound : NotFoundException
    {
        public GuildNotFound(string GuildName) : base($"Guild - {GuildName} does not exist.") { }
    }
}

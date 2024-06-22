using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sapphire.Entities.Exceptions.NotFound
{
    public sealed class HunterNotFoundException : NotFoundException
    {
        public HunterNotFoundException(string nm) : base($"Hunter \'{nm}\' does not exist.") { }
    }
}

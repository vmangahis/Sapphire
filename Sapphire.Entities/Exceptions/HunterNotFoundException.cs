using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sapphire.Entities.Exceptions
{
    public sealed class HunterNotFoundException : NotFoundException
    {
        public HunterNotFoundException(Guid hnguid) : base($"Hunter with ID: {hnguid} is not found") { }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sapphire.Entities.Exceptions.NotFound
{
    public sealed class RoleNotFound : NotFoundException
    {
        public RoleNotFound(string msg) : base($"Role '{msg}' not found.") { }
    }
}

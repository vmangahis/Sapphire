using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sapphire.Entities.Exceptions.BadRequest
{
    public sealed class MaxHunterCreationException : BadRequestException
    {
        public MaxHunterCreationException() : base("Max hunter created.") { }
    }
}

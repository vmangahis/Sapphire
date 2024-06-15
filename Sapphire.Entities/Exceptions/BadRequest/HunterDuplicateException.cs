using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sapphire.Entities.Exceptions.BadRequest
{
    public sealed class HunterDuplicateException : BadRequestException
    {
        public HunterDuplicateException(string HunterName) : base($"Hunter name already exists. Please try another name.") { }
    }
}

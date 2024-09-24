using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sapphire.Entities.Exceptions.BadRequest
{
    public sealed class GenericBadRequest : BadRequestException
    {
        public GenericBadRequest(string message) : base(message) { }
    }
}

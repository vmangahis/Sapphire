using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sapphire.Entities.Exceptions.BadRequest
{
    public sealed class MaxCharacterCreation : BadRequestException
    {
        public MaxCharacterCreation() : base("Reached limit of character creation."){ }
    }
}

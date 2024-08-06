using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sapphire.Entities.Exceptions.BadRequest
{
    public sealed class MaxHunterRankRequestException : BadRequestException
    {
        public MaxHunterRankRequestException (): base("Hunter rank parameter is invalid."){}
    }
}

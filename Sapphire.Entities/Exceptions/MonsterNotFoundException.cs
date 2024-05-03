using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sapphire.Entities.Exceptions
{
    public sealed class MonsterNotFoundException : NotFoundException
    {
        public MonsterNotFoundException(Guid monId) : base($"Monster ID {monId} - Not Found")
        { 
            
        }
    }
}

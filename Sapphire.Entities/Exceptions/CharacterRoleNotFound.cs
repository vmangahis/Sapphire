using Sapphire.Entities.Exceptions.BadRequest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sapphire.Entities.Exceptions
{
    public sealed class CharacterRoleNotFound: BadRequestException
    {
        public CharacterRoleNotFound(string message) : base(message) { }
}

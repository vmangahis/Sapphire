using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sapphire.Shared.DTOBase;

namespace Sapphire.Shared.DTO.Hunter
{
    public record HunterUpdateDTO : HunterForModificationDTO
    {
        public int? Rank { get; init; }
    }
}

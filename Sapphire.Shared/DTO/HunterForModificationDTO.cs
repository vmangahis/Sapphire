using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sapphire.Shared.DTO
{
    public abstract record HunterForModificationDTO {
        [Required(ErrorMessage = "Please provide a hunter name.")]
        [MaxLength(20, ErrorMessage = "Max length for Hunter Name is 20.")]
        public string HunterName { get; init; }
    }
}

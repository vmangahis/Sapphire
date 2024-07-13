using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sapphire.Shared.DTO
{
    public record HunterCreationDTO {
        
        [Required(ErrorMessage = "Please provide a hunter name.")]
        [MaxLength(10, ErrorMessage = "Max length for Hunter Name is 10.")]
        public string HunterName { get; init; }
    }
}

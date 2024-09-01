using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sapphire.Shared.DTO
{
    public record SapphireUserForAuthDTO
    {
        [Required(ErrorMessage = "Username is required to login.")]
        public string? Username { get; init; }
        [Required(ErrorMessage = "Password is required.")]
        public string? Password { get; init; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sapphire.Shared.DTO
{
    public record SapphireUserForRegistrationDTO
    {
        public string? FirstName { get; init; }
        public string? LastName { get; init; }
        [Required(ErrorMessage = "Username required.")]
        public string? Username { get; init; }
        [Required(ErrorMessage = "Password required.")]
        public string? Password { get; init; }
        public string? Email { get; init; }
        public string? MobileNumber { get; init; }
        public ICollection<string>? Roles { get; init; }
    }
}

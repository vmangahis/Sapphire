using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sapphire.Shared.DTO.SapphireUser
{
    public record SapphireUserForRegistrationDTO
    {
        [Required(ErrorMessage = "First name is required.")]
        public string? FirstName { get; init; }
        [Required(ErrorMessage = "Last name is required.")]
        public string? LastName { get; init; }
        [Required(ErrorMessage = "Username required.")]
        public string? Username { get; init; }
        [Required(ErrorMessage = "Password required.")]
        public string? Password { get; init; }
        [Required(ErrorMessage = "Email required.")]
        public string? Email { get; init; }
        [Required(ErrorMessage = "Mobile Number required.")]
        public string? MobileNumber { get; init; }
        [Required(ErrorMessage = "Please provide a role.")]
        public ICollection<string>? Roles { get; init; }
    }
}

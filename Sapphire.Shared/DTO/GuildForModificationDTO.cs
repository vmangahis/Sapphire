using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sapphire.Shared.DTO
{
    public abstract record GuildForModificationDTO{
        [Required(ErrorMessage = "Please provide a guild name.")]
        [MaxLength(20, ErrorMessage = "Guild names can only be 20 characters")]
        public string GuildName { get; init; }

    }
}

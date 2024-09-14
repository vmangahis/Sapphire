using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sapphire.Shared.DTO.Monster
{
    public record MonsterDTO
    {
        public Guid Id { get; init; }
        public string? MonsterName { get; init; }
    }
}

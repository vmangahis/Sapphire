using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sapphire.Shared.DTO.Quest
{
    public record PostQuestDto
    {
        public string? QuestTitle { get; init; }
        public string? QuestDescription { get; init; }
        public double ZennyReward { get; init; }

    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sapphire.Shared.DTO.Quest
{
    public record PostQuestDTO
    {
        [Required(ErrorMessage = "Quest Title is required.")]
        public string? QuestTitle { get; init; }
        [Required(ErrorMessage = "Quest Description is required.")]
        public string? QuestDescription { get; init; }
        [Required(ErrorMessage = "Zenny Reward is required.")]
        public double ZennyReward { get; init; }
        [Required(ErrorMessage = "Unknown character id")]
        public  string? CharacterId { get; init; }
        [Required(ErrorMessage = "Unknown client id")]
        public string? ClientId { get; init; }
    }
}

using System.Text.Json.Serialization;

namespace Sapphire.DTO.Monster
{
    public class EditMonsterDTO
    {
        public string MonsterName { get; set; }
        public double HealthPool { get; set; }
        public double BaseAttack { get; set; }
        public double BaseDefense { get; set; }
    }
}

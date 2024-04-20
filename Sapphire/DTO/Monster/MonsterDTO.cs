namespace Sapphire.DTO.Monster
{
    public class MonsterDTO
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string MonsterName { get; set; } = "Dummy";
    }
}

namespace Sapphire.Models
{
    public class Monsters
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string MonsterName { get; set; } = "Dummy";
        public double HealthPool { get; set; } = 0.0;
        public double BaseAttack { get; set; } = 0.0;
        public double BaseDefense { get; set; } = 0.0;
        

    }
}

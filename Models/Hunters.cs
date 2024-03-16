namespace Sapphire.Models
{
    public class Hunters
    {
        public Guid Id { get; set; }
        public string HunterName { get; set; } = string.Empty;
        public int Rank { get; set; } = 1;
        public double ZennyAmount { get; set; } = 0.0;
        public bool DummyColumn { get; set; } = false;


    }
}

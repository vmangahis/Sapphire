using Sapphire.Entities.Models;
namespace Sapphire.Service.Contracts
{
    public interface IMonsterService 
    {
        IEnumerable<Monsters> GetAllMonsters(bool track);
    }
}

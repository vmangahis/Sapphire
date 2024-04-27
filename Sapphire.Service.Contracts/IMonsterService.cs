using Sapphire.Shared.DTO;
namespace Sapphire.Service.Contracts
{
    public interface IMonsterService 
    {
        IEnumerable<MonsterDTO> GetAllMonsters(bool track);
    }
}

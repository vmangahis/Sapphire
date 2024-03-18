using Sapphire.DTO;

namespace Sapphire.Interfaces
{
    public interface IMonsterRepository
    {
        Task<IEnumerable<MonsterDTO>> GetAllMonsterAsync();
    }
}

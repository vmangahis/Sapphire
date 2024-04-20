using Sapphire.DTO.Monster;

namespace Sapphire.Interfaces
{
    public interface IMonsterRepository
    {
        Task<IEnumerable<MonsterDTO>> GetAllMonsterAsync();
    }
}

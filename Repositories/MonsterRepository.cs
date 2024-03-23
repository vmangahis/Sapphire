using Sapphire.DTO.Monster;
using Sapphire.Interfaces;

namespace Sapphire.Repositories
{
    public class MonsterRepository : IMonsterRepository
    {
        public Task<IEnumerable<MonsterDTO>> GetAllMonsterAsync()
        {
            throw new NotImplementedException();
        }
    }
}

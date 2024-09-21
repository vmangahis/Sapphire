using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sapphire.Contracts
{
    public interface IRepositoryManager
    {
        IGuildRepository Guild { get; }
        IMonsterRepository Monster { get; }
        IHunterRepository Hunter { get; }
        ILocaleRepository Locale { get; }
        IQuestRepository Quest { get; }
        ICharacterRepository Character { get; } 
        IRoleRepository Role { get; }
        Task SaveAsync();
    }
}

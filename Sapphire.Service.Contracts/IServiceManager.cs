using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sapphire.Service.Contracts
{
    public interface IServiceManager
    {
        IHunterService HunterService { get; }
        IMonsterService MonsterService { get; } 
        IGuildService GuildService { get; }
        IAuthenticationService AuthenticationService { get; }
        ISapphireUserService SapphireUserService { get; }
    }
}

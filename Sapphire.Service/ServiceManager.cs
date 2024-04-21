using Sapphire.Service.Contracts;
using Sapphire.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography.X509Certificates;

namespace Sapphire.Service
{
    public sealed class ServiceManager : IServiceManager
    {
        private readonly Lazy<IHunterService> _hunterService;
        private readonly Lazy<IMonsterService> _monsterService;
        public ServiceManager(IRepositoryManager repositorymanager, ILoggerManager loggermanager) {
            _monsterService = new Lazy<IMonsterService>(() => new MonsterService(repositorymanager, loggermanager));
            _hunterService = new Lazy<IHunterService>(() => new HunterService(repositorymanager, loggermanager));
        }
        public IHunterService HunterService => _hunterService.Value;
        public IMonsterService MonsterService => _monsterService.Value;
    }
}

using Sapphire.Service.Contracts;
using Sapphire.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography.X509Certificates;
using AutoMapper;

namespace Sapphire.Service
{
    public sealed class ServiceManager : IServiceManager
    {
        private readonly Lazy<IHunterService> _hunterService;
        private readonly Lazy<IMonsterService> _monsterService;
        private readonly Lazy<IGuildService> _guildService;
        public ServiceManager(IRepositoryManager repositorymanager, IMapper map) {
            _monsterService = new Lazy<IMonsterService>(() => new MonsterService(repositorymanager, map));
            _hunterService = new Lazy<IHunterService>(() => new HunterService(repositorymanager, map));
            _guildService = new Lazy<IGuildService>(() => new GuildService(repositorymanager, map));

        }
        public IHunterService HunterService => _hunterService.Value;
        public IMonsterService MonsterService => _monsterService.Value;
        public IGuildService GuildService => _guildService.Value;
    }
}

using Sapphire.Service.Contracts;
using Sapphire.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography.X509Certificates;
using AutoMapper;
using Sapphire.Shared.DTO;
using Sapphire.Entities.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;

namespace Sapphire.Service
{
    public sealed class ServiceManager : IServiceManager
    {
        private readonly Lazy<IHunterService> _hunterService;
        private readonly Lazy<IMonsterService> _monsterService;
        private readonly Lazy<IGuildService> _guildService;
        private readonly Lazy<IAuthenticationService> _authService;
        private readonly Lazy<ISapphireUserService> _sapphireUserService;
        public ServiceManager(IRepositoryManager repositorymanager, IMapper map, IDataShaper<HunterDTO> dataShaper, UserManager<SapphireUser> userManager, IConfiguration conf, RoleManager<IdentityRole> roleManager) {
            _monsterService = new Lazy<IMonsterService>(() => new MonsterService(repositorymanager, map));
            _hunterService = new Lazy<IHunterService>(() => new HunterService(repositorymanager, map, dataShaper));
            _guildService = new Lazy<IGuildService>(() => new GuildService(repositorymanager, map));
            _authService = new Lazy<IAuthenticationService>(() => new AuthenticationService(map, userManager, conf, roleManager));
            _sapphireUserService = new Lazy<ISapphireUserService>(() => new SapphireUserService(repositorymanager,map, userManager ));
        }
        public IHunterService HunterService => _hunterService.Value;
        public IMonsterService MonsterService => _monsterService.Value;
        public IGuildService GuildService => _guildService.Value;
        public IAuthenticationService AuthenticationService => _authService.Value;
        public ISapphireUserService SapphireUserService => _sapphireUserService.Value;
    }
}

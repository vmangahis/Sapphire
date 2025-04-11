using Sapphire.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Sapphire.Repository
{
    public sealed class RepositoryManager : IRepositoryManager
    {
        private readonly RepositoryContext _repoContext;
        private readonly Lazy<IMonsterRepository> _monsrepo;
        private readonly Lazy<IHunterRepository> _huntrepo;
        private readonly Lazy<IGuildRepository> _guildrepo;
        private readonly Lazy<ILocaleRepository> _localrepo;
        private readonly Lazy<IQuestRepository> _questRepo;
        private readonly Lazy<ICharacterRepository> _charRepo;

        public RepositoryManager(RepositoryContext repocont) {
            _repoContext = repocont;
            _monsrepo = new Lazy<IMonsterRepository>(() => new MonsterRepository(repocont));
            _huntrepo = new Lazy<IHunterRepository>(() => new HunterRepository(repocont));
            _guildrepo = new Lazy<IGuildRepository>(() => new GuildRepository(repocont));
            _localrepo = new Lazy<ILocaleRepository>(() => new LocaleRepository(repocont));
            _questRepo = new Lazy<IQuestRepository>(() => new QuestRepository(repocont));
            _charRepo = new Lazy<ICharacterRepository>(() => new CharacterRepository(repocont));

        }
 
        public IMonsterRepository Monster => _monsrepo.Value;
        public IHunterRepository Hunter => _huntrepo.Value;
        public IGuildRepository Guild => _guildrepo.Value;
        public ILocaleRepository Locale => _localrepo.Value;
        public IQuestRepository Quest => _questRepo.Value;
        public ICharacterRepository Character => _charRepo.Value;

        public async Task SaveAsync() => await _repoContext.SaveChangesAsync();      
    }
}

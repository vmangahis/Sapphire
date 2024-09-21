using AutoMapper;
using Sapphire.Contracts;
using Sapphire.Service.Contracts;
using Sapphire.Shared.DTO.Quest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sapphire.Service
{
    public class QuestService : IQuestService
    {
        private readonly IRepositoryManager _repoManager;
        private readonly IMapper _mapper;

        public QuestService(IRepositoryManager repoManager, IMapper mapper) {
            _repoManager = repoManager;
            _mapper = mapper;
        }
        public async Task PostQuest(PostQuestDto postquestDto)
        {
            
        }
    }
}

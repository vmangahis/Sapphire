using AutoMapper;
using Sapphire.Contracts;
using Sapphire.Entities.Models;
using Sapphire.Service.Contracts;
using Sapphire.Shared.DTO.Quest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
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
        public async Task PostQuest(PostQuestDTO postquestDto, SapphireUser saphUser)
        {
            var quest = _mapper.Map<Quest>(postquestDto);
            var questReward = postquestDto.ZennyReward;
            if (questReward == 0){
                questReward = 200.0;
                quest.ZennyReward = questReward;
            }

            quest.SapphireId = new Guid(saphUser.Id);
            _repoManager.Quest.PostQuest(quest);
            await _repoManager.SaveAsync();
            
        }
    }
}

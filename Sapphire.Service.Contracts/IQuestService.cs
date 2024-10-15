using Sapphire.Entities.Models;
using Sapphire.Shared.DTO.Quest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sapphire.Service.Contracts
{
    public interface IQuestService
    {
        Task PostQuest(PostQuestDTO postquestDto, SapphireUser saphUser);
    }
}

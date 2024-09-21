using Sapphire.Contracts;
using Sapphire.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sapphire.Repository
{
    public class QuestRepository : RepositoryBase<Quest>, IQuestRepository
    {
        public QuestRepository(RepositoryContext repoCont) : base(repoCont){ }
        public void PostQuest(Quest q) => Create(q);
    }
}

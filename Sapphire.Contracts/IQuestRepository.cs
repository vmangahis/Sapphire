using Sapphire.Entities.Models;

namespace Sapphire.Contracts
{
    public interface IQuestRepository
    {
        void PostQuest(Quest q);
    }
}
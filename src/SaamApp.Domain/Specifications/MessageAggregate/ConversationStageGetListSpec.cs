using Ardalis.Specification;
using SaamApp.Domain.Entities;

namespace SaamApp.Domain.Specifications
{
    public class ConversationStageGetListSpec : Specification<ConversationStage>
    {
        public ConversationStageGetListSpec()
        {
            Query.OrderBy(conversationStage => conversationStage.ConversationStageId)
                .AsNoTracking();
        }
    }
}
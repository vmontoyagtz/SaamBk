using Ardalis.Specification;
using SaamApp.Domain.Entities;

namespace SaamApp.Domain.Specifications
{
    public class UnansweredConversationGetListSpec : Specification<UnansweredConversation>
    {
        public UnansweredConversationGetListSpec()
        {
            Query.Where(unansweredConversation => unansweredConversation.Answered == true)
                .AsNoTracking();
        }
    }
}
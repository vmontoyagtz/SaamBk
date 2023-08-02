using Ardalis.Specification;
using SaamApp.Domain.Entities;

namespace SaamApp.Domain.Specifications
{
    public class ConversationGetListSpec : Specification<Conversation>
    {
        public ConversationGetListSpec()
        {
            Query.Where(conversation => conversation.LostSignalCustomer == true)
                .AsNoTracking();
        }
    }
}
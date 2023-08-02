using Ardalis.Specification;
using SaamApp.Domain.Entities;

namespace SaamApp.Domain.Specifications
{
    public class ConversationPaymentGetListSpec : Specification<ConversationPayment>
    {
        public ConversationPaymentGetListSpec()
        {
            Query.Where(conversationPayment => conversationPayment.ConversationPaymentStage == true)
                .AsNoTracking();
        }
    }
}
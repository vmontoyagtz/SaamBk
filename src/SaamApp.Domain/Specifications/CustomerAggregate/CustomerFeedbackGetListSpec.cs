using Ardalis.Specification;
using SaamApp.Domain.Entities;

namespace SaamApp.Domain.Specifications
{
    public class CustomerFeedbackGetListSpec : Specification<CustomerFeedback>
    {
        public CustomerFeedbackGetListSpec()
        {
            Query.OrderBy(customerFeedback => customerFeedback.FeedbackId)
                .AsNoTracking();
        }
    }
}
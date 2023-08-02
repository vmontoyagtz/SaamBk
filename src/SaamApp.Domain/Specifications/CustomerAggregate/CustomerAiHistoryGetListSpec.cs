using Ardalis.Specification;
using SaamApp.Domain.Entities;

namespace SaamApp.Domain.Specifications
{
    public class CustomerAiHistoryGetListSpec : Specification<CustomerAiHistory>
    {
        public CustomerAiHistoryGetListSpec()
        {
            Query.OrderBy(customerAiHistory => customerAiHistory.CustomerAiHistoryId)
                .AsNoTracking();
        }
    }
}
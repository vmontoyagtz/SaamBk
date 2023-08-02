using System;
using Ardalis.GuardClauses;
using Ardalis.Specification;
using SaamApp.Domain.Entities;

namespace SaamApp.Domain.Specifications
{
    public class CustomerAiHistoryByIdWithIncludesSpec : Specification<CustomerAiHistory>, ISingleResultSpecification
    {
        public CustomerAiHistoryByIdWithIncludesSpec(Guid customerAiHistoryId)
        {
            Guard.Against.NullOrEmpty(customerAiHistoryId, nameof(customerAiHistoryId));
            Query.Where(customerAiHistory => customerAiHistory.CustomerAiHistoryId == customerAiHistoryId)
                .Include(a => a.Customer)
                .AsNoTracking();
        }
    }
}
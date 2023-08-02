using System;
using Ardalis.GuardClauses;
using Ardalis.Specification;
using SaamApp.Domain.Entities;

namespace SaamApp.Domain.Specifications
{
    public class CustomerPurchaseByIdWithIncludesSpec : Specification<CustomerPurchase>, ISingleResultSpecification
    {
        public CustomerPurchaseByIdWithIncludesSpec(Guid customerPurchaseId)
        {
            Guard.Against.NullOrEmpty(customerPurchaseId, nameof(customerPurchaseId));
            Query.Where(customerPurchase => customerPurchase.CustomerPurchaseId == customerPurchaseId)
                .Include(a => a.Customer)
                .AsNoTracking();
        }
    }
}
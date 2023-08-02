using System;
using Ardalis.GuardClauses;
using Ardalis.Specification;
using SaamApp.Domain.Entities;

namespace SaamApp.Domain.Specifications
{
    public class CustomerAccountByRelIdsSpec : Specification<CustomerAccount>
    {
        public CustomerAccountByRelIdsSpec(Guid accountId, Guid customerId)
        {
            Guard.Against.NullOrEmpty(accountId, nameof(accountId));
            Guard.Against.NullOrEmpty(customerId, nameof(customerId));
            Query.Where(customerAccount =>
                customerAccount.AccountId == accountId && customerAccount.CustomerId == customerId).AsNoTracking();
        }
    }
}
using System;
using Ardalis.GuardClauses;
using Ardalis.Specification;
using SaamApp.Domain.Entities;

namespace SaamApp.Domain.Specifications
{
    public class CustomerEmailAddressByRelIdsSpec : Specification<CustomerEmailAddress>
    {
        public CustomerEmailAddressByRelIdsSpec(Guid customerId, Guid emailAddressId)
        {
            Guard.Against.NullOrEmpty(customerId, nameof(customerId));
            Guard.Against.NullOrEmpty(emailAddressId, nameof(emailAddressId));
            Query.Where(customerEmailAddress => customerEmailAddress.CustomerId == customerId &&
                                                customerEmailAddress.EmailAddressId == emailAddressId).AsNoTracking();
        }
    }
}
using System;
using Ardalis.GuardClauses;
using Ardalis.Specification;
using SaamApp.Domain.Entities;

namespace SaamApp.Domain.Specifications
{
    public class CustomerPhoneNumberByRelIdsSpec : Specification<CustomerPhoneNumber>
    {
        public CustomerPhoneNumberByRelIdsSpec(Guid customerId, Guid phoneNumberId)
        {
            Guard.Against.NullOrEmpty(customerId, nameof(customerId));
            Guard.Against.NullOrEmpty(phoneNumberId, nameof(phoneNumberId));
            Query.Where(customerPhoneNumber => customerPhoneNumber.CustomerId == customerId &&
                                               customerPhoneNumber.PhoneNumberId == phoneNumberId).AsNoTracking();
        }
    }
}
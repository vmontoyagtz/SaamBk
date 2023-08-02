using System;
using Ardalis.GuardClauses;
using Ardalis.Specification;
using SaamApp.Domain.Entities;

namespace SaamApp.Domain.Specifications
{
    public class CustomerAddressByRelIdsSpec : Specification<CustomerAddress>
    {
        public CustomerAddressByRelIdsSpec(Guid addressId, Guid customerId)
        {
            Guard.Against.NullOrEmpty(addressId, nameof(addressId));
            Guard.Against.NullOrEmpty(customerId, nameof(customerId));
            Query.Where(customerAddress =>
                customerAddress.AddressId == addressId && customerAddress.CustomerId == customerId).AsNoTracking();
        }
    }
}
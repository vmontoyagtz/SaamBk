using System;
using Ardalis.GuardClauses;
using Ardalis.Specification;
using SaamApp.Domain.Entities;

namespace SaamApp.Domain.Specifications
{
    public class GetAdvisorAddressWithAddressKeySpec : Specification<AdvisorAddress>
    {
        public GetAdvisorAddressWithAddressKeySpec(Guid addressId)
        {
            Guard.Against.NullOrEmpty(addressId, nameof(addressId));
            Query.Where(aa => aa.AddressId == addressId).AsNoTracking();
        }
    }

    public class GetBusinessUnitAddressWithAddressKeySpec : Specification<BusinessUnitAddress>
    {
        public GetBusinessUnitAddressWithAddressKeySpec(Guid addressId)
        {
            Guard.Against.NullOrEmpty(addressId, nameof(addressId));
            Query.Where(bua => bua.AddressId == addressId).AsNoTracking();
        }
    }

    public class GetCustomerAddressWithAddressKeySpec : Specification<CustomerAddress>
    {
        public GetCustomerAddressWithAddressKeySpec(Guid addressId)
        {
            Guard.Against.NullOrEmpty(addressId, nameof(addressId));
            Query.Where(ca => ca.AddressId == addressId).AsNoTracking();
        }
    }

    public class GetEmployeeAddressWithAddressKeySpec : Specification<EmployeeAddress>
    {
        public GetEmployeeAddressWithAddressKeySpec(Guid addressId)
        {
            Guard.Against.NullOrEmpty(addressId, nameof(addressId));
            Query.Where(ea => ea.AddressId == addressId).AsNoTracking();
        }
    }
}
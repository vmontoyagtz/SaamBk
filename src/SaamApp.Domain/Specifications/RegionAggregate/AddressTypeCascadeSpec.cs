using System;
using Ardalis.GuardClauses;
using Ardalis.Specification;
using SaamApp.Domain.Entities;

namespace SaamApp.Domain.Specifications
{
    public class GetAdvisorAddressWithAddressTypeKeySpec : Specification<AdvisorAddress>
    {
        public GetAdvisorAddressWithAddressTypeKeySpec(Guid addressTypeId)
        {
            Guard.Against.NullOrEmpty(addressTypeId, nameof(addressTypeId));
            Query.Where(aa => aa.AddressTypeId == addressTypeId).AsNoTracking();
        }
    }

    public class GetBusinessUnitAddressWithAddressTypeKeySpec : Specification<BusinessUnitAddress>
    {
        public GetBusinessUnitAddressWithAddressTypeKeySpec(Guid addressTypeId)
        {
            Guard.Against.NullOrEmpty(addressTypeId, nameof(addressTypeId));
            Query.Where(bua => bua.AddressTypeId == addressTypeId).AsNoTracking();
        }
    }

    public class GetCustomerAddressWithAddressTypeKeySpec : Specification<CustomerAddress>
    {
        public GetCustomerAddressWithAddressTypeKeySpec(Guid addressTypeId)
        {
            Guard.Against.NullOrEmpty(addressTypeId, nameof(addressTypeId));
            Query.Where(ca => ca.AddressTypeId == addressTypeId).AsNoTracking();
        }
    }

    public class GetEmployeeAddressWithAddressTypeKeySpec : Specification<EmployeeAddress>
    {
        public GetEmployeeAddressWithAddressTypeKeySpec(Guid addressTypeId)
        {
            Guard.Against.NullOrEmpty(addressTypeId, nameof(addressTypeId));
            Query.Where(ea => ea.AddressTypeId == addressTypeId).AsNoTracking();
        }
    }
}
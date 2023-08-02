using System;
using Ardalis.GuardClauses;
using Ardalis.Specification;
using SaamApp.Domain.Entities;

namespace SaamApp.Domain.Specifications
{
    public class BusinessUnitAddressByRelIdsSpec : Specification<BusinessUnitAddress>
    {
        public BusinessUnitAddressByRelIdsSpec(Guid addressId, Guid businessUnitId)
        {
            Guard.Against.NullOrEmpty(addressId, nameof(addressId));
            Guard.Against.NullOrEmpty(businessUnitId, nameof(businessUnitId));
            Query.Where(businessUnitAddress => businessUnitAddress.AddressId == addressId &&
                                               businessUnitAddress.BusinessUnitId == businessUnitId).AsNoTracking();
        }
    }
}
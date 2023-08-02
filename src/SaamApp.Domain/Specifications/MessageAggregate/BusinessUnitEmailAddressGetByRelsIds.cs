using System;
using Ardalis.GuardClauses;
using Ardalis.Specification;
using SaamApp.Domain.Entities;

namespace SaamApp.Domain.Specifications
{
    public class BusinessUnitEmailAddressByRelIdsSpec : Specification<BusinessUnitEmailAddress>
    {
        public BusinessUnitEmailAddressByRelIdsSpec(Guid businessUnitId, Guid emailAddressId)
        {
            Guard.Against.NullOrEmpty(businessUnitId, nameof(businessUnitId));
            Guard.Against.NullOrEmpty(emailAddressId, nameof(emailAddressId));
            Query.Where(businessUnitEmailAddress => businessUnitEmailAddress.BusinessUnitId == businessUnitId &&
                                                    businessUnitEmailAddress.EmailAddressId == emailAddressId)
                .AsNoTracking();
        }
    }
}
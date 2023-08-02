using System;
using Ardalis.GuardClauses;
using Ardalis.Specification;
using SaamApp.Domain.Entities;

namespace SaamApp.Domain.Specifications
{
    public class BusinessUnitPhoneNumberByRelIdsSpec : Specification<BusinessUnitPhoneNumber>
    {
        public BusinessUnitPhoneNumberByRelIdsSpec(Guid businessUnitId, Guid phoneNumberId)
        {
            Guard.Against.NullOrEmpty(businessUnitId, nameof(businessUnitId));
            Guard.Against.NullOrEmpty(phoneNumberId, nameof(phoneNumberId));
            Query.Where(businessUnitPhoneNumber => businessUnitPhoneNumber.BusinessUnitId == businessUnitId &&
                                                   businessUnitPhoneNumber.PhoneNumberId == phoneNumberId)
                .AsNoTracking();
        }
    }
}
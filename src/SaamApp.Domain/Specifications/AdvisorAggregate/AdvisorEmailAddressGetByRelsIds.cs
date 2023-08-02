using System;
using Ardalis.GuardClauses;
using Ardalis.Specification;
using SaamApp.Domain.Entities;

namespace SaamApp.Domain.Specifications
{
    public class AdvisorEmailAddressByRelIdsSpec : Specification<AdvisorEmailAddress>
    {
        public AdvisorEmailAddressByRelIdsSpec(Guid advisorId, Guid emailAddressId)
        {
            Guard.Against.NullOrEmpty(advisorId, nameof(advisorId));
            Guard.Against.NullOrEmpty(emailAddressId, nameof(emailAddressId));
            Query.Where(advisorEmailAddress => advisorEmailAddress.AdvisorId == advisorId &&
                                               advisorEmailAddress.EmailAddressId == emailAddressId).AsNoTracking();
        }
    }
}
using System;
using Ardalis.GuardClauses;
using Ardalis.Specification;
using SaamApp.Domain.Entities;

namespace SaamApp.Domain.Specifications
{
    public class AdvisorPhoneNumberByRelIdsSpec : Specification<AdvisorPhoneNumber>
    {
        public AdvisorPhoneNumberByRelIdsSpec(Guid advisorId, Guid phoneNumberId)
        {
            Guard.Against.NullOrEmpty(advisorId, nameof(advisorId));
            Guard.Against.NullOrEmpty(phoneNumberId, nameof(phoneNumberId));
            Query.Where(advisorPhoneNumber => advisorPhoneNumber.AdvisorId == advisorId &&
                                              advisorPhoneNumber.PhoneNumberId == phoneNumberId).AsNoTracking();
        }
    }
}
using System;
using Ardalis.GuardClauses;
using Ardalis.Specification;
using SaamApp.Domain.Entities;

namespace SaamApp.Domain.Specifications
{
    public class AdvisorAddressByRelIdsSpec : Specification<AdvisorAddress>
    {
        public AdvisorAddressByRelIdsSpec(Guid addressId, Guid advisorId)
        {
            Guard.Against.NullOrEmpty(addressId, nameof(addressId));
            Guard.Against.NullOrEmpty(advisorId, nameof(advisorId));
            Query.Where(
                    advisorAddress => advisorAddress.AddressId == addressId && advisorAddress.AdvisorId == advisorId)
                .AsNoTracking();
        }
    }
}
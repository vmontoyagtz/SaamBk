using System;
using Ardalis.GuardClauses;
using Ardalis.Specification;
using SaamApp.Domain.Entities;

namespace SaamApp.Domain.Specifications
{
    public class GetAddressWithStateKeySpec : Specification<Address>
    {
        public GetAddressWithStateKeySpec(Guid stateId)
        {
            Guard.Against.NullOrEmpty(stateId, nameof(stateId));
            Query.Where(a => a.StateId == stateId).AsNoTracking();
        }
    }

    public class GetCityWithStateKeySpec : Specification<City>
    {
        public GetCityWithStateKeySpec(Guid stateId)
        {
            Guard.Against.NullOrEmpty(stateId, nameof(stateId));
            Query.Where(c => c.StateId == stateId).AsNoTracking();
        }
    }
}
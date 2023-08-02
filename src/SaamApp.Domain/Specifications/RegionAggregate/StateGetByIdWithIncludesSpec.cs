using System;
using Ardalis.GuardClauses;
using Ardalis.Specification;
using SaamApp.Domain.Entities;

namespace SaamApp.Domain.Specifications
{
    public class StateByIdWithIncludesSpec : Specification<State>, ISingleResultSpecification
    {
        public StateByIdWithIncludesSpec(Guid stateId)
        {
            Guard.Against.NullOrEmpty(stateId, nameof(stateId));
            Query.Where(state => state.StateId == stateId)
                .Include(a => a.Country)
                .Include(b => b.Addresses)
                .Include(c => c.Cities)
                .AsNoTracking();
        }
    }
}
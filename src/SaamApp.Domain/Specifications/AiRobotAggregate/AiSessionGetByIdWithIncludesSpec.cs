using System;
using Ardalis.GuardClauses;
using Ardalis.Specification;
using SaamApp.Domain.Entities;

namespace SaamApp.Domain.Specifications
{
    public class AiSessionByIdWithIncludesSpec : Specification<AiSession>, ISingleResultSpecification
    {
        public AiSessionByIdWithIncludesSpec(Guid aiSessionId)
        {
            Guard.Against.NullOrEmpty(aiSessionId, nameof(aiSessionId));
            Query.Where(aiSession => aiSession.AiSessionId == aiSessionId)
                .Include(a => a.Customer)
                .AsNoTracking();
        }
    }
}
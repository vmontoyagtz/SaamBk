using System;
using Ardalis.GuardClauses;
using Ardalis.Specification;
using SaamApp.Domain.Entities;

namespace SaamApp.Domain.Specifications
{
    public class AdvisorLoginByIdWithIncludesSpec : Specification<AdvisorLogin>, ISingleResultSpecification
    {
        public AdvisorLoginByIdWithIncludesSpec(Guid advisorLoginId)
        {
            Guard.Against.NullOrEmpty(advisorLoginId, nameof(advisorLoginId));
            Query.Where(advisorLogin => advisorLogin.AdvisorLoginId == advisorLoginId)
                .Include(a => a.Advisor)
                .AsNoTracking();
        }
    }
}
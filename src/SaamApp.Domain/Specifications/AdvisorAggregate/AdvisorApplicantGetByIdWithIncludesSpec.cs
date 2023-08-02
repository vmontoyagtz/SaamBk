using System;
using Ardalis.GuardClauses;
using Ardalis.Specification;
using SaamApp.Domain.Entities;

namespace SaamApp.Domain.Specifications
{
    public class AdvisorApplicantByIdWithIncludesSpec : Specification<AdvisorApplicant>, ISingleResultSpecification
    {
        public AdvisorApplicantByIdWithIncludesSpec(Guid advisorApplicantId)
        {
            Guard.Against.NullOrEmpty(advisorApplicantId, nameof(advisorApplicantId));
            Query.Where(advisorApplicant => advisorApplicant.AdvisorApplicantId == advisorApplicantId)
                .Include(a => a.RegionAreaAdvisorCategory)
                .AsNoTracking();
        }
    }
}
using System;
using Ardalis.GuardClauses;
using Ardalis.Specification;
using SaamApp.Domain.Entities;

namespace SaamApp.Domain.Specifications
{
    public class TaxInformationByIdWithIncludesSpec : Specification<TaxInformation>, ISingleResultSpecification
    {
        public TaxInformationByIdWithIncludesSpec(Guid taxInformationId)
        {
            Guard.Against.NullOrEmpty(taxInformationId, nameof(taxInformationId));
            Query.Where(taxInformation => taxInformation.TaxInformationId == taxInformationId)
                .Include(a => a.BusinessUnit)
                .Include(b => b.TaxpayerType)
                .Include(c => c.Accounts)
                .Include(d => d.Advisors)
                .ThenInclude(d => d.RegionAreaAdvisorCategories)
                .ThenInclude(d => d.Comissions)
                .AsNoTracking();
        }
    }
}
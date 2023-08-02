using System;
using Ardalis.GuardClauses;
using Ardalis.Specification;
using SaamApp.Domain.Entities;

namespace SaamApp.Domain.Specifications
{
    public class GetAccountWithTaxInformationKeySpec : Specification<Account>
    {
        public GetAccountWithTaxInformationKeySpec(Guid taxInformationId)
        {
            Guard.Against.NullOrEmpty(taxInformationId, nameof(taxInformationId));
            Query.Where(a => a.TaxInformationId == taxInformationId).AsNoTracking();
        }
    }

    public class GetAdvisorWithTaxInformationKeySpec : Specification<Advisor>
    {
        public GetAdvisorWithTaxInformationKeySpec(Guid taxInformationId)
        {
            Guard.Against.NullOrEmpty(taxInformationId, nameof(taxInformationId));
            Query.Where(a => a.TaxInformationId == taxInformationId).AsNoTracking();
        }
    }
}
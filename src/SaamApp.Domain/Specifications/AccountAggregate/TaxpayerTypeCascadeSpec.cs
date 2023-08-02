using System;
using Ardalis.GuardClauses;
using Ardalis.Specification;
using SaamApp.Domain.Entities;

namespace SaamApp.Domain.Specifications
{
    public class GetTaxInformationWithTaxpayerTypeKeySpec : Specification<TaxInformation>
    {
        public GetTaxInformationWithTaxpayerTypeKeySpec(Guid taxpayerTypeId)
        {
            Guard.Against.NullOrEmpty(taxpayerTypeId, nameof(taxpayerTypeId));
            Query.Where(ti => ti.TaxpayerTypeId == taxpayerTypeId).AsNoTracking();
        }
    }
}
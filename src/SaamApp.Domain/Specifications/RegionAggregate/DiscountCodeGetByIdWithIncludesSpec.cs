using System;
using Ardalis.GuardClauses;
using Ardalis.Specification;
using SaamApp.Domain.Entities;

namespace SaamApp.Domain.Specifications
{
    public class DiscountCodeByIdWithIncludesSpec : Specification<DiscountCode>, ISingleResultSpecification
    {
        public DiscountCodeByIdWithIncludesSpec(Guid discountCodeId)
        {
            Guard.Against.NullOrEmpty(discountCodeId, nameof(discountCodeId));
            Query.Where(discountCode => discountCode.DiscountCodeId == discountCodeId)
                .Include(a => a.Region)
                .Include(b => b.DiscountCodeRedemptions)
                .ThenInclude(c => c.Customer)
                .Include(c => c.SerfinsaPayments)
                .AsNoTracking();
        }
    }
}
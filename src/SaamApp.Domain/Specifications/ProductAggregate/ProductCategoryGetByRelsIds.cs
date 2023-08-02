using System;
using Ardalis.GuardClauses;
using Ardalis.Specification;
using SaamApp.Domain.Entities;

namespace SaamApp.Domain.Specifications
{
    public class ProductCategoryByRelIdsSpec : Specification<ProductCategory>
    {
        public ProductCategoryByRelIdsSpec(Guid regionAreaAdvisorCategoryId, Guid comissionId, Guid productId,
            Guid tenantId)
        {
            Guard.Against.NullOrEmpty(regionAreaAdvisorCategoryId, nameof(regionAreaAdvisorCategoryId));
            Guard.Against.NullOrEmpty(comissionId, nameof(comissionId));
            Guard.Against.NullOrEmpty(productId, nameof(productId));
            Guard.Against.NullOrEmpty(tenantId, nameof(tenantId));
            Query.Where(productCategory => productCategory.RegionAreaAdvisorCategoryId == regionAreaAdvisorCategoryId &&
                                           productCategory.ComissionId == comissionId &&
                                           productCategory.ProductId == productId &&
                                           productCategory.TenantId == tenantId).AsNoTracking();
        }
    }
}
using System;
using Ardalis.GuardClauses;
using Ardalis.Specification;
using SaamApp.Domain.Entities;

namespace SaamApp.Domain.Specifications
{
    public class ProductByIdWithIncludesSpec : Specification<Product>, ISingleResultSpecification
    {
        public ProductByIdWithIncludesSpec(Guid productId)
        {
            Guard.Against.NullOrEmpty(productId, nameof(productId));
            Query.Where(product => product.ProductId == productId)
                .Include(a => a.InvoiceDetails)
                .ThenInclude(b => b.Invoice)
                .Include(b => b.Messages)
                .Include(c => c.ProductCategories)
                .ThenInclude(d => d.Comission).Include(d => d.ProductCategories)
                .ThenInclude(d => d.RegionAreaAdvisorCategory)
                .AsNoTracking();
        }
    }
}
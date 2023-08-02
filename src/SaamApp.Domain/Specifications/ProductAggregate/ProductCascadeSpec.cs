using System;
using Ardalis.GuardClauses;
using Ardalis.Specification;
using SaamApp.Domain.Entities;

namespace SaamApp.Domain.Specifications
{
    public class GetInvoiceDetailWithProductKeySpec : Specification<InvoiceDetail>
    {
        public GetInvoiceDetailWithProductKeySpec(Guid productId)
        {
            Guard.Against.NullOrEmpty(productId, nameof(productId));
            Query.Where(id => id.ProductId == productId).AsNoTracking();
        }
    }

    public class GetMessageWithProductKeySpec : Specification<Message>
    {
        public GetMessageWithProductKeySpec(Guid productId)
        {
            Guard.Against.NullOrEmpty(productId, nameof(productId));
            Query.Where(m => m.ProductId == productId).AsNoTracking();
        }
    }

    public class GetProductCategoryWithProductKeySpec : Specification<ProductCategory>
    {
        public GetProductCategoryWithProductKeySpec(Guid productId)
        {
            Guard.Against.NullOrEmpty(productId, nameof(productId));
            Query.Where(pc => pc.ProductId == productId).AsNoTracking();
        }
    }
}
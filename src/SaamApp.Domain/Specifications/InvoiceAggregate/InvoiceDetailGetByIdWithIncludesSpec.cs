using System;
using Ardalis.GuardClauses;
using Ardalis.Specification;
using SaamApp.Domain.Entities;

namespace SaamApp.Domain.Specifications
{
    public class InvoiceDetailByIdWithIncludesSpec : Specification<InvoiceDetail>, ISingleResultSpecification
    {
        public InvoiceDetailByIdWithIncludesSpec(Guid invoiceDetailId)
        {
            Guard.Against.NullOrEmpty(invoiceDetailId, nameof(invoiceDetailId));
            Query.Where(invoiceDetail => invoiceDetail.InvoiceDetailId == invoiceDetailId)
                .Include(a => a.Invoice)
                .Include(b => b.Product)
                .AsNoTracking();
        }
    }
}
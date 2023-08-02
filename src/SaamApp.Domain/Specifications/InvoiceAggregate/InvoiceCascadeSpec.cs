using System;
using Ardalis.GuardClauses;
using Ardalis.Specification;
using SaamApp.Domain.Entities;

namespace SaamApp.Domain.Specifications
{
    public class GetInvoiceDetailWithInvoiceKeySpec : Specification<InvoiceDetail>
    {
        public GetInvoiceDetailWithInvoiceKeySpec(Guid invoiceId)
        {
            Guard.Against.NullOrEmpty(invoiceId, nameof(invoiceId));
            Query.Where(id => id.InvoiceId == invoiceId).AsNoTracking();
        }
    }
}
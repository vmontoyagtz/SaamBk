using System;
using Ardalis.GuardClauses;
using Ardalis.Specification;
using SaamApp.Domain.Entities;

namespace SaamApp.Domain.Specifications
{
    public class InvoiceByIdWithIncludesSpec : Specification<Invoice>, ISingleResultSpecification
    {
        public InvoiceByIdWithIncludesSpec(Guid invoiceId)
        {
            Guard.Against.NullOrEmpty(invoiceId, nameof(invoiceId));
            Query.Where(invoice => invoice.InvoiceId == invoiceId)
                .Include(a => a.Account)
                .Include(b => b.FinancialAccountingPeriod)
                .Include(c => c.InvoiceDetails)
                .ThenInclude(d => d.Product)
                .AsNoTracking();
        }
    }
}
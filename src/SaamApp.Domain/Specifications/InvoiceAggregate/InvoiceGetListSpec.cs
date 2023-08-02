using Ardalis.Specification;
using SaamApp.Domain.Entities;

namespace SaamApp.Domain.Specifications
{
    public class InvoiceGetListSpec : Specification<Invoice>
    {
        public InvoiceGetListSpec()
        {
            Query.OrderBy(invoice => invoice.InvoiceId)
                .AsNoTracking();
        }
    }
}
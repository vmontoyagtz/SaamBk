using Ardalis.Specification;
using SaamApp.Domain.Entities;

namespace SaamApp.Domain.Specifications
{
    public class InvoiceDetailGetListSpec : Specification<InvoiceDetail>
    {
        public InvoiceDetailGetListSpec()
        {
            Query.OrderBy(invoiceDetail => invoiceDetail.InvoiceDetailId)
                .AsNoTracking();
        }
    }
}
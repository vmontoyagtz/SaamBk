using System;

namespace SaamApp.BlazorMauiShared.Models.Invoice
{
    public class GetByIdInvoiceRequest : BaseRequest
    {
        public Guid InvoiceId { get; set; }
    }
}
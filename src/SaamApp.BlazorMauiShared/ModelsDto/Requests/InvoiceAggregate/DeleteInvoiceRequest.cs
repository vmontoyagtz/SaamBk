using System;

namespace SaamApp.BlazorMauiShared.Models.Invoice
{
    public class DeleteInvoiceRequest : BaseRequest
    {
        public Guid InvoiceId { get; set; }
    }
}
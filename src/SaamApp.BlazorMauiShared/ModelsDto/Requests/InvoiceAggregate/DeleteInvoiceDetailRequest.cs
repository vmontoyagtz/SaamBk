using System;

namespace SaamApp.BlazorMauiShared.Models.InvoiceDetail
{
    public class DeleteInvoiceDetailRequest : BaseRequest
    {
        public Guid InvoiceDetailId { get; set; }
    }
}
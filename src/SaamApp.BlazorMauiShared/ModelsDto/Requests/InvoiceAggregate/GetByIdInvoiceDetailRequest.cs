using System;

namespace SaamApp.BlazorMauiShared.Models.InvoiceDetail
{
    public class GetByIdInvoiceDetailRequest : BaseRequest
    {
        public Guid InvoiceDetailId { get; set; }
    }
}
using System;

namespace SaamApp.BlazorMauiShared.Models.InvoiceDetail
{
    public class DeleteInvoiceDetailResponse : BaseResponse
    {
        public DeleteInvoiceDetailResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public DeleteInvoiceDetailResponse()
        {
        }
    }
}
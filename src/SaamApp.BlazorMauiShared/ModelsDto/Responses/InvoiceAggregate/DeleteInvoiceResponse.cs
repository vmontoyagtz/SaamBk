using System;

namespace SaamApp.BlazorMauiShared.Models.Invoice
{
    public class DeleteInvoiceResponse : BaseResponse
    {
        public DeleteInvoiceResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public DeleteInvoiceResponse()
        {
        }
    }
}
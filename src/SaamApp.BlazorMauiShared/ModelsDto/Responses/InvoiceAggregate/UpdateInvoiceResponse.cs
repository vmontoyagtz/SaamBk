using System;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.Invoice
{
    public class UpdateInvoiceResponse : BaseResponse
    {
        public UpdateInvoiceResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public UpdateInvoiceResponse()
        {
        }

        public InvoiceDto Invoice { get; set; } = new();
    }
}
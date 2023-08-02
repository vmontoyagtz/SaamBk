using System;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.Invoice
{
    public class CreateInvoiceResponse : BaseResponse
    {
        public CreateInvoiceResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public CreateInvoiceResponse()
        {
        }

        public InvoiceDto Invoice { get; set; } = new();
    }
}
using System;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.Invoice
{
    public class GetByIdInvoiceResponse : BaseResponse
    {
        public GetByIdInvoiceResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public GetByIdInvoiceResponse()
        {
        }

        public InvoiceDto Invoice { get; set; } = new();
    }
}
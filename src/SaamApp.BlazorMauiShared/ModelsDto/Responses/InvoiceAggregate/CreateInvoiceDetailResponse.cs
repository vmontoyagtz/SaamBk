using System;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.InvoiceDetail
{
    public class CreateInvoiceDetailResponse : BaseResponse
    {
        public CreateInvoiceDetailResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public CreateInvoiceDetailResponse()
        {
        }

        public InvoiceDetailDto InvoiceDetail { get; set; } = new();
    }
}
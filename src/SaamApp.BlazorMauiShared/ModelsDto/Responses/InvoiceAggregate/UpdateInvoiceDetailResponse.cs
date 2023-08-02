using System;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.InvoiceDetail
{
    public class UpdateInvoiceDetailResponse : BaseResponse
    {
        public UpdateInvoiceDetailResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public UpdateInvoiceDetailResponse()
        {
        }

        public InvoiceDetailDto InvoiceDetail { get; set; } = new();
    }
}
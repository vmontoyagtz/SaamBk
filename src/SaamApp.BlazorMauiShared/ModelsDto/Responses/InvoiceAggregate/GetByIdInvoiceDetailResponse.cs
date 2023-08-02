using System;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.InvoiceDetail
{
    public class GetByIdInvoiceDetailResponse : BaseResponse
    {
        public GetByIdInvoiceDetailResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public GetByIdInvoiceDetailResponse()
        {
        }

        public InvoiceDetailDto InvoiceDetail { get; set; } = new();
    }
}
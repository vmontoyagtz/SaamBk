using System;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.SerfinsaPayment
{
    public class GetByIdSerfinsaPaymentResponse : BaseResponse
    {
        public GetByIdSerfinsaPaymentResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public GetByIdSerfinsaPaymentResponse()
        {
        }

        public SerfinsaPaymentDto SerfinsaPayment { get; set; } = new();
    }
}
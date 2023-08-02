using System;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.SerfinsaPayment
{
    public class CreateSerfinsaPaymentResponse : BaseResponse
    {
        public CreateSerfinsaPaymentResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public CreateSerfinsaPaymentResponse()
        {
        }

        public SerfinsaPaymentDto SerfinsaPayment { get; set; } = new();
    }
}
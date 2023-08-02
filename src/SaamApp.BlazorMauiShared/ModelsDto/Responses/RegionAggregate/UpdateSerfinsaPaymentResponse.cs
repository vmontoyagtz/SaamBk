using System;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.SerfinsaPayment
{
    public class UpdateSerfinsaPaymentResponse : BaseResponse
    {
        public UpdateSerfinsaPaymentResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public UpdateSerfinsaPaymentResponse()
        {
        }

        public SerfinsaPaymentDto SerfinsaPayment { get; set; } = new();
    }
}
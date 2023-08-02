using System;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.PaymentMethod
{
    public class UpdatePaymentMethodResponse : BaseResponse
    {
        public UpdatePaymentMethodResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public UpdatePaymentMethodResponse()
        {
        }

        public PaymentMethodDto PaymentMethod { get; set; } = new();
    }
}
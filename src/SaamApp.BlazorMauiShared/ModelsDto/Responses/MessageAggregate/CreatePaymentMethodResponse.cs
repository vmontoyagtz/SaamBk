using System;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.PaymentMethod
{
    public class CreatePaymentMethodResponse : BaseResponse
    {
        public CreatePaymentMethodResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public CreatePaymentMethodResponse()
        {
        }

        public PaymentMethodDto PaymentMethod { get; set; } = new();
    }
}
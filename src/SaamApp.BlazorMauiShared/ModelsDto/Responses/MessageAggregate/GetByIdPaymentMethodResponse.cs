using System;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.PaymentMethod
{
    public class GetByIdPaymentMethodResponse : BaseResponse
    {
        public GetByIdPaymentMethodResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public GetByIdPaymentMethodResponse()
        {
        }

        public PaymentMethodDto PaymentMethod { get; set; } = new();
    }
}
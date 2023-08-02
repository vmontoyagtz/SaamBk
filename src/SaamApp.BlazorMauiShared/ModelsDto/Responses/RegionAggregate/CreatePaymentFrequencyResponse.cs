using System;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.PaymentFrequency
{
    public class CreatePaymentFrequencyResponse : BaseResponse
    {
        public CreatePaymentFrequencyResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public CreatePaymentFrequencyResponse()
        {
        }

        public PaymentFrequencyDto PaymentFrequency { get; set; } = new();
    }
}
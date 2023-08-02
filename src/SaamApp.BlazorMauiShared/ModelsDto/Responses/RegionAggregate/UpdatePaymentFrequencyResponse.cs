using System;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.PaymentFrequency
{
    public class UpdatePaymentFrequencyResponse : BaseResponse
    {
        public UpdatePaymentFrequencyResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public UpdatePaymentFrequencyResponse()
        {
        }

        public PaymentFrequencyDto PaymentFrequency { get; set; } = new();
    }
}
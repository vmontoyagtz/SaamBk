using System;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.PaymentFrequency
{
    public class GetByIdPaymentFrequencyResponse : BaseResponse
    {
        public GetByIdPaymentFrequencyResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public GetByIdPaymentFrequencyResponse()
        {
        }

        public PaymentFrequencyDto PaymentFrequency { get; set; } = new();
    }
}
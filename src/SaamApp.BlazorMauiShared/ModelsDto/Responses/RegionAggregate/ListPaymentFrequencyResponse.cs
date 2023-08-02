using System;
using System.Collections.Generic;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.PaymentFrequency
{
    public class ListPaymentFrequencyResponse : BaseResponse
    {
        public ListPaymentFrequencyResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public ListPaymentFrequencyResponse()
        {
        }

        public List<PaymentFrequencyDto> PaymentFrequencies { get; set; } = new();

        public int Count { get; set; }
    }
}
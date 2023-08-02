using System;
using System.Collections.Generic;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.PaymentMethod
{
    public class ListPaymentMethodResponse : BaseResponse
    {
        public ListPaymentMethodResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public ListPaymentMethodResponse()
        {
        }

        public List<PaymentMethodDto> PaymentMethods { get; set; } = new();

        public int Count { get; set; }
    }
}
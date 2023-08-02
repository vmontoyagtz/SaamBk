using System;
using System.Collections.Generic;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.SerfinsaPayment
{
    public class ListSerfinsaPaymentResponse : BaseResponse
    {
        public ListSerfinsaPaymentResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public ListSerfinsaPaymentResponse()
        {
        }

        public List<SerfinsaPaymentDto> SerfinsaPayments { get; set; } = new();

        public int Count { get; set; }
    }
}
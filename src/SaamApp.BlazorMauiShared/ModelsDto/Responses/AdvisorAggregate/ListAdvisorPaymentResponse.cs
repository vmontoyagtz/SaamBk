using System;
using System.Collections.Generic;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.AdvisorPayment
{
    public class ListAdvisorPaymentResponse : BaseResponse
    {
        public ListAdvisorPaymentResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public ListAdvisorPaymentResponse()
        {
        }

        public List<AdvisorPaymentDto> AdvisorPayments { get; set; } = new();

        public int Count { get; set; }
    }
}
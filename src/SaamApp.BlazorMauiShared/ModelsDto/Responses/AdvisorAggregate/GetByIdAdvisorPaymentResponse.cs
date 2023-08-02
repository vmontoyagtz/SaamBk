using System;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.AdvisorPayment
{
    public class GetByIdAdvisorPaymentResponse : BaseResponse
    {
        public GetByIdAdvisorPaymentResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public GetByIdAdvisorPaymentResponse()
        {
        }

        public AdvisorPaymentDto AdvisorPayment { get; set; } = new();
    }
}
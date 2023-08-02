using System;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.AdvisorPayment
{
    public class CreateAdvisorPaymentResponse : BaseResponse
    {
        public CreateAdvisorPaymentResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public CreateAdvisorPaymentResponse()
        {
        }

        public AdvisorPaymentDto AdvisorPayment { get; set; } = new();
    }
}
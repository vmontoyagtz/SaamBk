using System;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.AdvisorPayment
{
    public class UpdateAdvisorPaymentResponse : BaseResponse
    {
        public UpdateAdvisorPaymentResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public UpdateAdvisorPaymentResponse()
        {
        }

        public AdvisorPaymentDto AdvisorPayment { get; set; } = new();
    }
}
using System;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.CustomerFeedback
{
    public class GetByIdCustomerFeedbackResponse : BaseResponse
    {
        public GetByIdCustomerFeedbackResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public GetByIdCustomerFeedbackResponse()
        {
        }

        public CustomerFeedbackDto CustomerFeedback { get; set; } = new();
    }
}
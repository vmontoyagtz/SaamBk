using System;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.CustomerFeedback
{
    public class CreateCustomerFeedbackResponse : BaseResponse
    {
        public CreateCustomerFeedbackResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public CreateCustomerFeedbackResponse()
        {
        }

        public CustomerFeedbackDto CustomerFeedback { get; set; } = new();
    }
}
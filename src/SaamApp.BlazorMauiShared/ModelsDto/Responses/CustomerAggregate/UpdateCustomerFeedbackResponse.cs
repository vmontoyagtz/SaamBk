using System;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.CustomerFeedback
{
    public class UpdateCustomerFeedbackResponse : BaseResponse
    {
        public UpdateCustomerFeedbackResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public UpdateCustomerFeedbackResponse()
        {
        }

        public CustomerFeedbackDto CustomerFeedback { get; set; } = new();
    }
}
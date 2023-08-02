using System;

namespace SaamApp.BlazorMauiShared.Models.AiFeedback
{
    public class DeleteAiFeedbackResponse : BaseResponse
    {
        public DeleteAiFeedbackResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public DeleteAiFeedbackResponse()
        {
        }
    }
}
using System;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.AiFeedback
{
    public class CreateAiFeedbackResponse : BaseResponse
    {
        public CreateAiFeedbackResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public CreateAiFeedbackResponse()
        {
        }

        public AiFeedbackDto AiFeedback { get; set; } = new();
    }
}
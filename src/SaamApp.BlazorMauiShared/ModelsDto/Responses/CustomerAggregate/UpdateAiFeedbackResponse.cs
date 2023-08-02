using System;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.AiFeedback
{
    public class UpdateAiFeedbackResponse : BaseResponse
    {
        public UpdateAiFeedbackResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public UpdateAiFeedbackResponse()
        {
        }

        public AiFeedbackDto AiFeedback { get; set; } = new();
    }
}
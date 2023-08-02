using System;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.AiFeedback
{
    public class GetByIdAiFeedbackResponse : BaseResponse
    {
        public GetByIdAiFeedbackResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public GetByIdAiFeedbackResponse()
        {
        }

        public AiFeedbackDto AiFeedback { get; set; } = new();
    }
}
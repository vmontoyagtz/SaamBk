using System;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.AiAreaExpertise
{
    public class CreateAiAreaExpertiseResponse : BaseResponse
    {
        public CreateAiAreaExpertiseResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public CreateAiAreaExpertiseResponse()
        {
        }

        public AiAreaExpertiseDto AiAreaExpertise { get; set; } = new();
    }
}
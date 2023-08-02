using System;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.AiAreaExpertise
{
    public class UpdateAiAreaExpertiseResponse : BaseResponse
    {
        public UpdateAiAreaExpertiseResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public UpdateAiAreaExpertiseResponse()
        {
        }

        public AiAreaExpertiseDto AiAreaExpertise { get; set; } = new();
    }
}
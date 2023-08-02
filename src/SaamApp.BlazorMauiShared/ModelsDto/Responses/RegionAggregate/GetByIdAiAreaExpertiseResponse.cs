using System;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.AiAreaExpertise
{
    public class GetByIdAiAreaExpertiseResponse : BaseResponse
    {
        public GetByIdAiAreaExpertiseResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public GetByIdAiAreaExpertiseResponse()
        {
        }

        public AiAreaExpertiseDto AiAreaExpertise { get; set; } = new();
    }
}
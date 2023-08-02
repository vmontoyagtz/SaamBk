using System;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.AiModel
{
    public class CreateAiModelResponse : BaseResponse
    {
        public CreateAiModelResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public CreateAiModelResponse()
        {
        }

        public AiModelDto AiModel { get; set; } = new();
    }
}
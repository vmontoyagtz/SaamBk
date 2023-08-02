using System;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.AiModel
{
    public class UpdateAiModelResponse : BaseResponse
    {
        public UpdateAiModelResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public UpdateAiModelResponse()
        {
        }

        public AiModelDto AiModel { get; set; } = new();
    }
}
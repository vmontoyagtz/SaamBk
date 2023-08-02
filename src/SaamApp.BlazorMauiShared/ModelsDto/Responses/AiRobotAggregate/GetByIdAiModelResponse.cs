using System;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.AiModel
{
    public class GetByIdAiModelResponse : BaseResponse
    {
        public GetByIdAiModelResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public GetByIdAiModelResponse()
        {
        }

        public AiModelDto AiModel { get; set; } = new();
    }
}
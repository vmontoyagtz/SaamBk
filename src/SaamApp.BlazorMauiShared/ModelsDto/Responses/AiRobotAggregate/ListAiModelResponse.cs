using System;
using System.Collections.Generic;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.AiModel
{
    public class ListAiModelResponse : BaseResponse
    {
        public ListAiModelResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public ListAiModelResponse()
        {
        }

        public List<AiModelDto> AiModels { get; set; } = new();

        public int Count { get; set; }
    }
}
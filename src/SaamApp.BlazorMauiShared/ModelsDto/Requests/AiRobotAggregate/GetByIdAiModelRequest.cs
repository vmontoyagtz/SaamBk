using System;

namespace SaamApp.BlazorMauiShared.Models.AiModel
{
    public class GetByIdAiModelRequest : BaseRequest
    {
        public Guid AiModelId { get; set; }
    }
}
using System;

namespace SaamApp.BlazorMauiShared.Models.AiModel
{
    public class DeleteAiModelRequest : BaseRequest
    {
        public Guid AiModelId { get; set; }
    }
}
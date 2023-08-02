using System;

namespace SaamApp.BlazorMauiShared.Models.AiMemory
{
    public class DeleteAiMemoryRequest : BaseRequest
    {
        public Guid AiMemoryId { get; set; }
    }
}
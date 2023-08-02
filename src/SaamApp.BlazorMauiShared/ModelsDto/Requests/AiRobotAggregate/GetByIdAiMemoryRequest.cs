using System;

namespace SaamApp.BlazorMauiShared.Models.AiMemory
{
    public class GetByIdAiMemoryRequest : BaseRequest
    {
        public Guid AiMemoryId { get; set; }
    }
}
using System;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.AiMemory
{
    public class CreateAiMemoryResponse : BaseResponse
    {
        public CreateAiMemoryResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public CreateAiMemoryResponse()
        {
        }

        public AiMemoryDto AiMemory { get; set; } = new();
    }
}
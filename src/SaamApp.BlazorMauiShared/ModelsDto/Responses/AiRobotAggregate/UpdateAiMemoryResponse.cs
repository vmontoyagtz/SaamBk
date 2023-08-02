using System;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.AiMemory
{
    public class UpdateAiMemoryResponse : BaseResponse
    {
        public UpdateAiMemoryResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public UpdateAiMemoryResponse()
        {
        }

        public AiMemoryDto AiMemory { get; set; } = new();
    }
}
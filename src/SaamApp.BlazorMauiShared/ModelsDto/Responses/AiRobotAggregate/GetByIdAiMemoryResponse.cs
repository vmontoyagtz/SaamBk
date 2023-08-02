using System;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.AiMemory
{
    public class GetByIdAiMemoryResponse : BaseResponse
    {
        public GetByIdAiMemoryResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public GetByIdAiMemoryResponse()
        {
        }

        public AiMemoryDto AiMemory { get; set; } = new();
    }
}
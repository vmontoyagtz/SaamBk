using System;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.AiMemory
{
    public class UpdateAiMemoryRequest : BaseRequest
    {
        public Guid AiMemoryId { get; set; }
        public Guid ModelId { get; set; }
        public string? Question { get; set; }
        public string? Response { get; set; }
        public DateTime InteractionTime { get; set; }
        public Guid TenantId { get; set; }

        public static UpdateAiMemoryRequest FromDto(AiMemoryDto aiMemoryDto)
        {
            return new UpdateAiMemoryRequest
            {
                AiMemoryId = aiMemoryDto.AiMemoryId,
                ModelId = aiMemoryDto.ModelId,
                Question = aiMemoryDto.Question,
                Response = aiMemoryDto.Response,
                InteractionTime = aiMemoryDto.InteractionTime,
                TenantId = aiMemoryDto.TenantId
            };
        }
    }
}
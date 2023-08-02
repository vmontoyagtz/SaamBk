using System;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.AiErrorLog
{
    public class UpdateAiErrorLogRequest : BaseRequest
    {
        public Guid AiErrorLogId { get; set; }
        public Guid ModelId { get; set; }
        public DateTime ErrorTime { get; set; }
        public string? ErrorMessage { get; set; }
        public Guid TenantId { get; set; }

        public static UpdateAiErrorLogRequest FromDto(AiErrorLogDto aiErrorLogDto)
        {
            return new UpdateAiErrorLogRequest
            {
                AiErrorLogId = aiErrorLogDto.AiErrorLogId,
                ModelId = aiErrorLogDto.ModelId,
                ErrorTime = aiErrorLogDto.ErrorTime,
                ErrorMessage = aiErrorLogDto.ErrorMessage,
                TenantId = aiErrorLogDto.TenantId
            };
        }
    }
}
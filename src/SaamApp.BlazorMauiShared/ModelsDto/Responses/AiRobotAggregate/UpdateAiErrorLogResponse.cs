using System;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.AiErrorLog
{
    public class UpdateAiErrorLogResponse : BaseResponse
    {
        public UpdateAiErrorLogResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public UpdateAiErrorLogResponse()
        {
        }

        public AiErrorLogDto AiErrorLog { get; set; } = new();
    }
}
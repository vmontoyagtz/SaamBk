using System;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.AiErrorLog
{
    public class CreateAiErrorLogResponse : BaseResponse
    {
        public CreateAiErrorLogResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public CreateAiErrorLogResponse()
        {
        }

        public AiErrorLogDto AiErrorLog { get; set; } = new();
    }
}
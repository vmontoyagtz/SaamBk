using System;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.AiErrorLog
{
    public class GetByIdAiErrorLogResponse : BaseResponse
    {
        public GetByIdAiErrorLogResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public GetByIdAiErrorLogResponse()
        {
        }

        public AiErrorLogDto AiErrorLog { get; set; } = new();
    }
}
using System;

namespace SaamApp.BlazorMauiShared.Models.AiErrorLog
{
    public class DeleteAiErrorLogResponse : BaseResponse
    {
        public DeleteAiErrorLogResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public DeleteAiErrorLogResponse()
        {
        }
    }
}
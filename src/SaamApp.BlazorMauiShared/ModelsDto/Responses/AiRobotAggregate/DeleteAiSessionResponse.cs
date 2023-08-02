using System;

namespace SaamApp.BlazorMauiShared.Models.AiSession
{
    public class DeleteAiSessionResponse : BaseResponse
    {
        public DeleteAiSessionResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public DeleteAiSessionResponse()
        {
        }
    }
}
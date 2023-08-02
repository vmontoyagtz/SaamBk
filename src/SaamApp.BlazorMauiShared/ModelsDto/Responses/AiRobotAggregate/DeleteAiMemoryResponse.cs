using System;

namespace SaamApp.BlazorMauiShared.Models.AiMemory
{
    public class DeleteAiMemoryResponse : BaseResponse
    {
        public DeleteAiMemoryResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public DeleteAiMemoryResponse()
        {
        }
    }
}
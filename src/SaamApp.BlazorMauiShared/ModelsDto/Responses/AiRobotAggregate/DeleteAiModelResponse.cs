using System;

namespace SaamApp.BlazorMauiShared.Models.AiModel
{
    public class DeleteAiModelResponse : BaseResponse
    {
        public DeleteAiModelResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public DeleteAiModelResponse()
        {
        }
    }
}
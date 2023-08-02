using System;

namespace SaamApp.BlazorMauiShared.Models.AiAreaExpertise
{
    public class DeleteAiAreaExpertiseResponse : BaseResponse
    {
        public DeleteAiAreaExpertiseResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public DeleteAiAreaExpertiseResponse()
        {
        }
    }
}
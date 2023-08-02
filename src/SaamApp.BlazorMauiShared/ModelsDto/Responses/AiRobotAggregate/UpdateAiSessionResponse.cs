using System;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.AiSession
{
    public class UpdateAiSessionResponse : BaseResponse
    {
        public UpdateAiSessionResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public UpdateAiSessionResponse()
        {
        }

        public AiSessionDto AiSession { get; set; } = new();
    }
}
using System;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.AiSession
{
    public class CreateAiSessionResponse : BaseResponse
    {
        public CreateAiSessionResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public CreateAiSessionResponse()
        {
        }

        public AiSessionDto AiSession { get; set; } = new();
    }
}
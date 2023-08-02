using System;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.AiSession
{
    public class GetByIdAiSessionResponse : BaseResponse
    {
        public GetByIdAiSessionResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public GetByIdAiSessionResponse()
        {
        }

        public AiSessionDto AiSession { get; set; } = new();
    }
}
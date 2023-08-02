using System;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.AiSession
{
    public class UpdateAiSessionRequest : BaseRequest
    {
        public Guid AiSessionId { get; set; }
        public Guid CustomerId { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public int NumberOfInteractions { get; set; }

        public static UpdateAiSessionRequest FromDto(AiSessionDto aiSessionDto)
        {
            return new UpdateAiSessionRequest
            {
                AiSessionId = aiSessionDto.AiSessionId,
                CustomerId = aiSessionDto.CustomerId,
                StartTime = aiSessionDto.StartTime,
                EndTime = aiSessionDto.EndTime,
                NumberOfInteractions = aiSessionDto.NumberOfInteractions
            };
        }
    }
}
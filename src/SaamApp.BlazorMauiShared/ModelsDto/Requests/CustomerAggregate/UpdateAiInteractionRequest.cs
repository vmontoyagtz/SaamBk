using System;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.AiInteraction
{
    public class UpdateAiInteractionRequest : BaseRequest
    {
        public Guid AiInteractionId { get; set; }
        public Guid AiRobotId { get; set; }
        public Guid CustomerId { get; set; }
        public Guid SessionId { get; set; }
        public string? Question { get; set; }
        public string? Answer { get; set; }
        public DateTime InteractionTime { get; set; }
        public bool IsSuccessful { get; set; }

        public static UpdateAiInteractionRequest FromDto(AiInteractionDto aiInteractionDto)
        {
            return new UpdateAiInteractionRequest
            {
                AiInteractionId = aiInteractionDto.AiInteractionId,
                AiRobotId = aiInteractionDto.AiRobotId,
                CustomerId = aiInteractionDto.CustomerId,
                SessionId = aiInteractionDto.SessionId,
                Question = aiInteractionDto.Question,
                Answer = aiInteractionDto.Answer,
                InteractionTime = aiInteractionDto.InteractionTime,
                IsSuccessful = aiInteractionDto.IsSuccessful
            };
        }
    }
}
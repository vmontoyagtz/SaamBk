using System;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.AiFeedback
{
    public class UpdateAiFeedbackRequest : BaseRequest
    {
        public Guid AiFeedbackId { get; set; }
        public Guid CustomerId { get; set; }
        public Guid ModelId { get; set; }
        public string? Question { get; set; }
        public string? Response { get; set; }
        public bool? UserFeedback { get; set; }
        public Guid AISessionId { get; set; }
        public DateTime InteractionTime { get; set; }

        public static UpdateAiFeedbackRequest FromDto(AiFeedbackDto aiFeedbackDto)
        {
            return new UpdateAiFeedbackRequest
            {
                AiFeedbackId = aiFeedbackDto.AiFeedbackId,
                CustomerId = aiFeedbackDto.CustomerId,
                ModelId = aiFeedbackDto.ModelId,
                Question = aiFeedbackDto.Question,
                Response = aiFeedbackDto.Response,
                UserFeedback = aiFeedbackDto.UserFeedback,
                AISessionId = aiFeedbackDto.AISessionId,
                InteractionTime = aiFeedbackDto.InteractionTime
            };
        }
    }
}
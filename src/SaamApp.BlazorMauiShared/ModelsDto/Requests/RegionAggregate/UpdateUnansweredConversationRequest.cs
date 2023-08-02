using System;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.UnansweredConversation
{
    public class UpdateUnansweredConversationRequest : BaseRequest
    {
        public Guid UnansweredConversationId { get; set; }
        public Guid CustomerId { get; set; }
        public Guid InteractionTypeId { get; set; }
        public Guid RegionAreaAdvisorCategoryId { get; set; }
        public string UnansweredConversationQuestion { get; set; }
        public DateTime? UnansweredConversationAnsweredTime { get; set; }
        public bool? Answered { get; set; }
        public bool? Canceled { get; set; }
        public bool? Unanswered { get; set; }
        public bool? AiRobot { get; set; }
        public DateTime CreatedAt { get; set; }
        public Guid CreatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public Guid? UpdatedBy { get; set; }
        public bool? IsDeleted { get; set; }
        public Guid TenantId { get; set; }

        public static UpdateUnansweredConversationRequest FromDto(UnansweredConversationDto unansweredConversationDto)
        {
            return new UpdateUnansweredConversationRequest
            {
                UnansweredConversationId = unansweredConversationDto.UnansweredConversationId,
                CustomerId = unansweredConversationDto.CustomerId,
                InteractionTypeId = unansweredConversationDto.InteractionTypeId,
                RegionAreaAdvisorCategoryId = unansweredConversationDto.RegionAreaAdvisorCategoryId,
                UnansweredConversationQuestion = unansweredConversationDto.UnansweredConversationQuestion,
                UnansweredConversationAnsweredTime = unansweredConversationDto.UnansweredConversationAnsweredTime,
                Answered = unansweredConversationDto.Answered,
                Canceled = unansweredConversationDto.Canceled,
                Unanswered = unansweredConversationDto.Unanswered,
                AiRobot = unansweredConversationDto.AiRobot,
                CreatedAt = unansweredConversationDto.CreatedAt,
                CreatedBy = unansweredConversationDto.CreatedBy,
                UpdatedAt = unansweredConversationDto.UpdatedAt,
                UpdatedBy = unansweredConversationDto.UpdatedBy,
                IsDeleted = unansweredConversationDto.IsDeleted,
                TenantId = unansweredConversationDto.TenantId
            };
        }
    }
}
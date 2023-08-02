using System;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.Conversation
{
    public class UpdateConversationRequest : BaseRequest
    {
        public Guid ConversationId { get; set; }
        public Guid InteractionTypeId { get; set; }
        public Guid RegionAreaAdvisorCategoryId { get; set; }
        public Guid UnansweredConversationId { get; set; }
        public string ReconnectConversationId { get; set; }
        public int ConversationSumTimeInSecs { get; set; }
        public decimal ConversationSumSpent { get; set; }
        public bool? LostSignalCustomer { get; set; }
        public bool? LostSignalAdvisor { get; set; }
        public bool? CanceledByCustomer { get; set; }
        public bool? CanceledByAdvisor { get; set; }
        public bool? EndedByNoBalance { get; set; }
        public bool? StillActive { get; set; }
        public DateTime CreatedAt { get; set; }
        public Guid CreatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public Guid? UpdatedBy { get; set; }
        public bool? IsDeleted { get; set; }
        public Guid TenantId { get; set; }

        public static UpdateConversationRequest FromDto(ConversationDto conversationDto)
        {
            return new UpdateConversationRequest
            {
                ConversationId = conversationDto.ConversationId,
                InteractionTypeId = conversationDto.InteractionTypeId,
                RegionAreaAdvisorCategoryId = conversationDto.RegionAreaAdvisorCategoryId,
                UnansweredConversationId = conversationDto.UnansweredConversationId,
                ReconnectConversationId = conversationDto.ReconnectConversationId,
                ConversationSumTimeInSecs = conversationDto.ConversationSumTimeInSecs,
                ConversationSumSpent = conversationDto.ConversationSumSpent,
                LostSignalCustomer = conversationDto.LostSignalCustomer,
                LostSignalAdvisor = conversationDto.LostSignalAdvisor,
                CanceledByCustomer = conversationDto.CanceledByCustomer,
                CanceledByAdvisor = conversationDto.CanceledByAdvisor,
                EndedByNoBalance = conversationDto.EndedByNoBalance,
                StillActive = conversationDto.StillActive,
                CreatedAt = conversationDto.CreatedAt,
                CreatedBy = conversationDto.CreatedBy,
                UpdatedAt = conversationDto.UpdatedAt,
                UpdatedBy = conversationDto.UpdatedBy,
                IsDeleted = conversationDto.IsDeleted,
                TenantId = conversationDto.TenantId
            };
        }
    }
}
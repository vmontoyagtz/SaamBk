using System;

namespace SaamApp.BlazorMauiShared.Models.UnansweredConversation
{
    public class CreateUnansweredConversationRequest : BaseRequest
    {
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
    }
}
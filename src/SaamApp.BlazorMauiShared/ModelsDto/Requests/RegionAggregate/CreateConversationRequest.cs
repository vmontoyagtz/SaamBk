using System;

namespace SaamApp.BlazorMauiShared.Models.Conversation
{
    public class CreateConversationRequest : BaseRequest
    {
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
    }
}
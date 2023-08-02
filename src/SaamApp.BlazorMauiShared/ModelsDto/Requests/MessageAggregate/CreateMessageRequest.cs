using System;

namespace SaamApp.BlazorMauiShared.Models.Message
{
    public class CreateMessageRequest : BaseRequest
    {
        public Guid AdvisorId { get; set; }
        public Guid ConversationId { get; set; }
        public Guid CustomerId { get; set; }
        public Guid InteractionTypeId { get; set; }
        public Guid MessageTypeId { get; set; }
        public Guid ProductId { get; set; }
        public Guid RegionAreaAdvisorCategoryId { get; set; }
        public string MessageContent { get; set; }
        public int MessageDetailTimeInSecs { get; set; }
        public decimal MessageDetailSpent { get; set; }
        public Guid TemplatetId { get; set; }
        public Guid ReplyToMessageId { get; set; }
        public bool SentByAdvisor { get; set; }
        public bool SentByCustomer { get; set; }
        public bool HasBeenReadByCustomer { get; set; }
        public bool HasBeenReadByAdvisor { get; set; }
        public DateTime? ReadByCustomerAt { get; set; }
        public DateTime? ReadByAdvisorAt { get; set; }
        public bool HasAttachments { get; set; }
        public bool AiRobot { get; set; }
        public bool IsChat { get; set; }
        public bool IsVoiceCall { get; set; }
        public bool IsVideoCall { get; set; }
        public bool IsVoiceNote { get; set; }
        public bool? VoiceNoteApproved { get; set; }
        public decimal? VoiceNoteSize { get; set; }
        public bool? LowBalance { get; set; }
        public DateTime CreatedAt { get; set; }
        public Guid CreatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public Guid? UpdatedBy { get; set; }
        public bool? IsDeleted { get; set; }
        public Guid TenantId { get; set; }
    }
}
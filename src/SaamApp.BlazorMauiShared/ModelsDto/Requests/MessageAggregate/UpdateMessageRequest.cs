using System;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.Message
{
    public class UpdateMessageRequest : BaseRequest
    {
        public Guid MessageId { get; set; }
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

        public static UpdateMessageRequest FromDto(MessageDto messageDto)
        {
            return new UpdateMessageRequest
            {
                MessageId = messageDto.MessageId,
                AdvisorId = messageDto.AdvisorId,
                ConversationId = messageDto.ConversationId,
                CustomerId = messageDto.CustomerId,
                InteractionTypeId = messageDto.InteractionTypeId,
                MessageTypeId = messageDto.MessageTypeId,
                ProductId = messageDto.ProductId,
                RegionAreaAdvisorCategoryId = messageDto.RegionAreaAdvisorCategoryId,
                MessageContent = messageDto.MessageContent,
                MessageDetailTimeInSecs = messageDto.MessageDetailTimeInSecs,
                MessageDetailSpent = messageDto.MessageDetailSpent,
                TemplatetId = messageDto.TemplatetId,
                ReplyToMessageId = messageDto.ReplyToMessageId,
                SentByAdvisor = messageDto.SentByAdvisor,
                SentByCustomer = messageDto.SentByCustomer,
                HasBeenReadByCustomer = messageDto.HasBeenReadByCustomer,
                HasBeenReadByAdvisor = messageDto.HasBeenReadByAdvisor,
                ReadByCustomerAt = messageDto.ReadByCustomerAt,
                ReadByAdvisorAt = messageDto.ReadByAdvisorAt,
                HasAttachments = messageDto.HasAttachments,
                AiRobot = messageDto.AiRobot,
                IsChat = messageDto.IsChat,
                IsVoiceCall = messageDto.IsVoiceCall,
                IsVideoCall = messageDto.IsVideoCall,
                IsVoiceNote = messageDto.IsVoiceNote,
                VoiceNoteApproved = messageDto.VoiceNoteApproved,
                VoiceNoteSize = messageDto.VoiceNoteSize,
                LowBalance = messageDto.LowBalance,
                CreatedAt = messageDto.CreatedAt,
                CreatedBy = messageDto.CreatedBy,
                UpdatedAt = messageDto.UpdatedAt,
                UpdatedBy = messageDto.UpdatedBy,
                IsDeleted = messageDto.IsDeleted,
                TenantId = messageDto.TenantId
            };
        }
    }
}
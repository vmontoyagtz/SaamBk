using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Ardalis.GuardClauses;

namespace SaamApp.Domain.ModelsDto
{
    public class MessageDto
    {
        public MessageDto() { } // AutoMapper required

        public MessageDto(Guid messageId, Guid advisorId, Guid conversationId, Guid customerId, Guid interactionTypeId,
            Guid messageTypeId, Guid productId, Guid regionAreaAdvisorCategoryId, string messageContent,
            int messageDetailTimeInSecs, decimal messageDetailSpent, Guid templatetId, Guid replyToMessageId,
            bool sentByAdvisor, bool sentByCustomer, bool hasBeenReadByCustomer, bool hasBeenReadByAdvisor,
            DateTime? readByCustomerAt, DateTime? readByAdvisorAt, bool hasAttachments, bool aiRobot, bool isChat,
            bool isVoiceCall, bool isVideoCall, bool isVoiceNote, bool? voiceNoteApproved, decimal? voiceNoteSize,
            bool? lowBalance, DateTime createdAt, Guid createdBy, DateTime? updatedAt, Guid? updatedBy, bool? isDeleted,
            Guid tenantId)
        {
            MessageId = Guard.Against.NullOrEmpty(messageId, nameof(messageId));
            AdvisorId = Guard.Against.NullOrEmpty(advisorId, nameof(advisorId));
            ConversationId = Guard.Against.NullOrEmpty(conversationId, nameof(conversationId));
            CustomerId = Guard.Against.NullOrEmpty(customerId, nameof(customerId));
            InteractionTypeId = Guard.Against.NullOrEmpty(interactionTypeId, nameof(interactionTypeId));
            MessageTypeId = Guard.Against.NullOrEmpty(messageTypeId, nameof(messageTypeId));
            ProductId = Guard.Against.NullOrEmpty(productId, nameof(productId));
            RegionAreaAdvisorCategoryId =
                Guard.Against.NullOrEmpty(regionAreaAdvisorCategoryId, nameof(regionAreaAdvisorCategoryId));
            MessageContent = Guard.Against.NullOrWhiteSpace(messageContent, nameof(messageContent));
            MessageDetailTimeInSecs =
                Guard.Against.NegativeOrZero(messageDetailTimeInSecs, nameof(messageDetailTimeInSecs));
            MessageDetailSpent = Guard.Against.Negative(messageDetailSpent, nameof(messageDetailSpent));
            TemplatetId = Guard.Against.NullOrEmpty(templatetId, nameof(templatetId));
            ReplyToMessageId = Guard.Against.NullOrEmpty(replyToMessageId, nameof(replyToMessageId));
            SentByAdvisor = Guard.Against.Null(sentByAdvisor, nameof(sentByAdvisor));
            SentByCustomer = Guard.Against.Null(sentByCustomer, nameof(sentByCustomer));
            HasBeenReadByCustomer = Guard.Against.Null(hasBeenReadByCustomer, nameof(hasBeenReadByCustomer));
            HasBeenReadByAdvisor = Guard.Against.Null(hasBeenReadByAdvisor, nameof(hasBeenReadByAdvisor));
            ReadByCustomerAt = readByCustomerAt;
            ReadByAdvisorAt = readByAdvisorAt;
            HasAttachments = Guard.Against.Null(hasAttachments, nameof(hasAttachments));
            AiRobot = Guard.Against.Null(aiRobot, nameof(aiRobot));
            IsChat = Guard.Against.Null(isChat, nameof(isChat));
            IsVoiceCall = Guard.Against.Null(isVoiceCall, nameof(isVoiceCall));
            IsVideoCall = Guard.Against.Null(isVideoCall, nameof(isVideoCall));
            IsVoiceNote = Guard.Against.Null(isVoiceNote, nameof(isVoiceNote));
            VoiceNoteApproved = voiceNoteApproved;
            VoiceNoteSize = voiceNoteSize;
            LowBalance = lowBalance;
            CreatedAt = Guard.Against.OutOfSQLDateRange(createdAt, nameof(createdAt));
            CreatedBy = Guard.Against.NullOrEmpty(createdBy, nameof(createdBy));
            UpdatedAt = updatedAt;
            UpdatedBy = updatedBy;
            IsDeleted = isDeleted;
            TenantId = Guard.Against.NullOrEmpty(tenantId, nameof(tenantId));
        }

        public Guid MessageId { get; set; }

        [Required(ErrorMessage = "Message Content is required")]
        [MaxLength(100)]
        public string MessageContent { get; set; }

        [Required(ErrorMessage = "Message Detail Time In Sec is required")]
        public int MessageDetailTimeInSecs { get; set; }

        [Required(ErrorMessage = "Message Detail Spent is required")]
        public decimal MessageDetailSpent { get; set; }

        [Required(ErrorMessage = "Templatet Id is required")]
        public Guid TemplatetId { get; set; }

        [Required(ErrorMessage = "Reply To Message Id is required")]
        public Guid ReplyToMessageId { get; set; }

        [Required(ErrorMessage = "Sent By Advisor is required")]
        public bool SentByAdvisor { get; set; }

        [Required(ErrorMessage = "Sent By Customer is required")]
        public bool SentByCustomer { get; set; }

        [Required(ErrorMessage = "Has Been Read By Customer is required")]
        public bool HasBeenReadByCustomer { get; set; }

        [Required(ErrorMessage = "Has Been Read By Advisor is required")]
        public bool HasBeenReadByAdvisor { get; set; }

        public DateTime? ReadByCustomerAt { get; set; }

        public DateTime? ReadByAdvisorAt { get; set; }

        [Required(ErrorMessage = "Has Attachment is required")]
        public bool HasAttachments { get; set; }

        [Required(ErrorMessage = "Ai Robot is required")]
        public bool AiRobot { get; set; }

        [Required(ErrorMessage = "Is Chat is required")]
        public bool IsChat { get; set; }

        [Required(ErrorMessage = "Is Voice Call is required")]
        public bool IsVoiceCall { get; set; }

        [Required(ErrorMessage = "Is Video Call is required")]
        public bool IsVideoCall { get; set; }

        [Required(ErrorMessage = "Is Voice Note is required")]
        public bool IsVoiceNote { get; set; }

        public bool? VoiceNoteApproved { get; set; }

        public decimal? VoiceNoteSize { get; set; }

        public bool? LowBalance { get; set; }

        [Required(ErrorMessage = "Created At is required")]
        public DateTime CreatedAt { get; set; }

        [Required(ErrorMessage = "Created By is required")]
        public Guid CreatedBy { get; set; }

        public DateTime? UpdatedAt { get; set; }

        public Guid? UpdatedBy { get; set; }

        public bool? IsDeleted { get; set; }

        [Required(ErrorMessage = "Tenant Id is required")]
        public Guid TenantId { get; set; }

        public AdvisorDto Advisor { get; set; }

        [Required(ErrorMessage = "Advisor is required")]
        public Guid AdvisorId { get; set; }

        public ConversationDto Conversation { get; set; }

        [Required(ErrorMessage = "Conversation is required")]
        public Guid ConversationId { get; set; }

        public CustomerDto Customer { get; set; }

        [Required(ErrorMessage = "Customer is required")]
        public Guid CustomerId { get; set; }

        public InteractionTypeDto InteractionType { get; set; }

        [Required(ErrorMessage = "Interaction Type is required")]
        public Guid InteractionTypeId { get; set; }

        public MessageTypeDto MessageType { get; set; }

        [Required(ErrorMessage = "Message Type is required")]
        public Guid MessageTypeId { get; set; }

        public ProductDto Product { get; set; }

        [Required(ErrorMessage = "Product is required")]
        public Guid ProductId { get; set; }

        public RegionAreaAdvisorCategoryDto RegionAreaAdvisorCategory { get; set; }

        [Required(ErrorMessage = "Region Area Advisor Category is required")]
        public Guid RegionAreaAdvisorCategoryId { get; set; }

        public List<MessageDocumentDto> MessageDocuments { get; set; } = new();
        public List<VoiceNoteDocumentDto> VoiceNoteDocuments { get; set; } = new();
    }
}
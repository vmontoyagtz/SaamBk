using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Ardalis.GuardClauses;
using SaamAppLib.SharedKernel;
using SaamAppLib.SharedKernel.Interfaces;

namespace SaamApp.Domain.Entities
{
    public class Message : BaseEntityEv<Guid>, IAggregateRoot
    {
        private readonly List<MessageDocument> _messageDocuments = new();

        private readonly List<VoiceNoteDocument> _voiceNoteDocuments = new();


        private Message() { } // EF required

        //[SetsRequiredMembers]
        public Message(Guid messageId, Guid advisorId, Guid conversationId, Guid customerId, Guid interactionTypeId,
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

        [Key] public Guid MessageId { get; private set; }

        public string MessageContent { get; private set; }

        public int MessageDetailTimeInSecs { get; private set; }

        public decimal MessageDetailSpent { get; private set; }

        public Guid TemplatetId { get; private set; }

        public Guid ReplyToMessageId { get; private set; }

        public bool SentByAdvisor { get; private set; }

        public bool SentByCustomer { get; private set; }

        public bool HasBeenReadByCustomer { get; private set; }

        public bool HasBeenReadByAdvisor { get; private set; }

        public DateTime? ReadByCustomerAt { get; private set; }

        public DateTime? ReadByAdvisorAt { get; private set; }

        public bool HasAttachments { get; private set; }

        public bool AiRobot { get; private set; }

        public bool IsChat { get; private set; }

        public bool IsVoiceCall { get; private set; }

        public bool IsVideoCall { get; private set; }

        public bool IsVoiceNote { get; private set; }

        public bool? VoiceNoteApproved { get; private set; }

        public decimal? VoiceNoteSize { get; private set; }

        public bool? LowBalance { get; private set; }

        public DateTime CreatedAt { get; private set; }

        public Guid CreatedBy { get; private set; }

        public DateTime? UpdatedAt { get; private set; }

        public Guid? UpdatedBy { get; private set; }

        public bool? IsDeleted { get; private set; }

        public Guid TenantId { get; private set; }
        public virtual Advisor Advisor { get; private set; }

        public Guid AdvisorId { get; private set; }

        public virtual Conversation Conversation { get; private set; }

        public Guid ConversationId { get; private set; }

        public virtual Customer Customer { get; private set; }

        public Guid CustomerId { get; private set; }

        public virtual InteractionType InteractionType { get; private set; }

        public Guid InteractionTypeId { get; private set; }

        public virtual MessageType MessageType { get; private set; }

        public Guid MessageTypeId { get; private set; }

        public virtual Product Product { get; private set; }

        public Guid ProductId { get; private set; }

        public virtual RegionAreaAdvisorCategory RegionAreaAdvisorCategory { get; private set; }

        public Guid RegionAreaAdvisorCategoryId { get; private set; }
        public IEnumerable<MessageDocument> MessageDocuments => _messageDocuments.AsReadOnly();
        public IEnumerable<VoiceNoteDocument> VoiceNoteDocuments => _voiceNoteDocuments.AsReadOnly();

        public void SetMessageContent(string messageContent)
        {
            MessageContent = Guard.Against.NullOrEmpty(messageContent, nameof(messageContent));
        }
    }
}
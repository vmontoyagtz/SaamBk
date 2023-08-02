using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Ardalis.GuardClauses;
using SaamAppLib.SharedKernel;
using SaamAppLib.SharedKernel.Interfaces;

namespace SaamApp.Domain.Entities
{
    public class UnansweredConversation : BaseEntityEv<Guid>, IAggregateRoot
    {
        private readonly List<Conversation> _conversations = new();


        private UnansweredConversation() { } // EF required

        //[SetsRequiredMembers]
        public UnansweredConversation(Guid unansweredConversationId, Guid customerId, Guid interactionTypeId,
            Guid regionAreaAdvisorCategoryId, string unansweredConversationQuestion,
            DateTime? unansweredConversationAnsweredTime, bool? answered, bool? canceled, bool? unanswered,
            bool? aiRobot, DateTime createdAt, Guid createdBy, DateTime? updatedAt, Guid? updatedBy, bool? isDeleted,
            Guid tenantId)
        {
            UnansweredConversationId =
                Guard.Against.NullOrEmpty(unansweredConversationId, nameof(unansweredConversationId));
            CustomerId = Guard.Against.NullOrEmpty(customerId, nameof(customerId));
            InteractionTypeId = Guard.Against.NullOrEmpty(interactionTypeId, nameof(interactionTypeId));
            RegionAreaAdvisorCategoryId =
                Guard.Against.NullOrEmpty(regionAreaAdvisorCategoryId, nameof(regionAreaAdvisorCategoryId));
            UnansweredConversationQuestion = Guard.Against.NullOrWhiteSpace(unansweredConversationQuestion,
                nameof(unansweredConversationQuestion));
            UnansweredConversationAnsweredTime = unansweredConversationAnsweredTime;
            Answered = answered;
            Canceled = canceled;
            Unanswered = unanswered;
            AiRobot = aiRobot;
            CreatedAt = Guard.Against.OutOfSQLDateRange(createdAt, nameof(createdAt));
            CreatedBy = Guard.Against.NullOrEmpty(createdBy, nameof(createdBy));
            UpdatedAt = updatedAt;
            UpdatedBy = updatedBy;
            IsDeleted = isDeleted;
            TenantId = Guard.Against.NullOrEmpty(tenantId, nameof(tenantId));
        }

        [Key] public Guid UnansweredConversationId { get; private set; }

        public string UnansweredConversationQuestion { get; private set; }

        public DateTime? UnansweredConversationAnsweredTime { get; private set; }

        public bool? Answered { get; private set; }

        public bool? Canceled { get; private set; }

        public bool? Unanswered { get; private set; }

        public bool? AiRobot { get; private set; }

        public DateTime CreatedAt { get; private set; }

        public Guid CreatedBy { get; private set; }

        public DateTime? UpdatedAt { get; private set; }

        public Guid? UpdatedBy { get; private set; }

        public bool? IsDeleted { get; private set; }

        public Guid TenantId { get; private set; }
        public virtual Customer Customer { get; private set; }

        public Guid CustomerId { get; private set; }

        public virtual InteractionType InteractionType { get; private set; }

        public Guid InteractionTypeId { get; private set; }

        public virtual RegionAreaAdvisorCategory RegionAreaAdvisorCategory { get; private set; }

        public Guid RegionAreaAdvisorCategoryId { get; private set; }
        public IEnumerable<Conversation> Conversations => _conversations.AsReadOnly();

        public void SetUnansweredConversationQuestion(string unansweredConversationQuestion)
        {
            UnansweredConversationQuestion = Guard.Against.NullOrEmpty(unansweredConversationQuestion,
                nameof(unansweredConversationQuestion));
        }
    }
}
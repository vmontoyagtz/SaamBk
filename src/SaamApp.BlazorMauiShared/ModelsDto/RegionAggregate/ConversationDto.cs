using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Ardalis.GuardClauses;

namespace SaamApp.Domain.ModelsDto
{
    public class ConversationDto
    {
        public ConversationDto() { } // AutoMapper required

        public ConversationDto(Guid conversationId, Guid interactionTypeId, Guid regionAreaAdvisorCategoryId,
            Guid unansweredConversationId, string reconnectConversationId, int conversationSumTimeInSecs,
            decimal conversationSumSpent, bool? lostSignalCustomer, bool? lostSignalAdvisor, bool? canceledByCustomer,
            bool? canceledByAdvisor, bool? endedByNoBalance, bool? stillActive, DateTime createdAt, Guid createdBy,
            DateTime? updatedAt, Guid? updatedBy, bool? isDeleted, Guid tenantId)
        {
            ConversationId = Guard.Against.NullOrEmpty(conversationId, nameof(conversationId));
            InteractionTypeId = Guard.Against.NullOrEmpty(interactionTypeId, nameof(interactionTypeId));
            RegionAreaAdvisorCategoryId =
                Guard.Against.NullOrEmpty(regionAreaAdvisorCategoryId, nameof(regionAreaAdvisorCategoryId));
            UnansweredConversationId =
                Guard.Against.NullOrEmpty(unansweredConversationId, nameof(unansweredConversationId));
            ReconnectConversationId =
                Guard.Against.NullOrWhiteSpace(reconnectConversationId, nameof(reconnectConversationId));
            ConversationSumTimeInSecs =
                Guard.Against.NegativeOrZero(conversationSumTimeInSecs, nameof(conversationSumTimeInSecs));
            ConversationSumSpent = Guard.Against.Negative(conversationSumSpent, nameof(conversationSumSpent));
            LostSignalCustomer = lostSignalCustomer;
            LostSignalAdvisor = lostSignalAdvisor;
            CanceledByCustomer = canceledByCustomer;
            CanceledByAdvisor = canceledByAdvisor;
            EndedByNoBalance = endedByNoBalance;
            StillActive = stillActive;
            CreatedAt = Guard.Against.OutOfSQLDateRange(createdAt, nameof(createdAt));
            CreatedBy = Guard.Against.NullOrEmpty(createdBy, nameof(createdBy));
            UpdatedAt = updatedAt;
            UpdatedBy = updatedBy;
            IsDeleted = isDeleted;
            TenantId = Guard.Against.NullOrEmpty(tenantId, nameof(tenantId));
        }

        public Guid ConversationId { get; set; }

        [Required(ErrorMessage = "Reconnect Conversation Id is required")]
        [MaxLength(100)]
        public string ReconnectConversationId { get; set; }

        [Required(ErrorMessage = "Conversation Sum Time In Sec is required")]
        public int ConversationSumTimeInSecs { get; set; }

        [Required(ErrorMessage = "Conversation Sum Spent is required")]
        public decimal ConversationSumSpent { get; set; }

        public bool? LostSignalCustomer { get; set; }

        public bool? LostSignalAdvisor { get; set; }

        public bool? CanceledByCustomer { get; set; }

        public bool? CanceledByAdvisor { get; set; }

        public bool? EndedByNoBalance { get; set; }

        public bool? StillActive { get; set; }

        [Required(ErrorMessage = "Created At is required")]
        public DateTime CreatedAt { get; set; }

        [Required(ErrorMessage = "Created By is required")]
        public Guid CreatedBy { get; set; }

        public DateTime? UpdatedAt { get; set; }

        public Guid? UpdatedBy { get; set; }

        public bool? IsDeleted { get; set; }

        [Required(ErrorMessage = "Tenant Id is required")]
        public Guid TenantId { get; set; }

        public InteractionTypeDto InteractionType { get; set; }

        [Required(ErrorMessage = "Interaction Type is required")]
        public Guid InteractionTypeId { get; set; }

        public RegionAreaAdvisorCategoryDto RegionAreaAdvisorCategory { get; set; }

        [Required(ErrorMessage = "Region Area Advisor Category is required")]
        public Guid RegionAreaAdvisorCategoryId { get; set; }

        public UnansweredConversationDto UnansweredConversation { get; set; }

        [Required(ErrorMessage = "Unanswered Conversation is required")]
        public Guid UnansweredConversationId { get; set; }

        public List<AdvisorRatingDto> AdvisorRatings { get; set; } = new();
        public List<ConversationPaymentDto> ConversationPayments { get; set; } = new();
        public List<MessageDto> Messages { get; set; } = new();
    }
}
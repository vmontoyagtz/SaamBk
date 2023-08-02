using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Ardalis.GuardClauses;

namespace SaamApp.Domain.ModelsDto
{
    public class UnansweredConversationDto
    {
        public UnansweredConversationDto() { } // AutoMapper required

        public UnansweredConversationDto(Guid unansweredConversationId, Guid customerId, Guid interactionTypeId,
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

        public Guid UnansweredConversationId { get; set; }

        [Required(ErrorMessage = "Unanswered Conversation Question is required")]
        [MaxLength(100)]
        public string UnansweredConversationQuestion { get; set; }

        public DateTime? UnansweredConversationAnsweredTime { get; set; }

        public bool? Answered { get; set; }

        public bool? Canceled { get; set; }

        public bool? Unanswered { get; set; }

        public bool? AiRobot { get; set; }

        [Required(ErrorMessage = "Created At is required")]
        public DateTime CreatedAt { get; set; }

        [Required(ErrorMessage = "Created By is required")]
        public Guid CreatedBy { get; set; }

        public DateTime? UpdatedAt { get; set; }

        public Guid? UpdatedBy { get; set; }

        public bool? IsDeleted { get; set; }

        [Required(ErrorMessage = "Tenant Id is required")]
        public Guid TenantId { get; set; }

        public CustomerDto Customer { get; set; }

        [Required(ErrorMessage = "Customer is required")]
        public Guid CustomerId { get; set; }

        public InteractionTypeDto InteractionType { get; set; }

        [Required(ErrorMessage = "Interaction Type is required")]
        public Guid InteractionTypeId { get; set; }

        public RegionAreaAdvisorCategoryDto RegionAreaAdvisorCategory { get; set; }

        [Required(ErrorMessage = "Region Area Advisor Category is required")]
        public Guid RegionAreaAdvisorCategoryId { get; set; }

        public List<ConversationDto> Conversations { get; set; } = new();
    }
}
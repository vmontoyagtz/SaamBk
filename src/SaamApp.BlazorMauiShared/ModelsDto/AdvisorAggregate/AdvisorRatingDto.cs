using System;
using System.ComponentModel.DataAnnotations;
using Ardalis.GuardClauses;

namespace SaamApp.Domain.ModelsDto
{
    public class AdvisorRatingDto
    {
        public AdvisorRatingDto() { } // AutoMapper required

        public AdvisorRatingDto(Guid advisorId, Guid conversationId, Guid customerId, Guid ratingReasonId,
            string? advisorRatingFeedback, int advisorRatingRate, DateTime advisorRatingDate)
        {
            AdvisorId = Guard.Against.NullOrEmpty(advisorId, nameof(advisorId));
            ConversationId = Guard.Against.NullOrEmpty(conversationId, nameof(conversationId));
            CustomerId = Guard.Against.NullOrEmpty(customerId, nameof(customerId));
            RatingReasonId = Guard.Against.NullOrEmpty(ratingReasonId, nameof(ratingReasonId));
            AdvisorRatingFeedback = advisorRatingFeedback;
            AdvisorRatingRate = Guard.Against.NegativeOrZero(advisorRatingRate, nameof(advisorRatingRate));
            AdvisorRatingDate = Guard.Against.OutOfSQLDateRange(advisorRatingDate, nameof(advisorRatingDate));
        }

        public int RowId { get; set; }

        [MaxLength(100)] public string? AdvisorRatingFeedback { get; set; }

        [Required(ErrorMessage = "Advisor Rating Rate is required")]
        public int AdvisorRatingRate { get; set; }

        [Required(ErrorMessage = "Advisor Rating Date is required")]
        public DateTime AdvisorRatingDate { get; set; }

        public AdvisorDto Advisor { get; set; }

        [Required(ErrorMessage = "Advisor is required")]
        public Guid AdvisorId { get; set; }

        public ConversationDto Conversation { get; set; }

        [Required(ErrorMessage = "Conversation is required")]
        public Guid ConversationId { get; set; }

        public CustomerDto Customer { get; set; }

        [Required(ErrorMessage = "Customer is required")]
        public Guid CustomerId { get; set; }

        public RatingReasonDto RatingReason { get; set; }

        [Required(ErrorMessage = "Rating Reason is required")]
        public Guid RatingReasonId { get; set; }
    }
}
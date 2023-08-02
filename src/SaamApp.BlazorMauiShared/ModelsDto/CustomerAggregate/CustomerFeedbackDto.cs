using System;
using System.ComponentModel.DataAnnotations;
using Ardalis.GuardClauses;

namespace SaamApp.Domain.ModelsDto
{
    public class CustomerFeedbackDto
    {
        public CustomerFeedbackDto() { } // AutoMapper required

        public CustomerFeedbackDto(Guid feedbackId, Guid customerId, DateTime feedbackDate, string feedbackContent)
        {
            FeedbackId = Guard.Against.NullOrEmpty(feedbackId, nameof(feedbackId));
            CustomerId = Guard.Against.NullOrEmpty(customerId, nameof(customerId));
            FeedbackDate = Guard.Against.OutOfSQLDateRange(feedbackDate, nameof(feedbackDate));
            FeedbackContent = Guard.Against.NullOrWhiteSpace(feedbackContent, nameof(feedbackContent));
        }

        public Guid FeedbackId { get; set; }

        [Required(ErrorMessage = "Feedback Date is required")]
        public DateTime FeedbackDate { get; set; }

        [Required(ErrorMessage = "Feedback Content is required")]
        [MaxLength(100)]
        public string FeedbackContent { get; set; }

        public CustomerDto Customer { get; set; }

        [Required(ErrorMessage = "Customer is required")]
        public Guid CustomerId { get; set; }
    }
}
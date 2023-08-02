using System;
using System.ComponentModel.DataAnnotations;
using Ardalis.GuardClauses;

namespace SaamApp.Domain.ModelsDto
{
    public class CustomerReviewDto
    {
        public CustomerReviewDto() { } // AutoMapper required

        public CustomerReviewDto(Guid customerReviewId, Guid advisorId, Guid customerId, int rating, string? reviewText,
            DateTime createdAt, Guid createdBy, DateTime? updatedAt, Guid? updatedBy, bool? isDeleted, Guid tenantId)
        {
            CustomerReviewId = Guard.Against.NullOrEmpty(customerReviewId, nameof(customerReviewId));
            AdvisorId = Guard.Against.NullOrEmpty(advisorId, nameof(advisorId));
            CustomerId = Guard.Against.NullOrEmpty(customerId, nameof(customerId));
            Rating = Guard.Against.NegativeOrZero(rating, nameof(rating));
            ReviewText = reviewText;
            CreatedAt = Guard.Against.OutOfSQLDateRange(createdAt, nameof(createdAt));
            CreatedBy = Guard.Against.NullOrEmpty(createdBy, nameof(createdBy));
            UpdatedAt = updatedAt;
            UpdatedBy = updatedBy;
            IsDeleted = isDeleted;
            TenantId = Guard.Against.NullOrEmpty(tenantId, nameof(tenantId));
        }

        public Guid CustomerReviewId { get; set; }

        [Required(ErrorMessage = "Rating is required")]
        public int Rating { get; set; }

        [MaxLength(100)] public string? ReviewText { get; set; }

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

        public CustomerDto Customer { get; set; }

        [Required(ErrorMessage = "Customer is required")]
        public Guid CustomerId { get; set; }
    }
}
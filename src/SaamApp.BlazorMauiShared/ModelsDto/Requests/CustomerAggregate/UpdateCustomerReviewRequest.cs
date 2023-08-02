using System;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.CustomerReview
{
    public class UpdateCustomerReviewRequest : BaseRequest
    {
        public Guid CustomerReviewId { get; set; }
        public Guid AdvisorId { get; set; }
        public Guid CustomerId { get; set; }
        public int Rating { get; set; }
        public string? ReviewText { get; set; }
        public DateTime CreatedAt { get; set; }
        public Guid CreatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public Guid? UpdatedBy { get; set; }
        public bool? IsDeleted { get; set; }
        public Guid TenantId { get; set; }

        public static UpdateCustomerReviewRequest FromDto(CustomerReviewDto customerReviewDto)
        {
            return new UpdateCustomerReviewRequest
            {
                CustomerReviewId = customerReviewDto.CustomerReviewId,
                AdvisorId = customerReviewDto.AdvisorId,
                CustomerId = customerReviewDto.CustomerId,
                Rating = customerReviewDto.Rating,
                ReviewText = customerReviewDto.ReviewText,
                CreatedAt = customerReviewDto.CreatedAt,
                CreatedBy = customerReviewDto.CreatedBy,
                UpdatedAt = customerReviewDto.UpdatedAt,
                UpdatedBy = customerReviewDto.UpdatedBy,
                IsDeleted = customerReviewDto.IsDeleted,
                TenantId = customerReviewDto.TenantId
            };
        }
    }
}
using System;

namespace SaamApp.BlazorMauiShared.Models.CustomerReview
{
    public class CreateCustomerReviewRequest : BaseRequest
    {
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
    }
}
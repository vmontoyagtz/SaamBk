using System;

namespace SaamApp.BlazorMauiShared.Models.CustomerReview
{
    public class DeleteCustomerReviewRequest : BaseRequest
    {
        public Guid CustomerReviewId { get; set; }
    }
}
using System;

namespace SaamApp.BlazorMauiShared.Models.CustomerReview
{
    public class GetByIdCustomerReviewRequest : BaseRequest
    {
        public Guid CustomerReviewId { get; set; }
    }
}
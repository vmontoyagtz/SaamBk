using System;

namespace SaamApp.BlazorMauiShared.Models.CustomerReview
{
    public class DeleteCustomerReviewResponse : BaseResponse
    {
        public DeleteCustomerReviewResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public DeleteCustomerReviewResponse()
        {
        }
    }
}
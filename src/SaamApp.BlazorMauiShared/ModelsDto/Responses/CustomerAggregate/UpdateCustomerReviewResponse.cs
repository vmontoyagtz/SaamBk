using System;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.CustomerReview
{
    public class UpdateCustomerReviewResponse : BaseResponse
    {
        public UpdateCustomerReviewResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public UpdateCustomerReviewResponse()
        {
        }

        public CustomerReviewDto CustomerReview { get; set; } = new();
    }
}
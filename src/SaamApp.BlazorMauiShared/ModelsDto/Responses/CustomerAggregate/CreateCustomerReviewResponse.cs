using System;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.CustomerReview
{
    public class CreateCustomerReviewResponse : BaseResponse
    {
        public CreateCustomerReviewResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public CreateCustomerReviewResponse()
        {
        }

        public CustomerReviewDto CustomerReview { get; set; } = new();
    }
}
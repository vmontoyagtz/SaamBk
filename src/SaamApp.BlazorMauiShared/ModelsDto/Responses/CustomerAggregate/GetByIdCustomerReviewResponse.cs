using System;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.CustomerReview
{
    public class GetByIdCustomerReviewResponse : BaseResponse
    {
        public GetByIdCustomerReviewResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public GetByIdCustomerReviewResponse()
        {
        }

        public CustomerReviewDto CustomerReview { get; set; } = new();
    }
}
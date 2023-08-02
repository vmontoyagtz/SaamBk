using System;
using System.Collections.Generic;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.CustomerReview
{
    public class ListCustomerReviewResponse : BaseResponse
    {
        public ListCustomerReviewResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public ListCustomerReviewResponse()
        {
        }

        public List<CustomerReviewDto> CustomerReviews { get; set; } = new();

        public int Count { get; set; }
    }
}
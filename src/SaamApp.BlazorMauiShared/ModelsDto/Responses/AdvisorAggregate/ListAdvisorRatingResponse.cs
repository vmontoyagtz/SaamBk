using System;
using System.Collections.Generic;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.AdvisorRating
{
    public class ListAdvisorRatingResponse : BaseResponse
    {
        public ListAdvisorRatingResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public ListAdvisorRatingResponse()
        {
        }

        public List<AdvisorRatingDto> AdvisorRatings { get; set; } = new();

        public int Count { get; set; }
    }
}
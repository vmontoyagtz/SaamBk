using System;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.AdvisorRating
{
    public class GetByIdAdvisorRatingResponse : BaseResponse
    {
        public GetByIdAdvisorRatingResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public GetByIdAdvisorRatingResponse()
        {
        }

        public AdvisorRatingDto AdvisorRating { get; set; } = new();
    }
}
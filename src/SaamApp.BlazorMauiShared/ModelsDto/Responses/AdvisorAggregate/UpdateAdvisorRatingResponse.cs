using System;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.AdvisorRating
{
    public class UpdateAdvisorRatingResponse : BaseResponse
    {
        public UpdateAdvisorRatingResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public UpdateAdvisorRatingResponse()
        {
        }

        public AdvisorRatingDto AdvisorRating { get; set; } = new();
    }
}
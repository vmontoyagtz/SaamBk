using System;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.AdvisorRating
{
    public class CreateAdvisorRatingResponse : BaseResponse
    {
        public CreateAdvisorRatingResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public CreateAdvisorRatingResponse()
        {
        }

        public AdvisorRatingDto AdvisorRating { get; set; } = new();
    }
}
using System;

namespace SaamApp.BlazorMauiShared.Models.AdvisorRating
{
    public class DeleteAdvisorRatingResponse : BaseResponse
    {
        public DeleteAdvisorRatingResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public DeleteAdvisorRatingResponse()
        {
        }
    }
}
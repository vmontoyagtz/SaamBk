using System;

namespace SaamApp.BlazorMauiShared.Models.RatingReason
{
    public class DeleteRatingReasonResponse : BaseResponse
    {
        public DeleteRatingReasonResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public DeleteRatingReasonResponse()
        {
        }
    }
}
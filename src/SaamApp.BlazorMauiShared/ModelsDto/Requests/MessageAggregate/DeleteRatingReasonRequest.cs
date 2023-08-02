using System;

namespace SaamApp.BlazorMauiShared.Models.RatingReason
{
    public class DeleteRatingReasonRequest : BaseRequest
    {
        public Guid RatingReasonId { get; set; }
    }
}
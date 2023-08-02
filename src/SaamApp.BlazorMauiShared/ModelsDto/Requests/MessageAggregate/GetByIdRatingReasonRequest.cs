using System;

namespace SaamApp.BlazorMauiShared.Models.RatingReason
{
    public class GetByIdRatingReasonRequest : BaseRequest
    {
        public Guid RatingReasonId { get; set; }
    }
}
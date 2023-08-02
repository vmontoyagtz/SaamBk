using System;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.RatingReason
{
    public class UpdateRatingReasonResponse : BaseResponse
    {
        public UpdateRatingReasonResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public UpdateRatingReasonResponse()
        {
        }

        public RatingReasonDto RatingReason { get; set; } = new();
    }
}
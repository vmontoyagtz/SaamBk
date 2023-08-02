using System;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.RatingReason
{
    public class CreateRatingReasonResponse : BaseResponse
    {
        public CreateRatingReasonResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public CreateRatingReasonResponse()
        {
        }

        public RatingReasonDto RatingReason { get; set; } = new();
    }
}
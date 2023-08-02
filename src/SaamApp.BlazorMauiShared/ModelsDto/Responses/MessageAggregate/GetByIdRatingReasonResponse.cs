using System;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.RatingReason
{
    public class GetByIdRatingReasonResponse : BaseResponse
    {
        public GetByIdRatingReasonResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public GetByIdRatingReasonResponse()
        {
        }

        public RatingReasonDto RatingReason { get; set; } = new();
    }
}
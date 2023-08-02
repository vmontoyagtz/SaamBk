using System;
using System.Collections.Generic;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.RatingReason
{
    public class ListRatingReasonResponse : BaseResponse
    {
        public ListRatingReasonResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public ListRatingReasonResponse()
        {
        }

        public List<RatingReasonDto> RatingReasons { get; set; } = new();

        public int Count { get; set; }
    }
}
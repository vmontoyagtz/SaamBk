using System;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.RatingReason
{
    public class UpdateRatingReasonRequest : BaseRequest
    {
        public Guid RatingReasonId { get; set; }
        public string RatingReasonDescription { get; set; }

        public static UpdateRatingReasonRequest FromDto(RatingReasonDto ratingReasonDto)
        {
            return new UpdateRatingReasonRequest
            {
                RatingReasonId = ratingReasonDto.RatingReasonId,
                RatingReasonDescription = ratingReasonDto.RatingReasonDescription
            };
        }
    }
}
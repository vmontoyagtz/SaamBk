using System;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.AdvisorRating
{
    public class UpdateAdvisorRatingRequest : BaseRequest
    {
        public int RowId { get; set; }
        public Guid AdvisorId { get; set; }
        public Guid ConversationId { get; set; }
        public Guid CustomerId { get; set; }
        public Guid RatingReasonId { get; set; }
        public string? AdvisorRatingFeedback { get; set; }
        public int AdvisorRatingRate { get; set; }
        public DateTime AdvisorRatingDate { get; set; }

        public static UpdateAdvisorRatingRequest FromDto(AdvisorRatingDto advisorRatingDto)
        {
            return new UpdateAdvisorRatingRequest
            {
                RowId = advisorRatingDto.RowId,
                AdvisorId = advisorRatingDto.AdvisorId,
                ConversationId = advisorRatingDto.ConversationId,
                CustomerId = advisorRatingDto.CustomerId,
                RatingReasonId = advisorRatingDto.RatingReasonId,
                AdvisorRatingFeedback = advisorRatingDto.AdvisorRatingFeedback,
                AdvisorRatingRate = advisorRatingDto.AdvisorRatingRate,
                AdvisorRatingDate = advisorRatingDto.AdvisorRatingDate
            };
        }
    }
}
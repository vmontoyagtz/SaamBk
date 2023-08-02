using System;

namespace SaamApp.BlazorMauiShared.Models.AdvisorRating
{
    public class GetByRelsIdsAdvisorRatingRequest : BaseRequest
    {
        public int AdvisorRatingRate { get; set; }
        public DateTime AdvisorRatingDate { get; set; }
        public Guid AdvisorId { get; set; }
        public Guid ConversationId { get; set; }
        public Guid CustomerId { get; set; }
        public Guid RatingReasonId { get; set; }
    }
}
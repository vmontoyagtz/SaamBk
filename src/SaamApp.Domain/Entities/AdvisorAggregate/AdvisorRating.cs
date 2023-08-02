using System;
using System.ComponentModel.DataAnnotations;
using Ardalis.GuardClauses;
using SaamApp.Domain.Events;
using SaamAppLib.SharedKernel;
using SaamAppLib.SharedKernel.Interfaces;

namespace SaamApp.Domain.Entities
{
    public class AdvisorRating : BaseEntityEv<int>, IAggregateRoot
    {
        private AdvisorRating() { } // EF required

        //[SetsRequiredMembers]
        public AdvisorRating(Guid advisorId, Guid conversationId, Guid customerId, Guid ratingReasonId,
            string? advisorRatingFeedback, int advisorRatingRate, DateTime advisorRatingDate)
        {
            AdvisorId = Guard.Against.NullOrEmpty(advisorId, nameof(advisorId));
            ConversationId = Guard.Against.NullOrEmpty(conversationId, nameof(conversationId));
            CustomerId = Guard.Against.NullOrEmpty(customerId, nameof(customerId));
            RatingReasonId = Guard.Against.NullOrEmpty(ratingReasonId, nameof(ratingReasonId));
            AdvisorRatingFeedback = advisorRatingFeedback;
            AdvisorRatingRate = Guard.Against.NegativeOrZero(advisorRatingRate, nameof(advisorRatingRate));
            AdvisorRatingDate = Guard.Against.OutOfSQLDateRange(advisorRatingDate, nameof(advisorRatingDate));
        }

        [Key] public int RowId { get; private set; }

        public string? AdvisorRatingFeedback { get; private set; }

        public int AdvisorRatingRate { get; private set; }

        public DateTime AdvisorRatingDate { get; private set; }

        public virtual Advisor Advisor { get; private set; }

        public Guid AdvisorId { get; private set; }

        public virtual Conversation Conversation { get; private set; }

        public Guid ConversationId { get; private set; }

        public virtual Customer Customer { get; private set; }

        public Guid CustomerId { get; private set; }

        public virtual RatingReason RatingReason { get; private set; }

        public Guid RatingReasonId { get; private set; }

        public void SetAdvisorRatingFeedback(string advisorRatingFeedback)
        {
            AdvisorRatingFeedback = advisorRatingFeedback;
        }

        public void UpdateAdvisorForAdvisorRating(Guid newAdvisorId)
        {
            Guard.Against.NullOrEmpty(newAdvisorId, nameof(newAdvisorId));
            if (newAdvisorId == AdvisorId)
            {
                return;
            }

            AdvisorId = newAdvisorId;
            var advisorRatingUpdatedEvent = new AdvisorRatingUpdatedEvent(this, "Mongo-History");
            Events.Add(advisorRatingUpdatedEvent);
        }


        public void UpdateConversationForAdvisorRating(Guid newConversationId)
        {
            Guard.Against.NullOrEmpty(newConversationId, nameof(newConversationId));
            if (newConversationId == ConversationId)
            {
                return;
            }

            ConversationId = newConversationId;
            var advisorRatingUpdatedEvent = new AdvisorRatingUpdatedEvent(this, "Mongo-History");
            Events.Add(advisorRatingUpdatedEvent);
        }


        public void UpdateCustomerForAdvisorRating(Guid newCustomerId)
        {
            Guard.Against.NullOrEmpty(newCustomerId, nameof(newCustomerId));
            if (newCustomerId == CustomerId)
            {
                return;
            }

            CustomerId = newCustomerId;
            var advisorRatingUpdatedEvent = new AdvisorRatingUpdatedEvent(this, "Mongo-History");
            Events.Add(advisorRatingUpdatedEvent);
        }


        public void UpdateRatingReasonForAdvisorRating(Guid newRatingReasonId)
        {
            Guard.Against.NullOrEmpty(newRatingReasonId, nameof(newRatingReasonId));
            if (newRatingReasonId == RatingReasonId)
            {
                return;
            }

            RatingReasonId = newRatingReasonId;
            var advisorRatingUpdatedEvent = new AdvisorRatingUpdatedEvent(this, "Mongo-History");
            Events.Add(advisorRatingUpdatedEvent);
        }
    }
}
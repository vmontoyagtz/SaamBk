using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Ardalis.GuardClauses;
using SaamApp.Domain.Events;
using SaamAppLib.SharedKernel;
using SaamAppLib.SharedKernel.Interfaces;

namespace SaamApp.Domain.Entities
{
    public class RatingReason : BaseEntityEv<Guid>, IAggregateRoot
    {
        private readonly List<AdvisorRating> _advisorRatings = new();

        private RatingReason() { } // EF required

        //[SetsRequiredMembers]
        public RatingReason(Guid ratingReasonId, string ratingReasonDescription)
        {
            RatingReasonId = Guard.Against.NullOrEmpty(ratingReasonId, nameof(ratingReasonId));
            RatingReasonDescription =
                Guard.Against.NullOrWhiteSpace(ratingReasonDescription, nameof(ratingReasonDescription));
        }

        [Key] public Guid RatingReasonId { get; private set; }

        public string RatingReasonDescription { get; private set; }
        public IEnumerable<AdvisorRating> AdvisorRatings => _advisorRatings.AsReadOnly();

        public void SetRatingReasonDescription(string ratingReasonDescription)
        {
            RatingReasonDescription =
                Guard.Against.NullOrEmpty(ratingReasonDescription, nameof(ratingReasonDescription));
        }


        public void AddNewAdvisorRating(string? advisorRatingFeedback, int advisorRatingRate,
            DateTime advisorRatingDate, Guid advisorId, Guid conversationId, Guid customerId, Guid ratingReasonId)
        {
            Guard.Against.NegativeOrZero(advisorRatingRate, nameof(advisorRatingRate));
            Guard.Against.OutOfSQLDateRange(advisorRatingDate, nameof(advisorRatingDate));
            Guard.Against.NullOrEmpty(advisorId, nameof(advisorId));
            Guard.Against.NullOrEmpty(conversationId, nameof(conversationId));
            Guard.Against.NullOrEmpty(customerId, nameof(customerId));
            Guard.Against.NullOrEmpty(ratingReasonId, nameof(ratingReasonId));

            var newAdvisorRating = new AdvisorRating(advisorId, conversationId, customerId, ratingReasonId,
                advisorRatingFeedback, advisorRatingRate, advisorRatingDate);
            Guard.Against.DuplicateAdvisorRating(_advisorRatings, newAdvisorRating, nameof(newAdvisorRating));
            _advisorRatings.Add(newAdvisorRating);
            var advisorRatingAddedEvent = new AdvisorRatingCreatedEvent(newAdvisorRating, "Mongo-History");
            Events.Add(advisorRatingAddedEvent);
        }

        public void DeleteAdvisorRating(string advisorRatingFeedback, int advisorRatingRate, DateTime advisorRatingDate,
            Guid advisorId, Guid conversationId, Guid customerId, Guid ratingReasonId)
        {
            Guard.Against.NullOrWhiteSpace(advisorRatingFeedback, nameof(advisorRatingFeedback));
            Guard.Against.NegativeOrZero(advisorRatingRate, nameof(advisorRatingRate));
            Guard.Against.OutOfSQLDateRange(advisorRatingDate, nameof(advisorRatingDate));
            Guard.Against.NullOrEmpty(advisorId, nameof(advisorId));
            Guard.Against.NullOrEmpty(conversationId, nameof(conversationId));
            Guard.Against.NullOrEmpty(customerId, nameof(customerId));
            Guard.Against.NullOrEmpty(ratingReasonId, nameof(ratingReasonId));

            var advisorRatingToDelete = _advisorRatings
                .Where(ar1 => ar1.AdvisorRatingFeedback == advisorRatingFeedback)
                .Where(ar2 => ar2.AdvisorRatingRate == advisorRatingRate)
                .Where(ar3 => ar3.AdvisorRatingDate == advisorRatingDate)
                .Where(ar4 => ar4.AdvisorId == advisorId)
                .Where(ar5 => ar5.ConversationId == conversationId)
                .Where(ar6 => ar6.CustomerId == customerId)
                .Where(ar7 => ar7.RatingReasonId == ratingReasonId)
                .FirstOrDefault();

            if (advisorRatingToDelete != null)
            {
                _advisorRatings.Remove(advisorRatingToDelete);
                var advisorRatingDeletedEvent = new AdvisorRatingDeletedEvent(advisorRatingToDelete, "Mongo-History");
                Events.Add(advisorRatingDeletedEvent);
            }
        }
    }
}
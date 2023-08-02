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
    public class Conversation : BaseEntityEv<Guid>, IAggregateRoot
    {
        private readonly List<AdvisorRating> _advisorRatings = new();

        private readonly List<ConversationPayment> _conversationPayments = new();

        private readonly List<Message> _messages = new();

        private Conversation() { } // EF required

        //[SetsRequiredMembers]
        public Conversation(Guid conversationId, Guid interactionTypeId, Guid regionAreaAdvisorCategoryId,
            Guid unansweredConversationId, string reconnectConversationId, int conversationSumTimeInSecs,
            decimal conversationSumSpent, bool? lostSignalCustomer, bool? lostSignalAdvisor, bool? canceledByCustomer,
            bool? canceledByAdvisor, bool? endedByNoBalance, bool? stillActive, DateTime createdAt, Guid createdBy,
            DateTime? updatedAt, Guid? updatedBy, bool? isDeleted, Guid tenantId)
        {
            ConversationId = Guard.Against.NullOrEmpty(conversationId, nameof(conversationId));
            InteractionTypeId = Guard.Against.NullOrEmpty(interactionTypeId, nameof(interactionTypeId));
            RegionAreaAdvisorCategoryId =
                Guard.Against.NullOrEmpty(regionAreaAdvisorCategoryId, nameof(regionAreaAdvisorCategoryId));
            UnansweredConversationId =
                Guard.Against.NullOrEmpty(unansweredConversationId, nameof(unansweredConversationId));
            ReconnectConversationId =
                Guard.Against.NullOrWhiteSpace(reconnectConversationId, nameof(reconnectConversationId));
            ConversationSumTimeInSecs =
                Guard.Against.NegativeOrZero(conversationSumTimeInSecs, nameof(conversationSumTimeInSecs));
            ConversationSumSpent = Guard.Against.Negative(conversationSumSpent, nameof(conversationSumSpent));
            LostSignalCustomer = lostSignalCustomer;
            LostSignalAdvisor = lostSignalAdvisor;
            CanceledByCustomer = canceledByCustomer;
            CanceledByAdvisor = canceledByAdvisor;
            EndedByNoBalance = endedByNoBalance;
            StillActive = stillActive;
            CreatedAt = Guard.Against.OutOfSQLDateRange(createdAt, nameof(createdAt));
            CreatedBy = Guard.Against.NullOrEmpty(createdBy, nameof(createdBy));
            UpdatedAt = updatedAt;
            UpdatedBy = updatedBy;
            IsDeleted = isDeleted;
            TenantId = Guard.Against.NullOrEmpty(tenantId, nameof(tenantId));
        }

        [Key] public Guid ConversationId { get; private set; }

        public string ReconnectConversationId { get; private set; }

        public int ConversationSumTimeInSecs { get; private set; }

        public decimal ConversationSumSpent { get; private set; }

        public bool? LostSignalCustomer { get; private set; }

        public bool? LostSignalAdvisor { get; private set; }

        public bool? CanceledByCustomer { get; private set; }

        public bool? CanceledByAdvisor { get; private set; }

        public bool? EndedByNoBalance { get; private set; }

        public bool? StillActive { get; private set; }

        public DateTime CreatedAt { get; private set; }

        public Guid CreatedBy { get; private set; }

        public DateTime? UpdatedAt { get; private set; }

        public Guid? UpdatedBy { get; private set; }

        public bool? IsDeleted { get; private set; }

        public Guid TenantId { get; private set; }

        public virtual InteractionType InteractionType { get; private set; }

        public Guid InteractionTypeId { get; private set; }

        public virtual RegionAreaAdvisorCategory RegionAreaAdvisorCategory { get; private set; }

        public Guid RegionAreaAdvisorCategoryId { get; private set; }

        public virtual UnansweredConversation UnansweredConversation { get; private set; }

        public Guid UnansweredConversationId { get; private set; }
        public IEnumerable<AdvisorRating> AdvisorRatings => _advisorRatings.AsReadOnly();
        public IEnumerable<ConversationPayment> ConversationPayments => _conversationPayments.AsReadOnly();
        public IEnumerable<Message> Messages => _messages.AsReadOnly();

        public void SetReconnectConversationId(string reconnectConversationId)
        {
            ReconnectConversationId =
                Guard.Against.NullOrEmpty(reconnectConversationId, nameof(reconnectConversationId));
        }

        public void UpdateRegionAreaAdvisorCategoryForConversation(Guid newRegionAreaAdvisorCategoryId)
        {
            Guard.Against.NullOrEmpty(newRegionAreaAdvisorCategoryId, nameof(newRegionAreaAdvisorCategoryId));
            if (newRegionAreaAdvisorCategoryId == RegionAreaAdvisorCategoryId)
            {
                return;
            }

            RegionAreaAdvisorCategoryId = newRegionAreaAdvisorCategoryId;
            var conversationUpdatedEvent = new ConversationUpdatedEvent(this, "Mongo-History");
            Events.Add(conversationUpdatedEvent);
        }


        public void UpdateInteractionTypeForConversation(Guid newInteractionTypeId)
        {
            Guard.Against.NullOrEmpty(newInteractionTypeId, nameof(newInteractionTypeId));
            if (newInteractionTypeId == InteractionTypeId)
            {
                return;
            }

            InteractionTypeId = newInteractionTypeId;
            var conversationUpdatedEvent = new ConversationUpdatedEvent(this, "Mongo-History");
            Events.Add(conversationUpdatedEvent);
        }


        public void UpdateUnansweredConversationForConversation(Guid newUnansweredConversationId)
        {
            Guard.Against.NullOrEmpty(newUnansweredConversationId, nameof(newUnansweredConversationId));
            if (newUnansweredConversationId == UnansweredConversationId)
            {
                return;
            }

            UnansweredConversationId = newUnansweredConversationId;
            var conversationUpdatedEvent = new ConversationUpdatedEvent(this, "Mongo-History");
            Events.Add(conversationUpdatedEvent);
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

        public void AddNewConversationPayment(Guid advisorPaymentId, bool? conversationPaymentStage,
            Guid conversationId)
        {
            Guard.Against.NullOrEmpty(advisorPaymentId, nameof(advisorPaymentId));
            Guard.Against.NullOrEmpty(conversationId, nameof(conversationId));

            var newConversationPayment =
                new ConversationPayment(conversationId, advisorPaymentId, conversationPaymentStage);
            Guard.Against.DuplicateConversationPayment(_conversationPayments, newConversationPayment,
                nameof(newConversationPayment));
            _conversationPayments.Add(newConversationPayment);
            var conversationPaymentAddedEvent =
                new ConversationPaymentCreatedEvent(newConversationPayment, "Mongo-History");
            Events.Add(conversationPaymentAddedEvent);
        }

        public void DeleteConversationPayment(Guid advisorPaymentId, bool conversationPaymentStage, Guid conversationId)
        {
            Guard.Against.NullOrEmpty(advisorPaymentId, nameof(advisorPaymentId));
            Guard.Against.Null(conversationPaymentStage, nameof(conversationPaymentStage));
            Guard.Against.NullOrEmpty(conversationId, nameof(conversationId));

            var conversationPaymentToDelete = _conversationPayments
                .Where(cp1 => cp1.AdvisorPaymentId == advisorPaymentId)
                .Where(cp2 => cp2.ConversationPaymentStage == conversationPaymentStage)
                .Where(cp3 => cp3.ConversationId == conversationId)
                .FirstOrDefault();

            if (conversationPaymentToDelete != null)
            {
                _conversationPayments.Remove(conversationPaymentToDelete);
                var conversationPaymentDeletedEvent =
                    new ConversationPaymentDeletedEvent(conversationPaymentToDelete, "Mongo-History");
                Events.Add(conversationPaymentDeletedEvent);
            }
        }

        public void AddNewMessage(Message message)
        {
            Guard.Against.Null(message, nameof(message));
            Guard.Against.NullOrEmpty(message.MessageId, nameof(message.MessageId));
            Guard.Against.DuplicateMessage(_messages, message, nameof(message));
            _messages.Add(message);
            var messageAddedEvent = new MessageCreatedEvent(message, "Mongo-History");
            Events.Add(messageAddedEvent);
        }

        public void DeleteMessage(Message message)
        {
            Guard.Against.Null(message, nameof(message));
            var messageToDelete = _messages
                .Where(m => m.MessageId == message.MessageId)
                .FirstOrDefault();
            if (messageToDelete != null)
            {
                _messages.Remove(messageToDelete);
                var messageDeletedEvent = new MessageDeletedEvent(messageToDelete, "Mongo-History");
                Events.Add(messageDeletedEvent);
            }
        }
    }
}
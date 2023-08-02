using System;
using System.ComponentModel.DataAnnotations;
using Ardalis.GuardClauses;
using SaamApp.Domain.Events;
using SaamAppLib.SharedKernel;
using SaamAppLib.SharedKernel.Interfaces;

namespace SaamApp.Domain.Entities
{
    public class ConversationPayment : BaseEntityEv<int>, IAggregateRoot
    {
        private ConversationPayment() { } // EF required

        //[SetsRequiredMembers]
        public ConversationPayment(Guid conversationId, Guid advisorPaymentId, bool? conversationPaymentStage)
        {
            ConversationId = Guard.Against.NullOrEmpty(conversationId, nameof(conversationId));
            AdvisorPaymentId = Guard.Against.NullOrEmpty(advisorPaymentId, nameof(advisorPaymentId));
            ConversationPaymentStage = conversationPaymentStage;
        }

        [Key] public int RowId { get; private set; }

        public Guid AdvisorPaymentId { get; private set; }

        public bool? ConversationPaymentStage { get; private set; }

        public virtual Conversation Conversation { get; private set; }

        public Guid ConversationId { get; private set; }


        public void UpdateConversationForConversationPayment(Guid newConversationId)
        {
            Guard.Against.NullOrEmpty(newConversationId, nameof(newConversationId));
            if (newConversationId == ConversationId)
            {
                return;
            }

            ConversationId = newConversationId;
            var conversationPaymentUpdatedEvent = new ConversationPaymentUpdatedEvent(this, "Mongo-History");
            Events.Add(conversationPaymentUpdatedEvent);
        }
    }
}
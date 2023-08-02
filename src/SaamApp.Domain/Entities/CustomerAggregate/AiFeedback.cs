using System;
using System.ComponentModel.DataAnnotations;
using Ardalis.GuardClauses;
using SaamApp.Domain.Events;
using SaamAppLib.SharedKernel;
using SaamAppLib.SharedKernel.Interfaces;

namespace SaamApp.Domain.Entities
{
    public class AiFeedback : BaseEntityEv<Guid>, IAggregateRoot
    {
        private AiFeedback() { } // EF required

        //[SetsRequiredMembers]
        public AiFeedback(Guid aiFeedbackId, Guid customerId, Guid modelId, string? question, string? response,
            bool? userFeedback, Guid aisessionId, DateTime interactionTime)
        {
            AiFeedbackId = Guard.Against.NullOrEmpty(aiFeedbackId, nameof(aiFeedbackId));
            CustomerId = Guard.Against.NullOrEmpty(customerId, nameof(customerId));
            ModelId = Guard.Against.NullOrEmpty(modelId, nameof(modelId));
            Question = question;
            Response = response;
            UserFeedback = userFeedback;
            AISessionId = Guard.Against.NullOrEmpty(aisessionId, nameof(aisessionId));
            InteractionTime = Guard.Against.OutOfSQLDateRange(interactionTime, nameof(interactionTime));
        }

        [Key] public Guid AiFeedbackId { get; private set; }

        public Guid ModelId { get; private set; }

        public string? Question { get; private set; }

        public string? Response { get; private set; }

        public bool? UserFeedback { get; private set; }

        public Guid AISessionId { get; private set; }

        public DateTime InteractionTime { get; private set; }
        public virtual Customer Customer { get; private set; }

        public Guid CustomerId { get; private set; }


        public void UpdateCustomerForAiFeedback(Guid newCustomerId)
        {
            Guard.Against.NullOrEmpty(newCustomerId, nameof(newCustomerId));
            if (newCustomerId == CustomerId)
            {
                return;
            }

            CustomerId = newCustomerId;
            var aiFeedbackUpdatedEvent = new AiFeedbackUpdatedEvent(this, "Mongo-History");
            Events.Add(aiFeedbackUpdatedEvent);
        }

        public void SetQuestion(string question)
        {
            Question = question;
        }

        public void SetResponse(string response)
        {
            Response = response;
        }
    }
}
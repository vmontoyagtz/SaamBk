using System;
using System.ComponentModel.DataAnnotations;
using Ardalis.GuardClauses;
using SaamApp.Domain.Events;
using SaamAppLib.SharedKernel;
using SaamAppLib.SharedKernel.Interfaces;

namespace SaamApp.Domain.Entities
{
    public class AiSession : BaseEntityEv<Guid>, IAggregateRoot
    {
        private AiSession() { } // EF required

        //[SetsRequiredMembers]
        public AiSession(Guid aiSessionId, Guid customerId, DateTime startTime, DateTime? endTime,
            int numberOfInteractions)
        {
            AiSessionId = Guard.Against.NullOrEmpty(aiSessionId, nameof(aiSessionId));
            CustomerId = Guard.Against.NullOrEmpty(customerId, nameof(customerId));
            StartTime = Guard.Against.OutOfSQLDateRange(startTime, nameof(startTime));
            EndTime = endTime;
            NumberOfInteractions = Guard.Against.NegativeOrZero(numberOfInteractions, nameof(numberOfInteractions));
        }

        [Key] public Guid AiSessionId { get; private set; }

        public DateTime StartTime { get; private set; }

        public DateTime? EndTime { get; private set; }

        public int NumberOfInteractions { get; private set; }

        public virtual Customer Customer { get; private set; }

        public Guid CustomerId { get; private set; }


        public void UpdateCustomerForAiSession(Guid newCustomerId)
        {
            Guard.Against.NullOrEmpty(newCustomerId, nameof(newCustomerId));
            if (newCustomerId == CustomerId)
            {
                return;
            }

            CustomerId = newCustomerId;
            var aiSessionUpdatedEvent = new AiSessionUpdatedEvent(this, "Mongo-History");
            Events.Add(aiSessionUpdatedEvent);
        }
    }
}
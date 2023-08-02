using System;
using System.ComponentModel.DataAnnotations;
using Ardalis.GuardClauses;
using SaamApp.Domain.Events;
using SaamAppLib.SharedKernel;
using SaamAppLib.SharedKernel.Interfaces;

namespace SaamApp.Domain.Entities
{
    public class CustomerAiHistory : BaseEntityEv<Guid>, IAggregateRoot
    {
        private CustomerAiHistory() { } // EF required

        //[SetsRequiredMembers]
        public CustomerAiHistory(Guid customerAiHistoryId, Guid customerId, Guid modelId, string? question,
            string? response, DateTime interactionTime, Guid tenantId)
        {
            CustomerAiHistoryId = Guard.Against.NullOrEmpty(customerAiHistoryId, nameof(customerAiHistoryId));
            CustomerId = Guard.Against.NullOrEmpty(customerId, nameof(customerId));
            ModelId = Guard.Against.NullOrEmpty(modelId, nameof(modelId));
            Question = question;
            Response = response;
            InteractionTime = Guard.Against.OutOfSQLDateRange(interactionTime, nameof(interactionTime));
            TenantId = Guard.Against.NullOrEmpty(tenantId, nameof(tenantId));
        }

        [Key] public Guid CustomerAiHistoryId { get; private set; }

        public Guid ModelId { get; private set; }

        public string? Question { get; private set; }

        public string? Response { get; private set; }

        public DateTime InteractionTime { get; private set; }

        public Guid TenantId { get; private set; }
        public virtual Customer Customer { get; private set; }

        public Guid CustomerId { get; private set; }


        public void UpdateCustomerForCustomerAiHistory(Guid newCustomerId)
        {
            Guard.Against.NullOrEmpty(newCustomerId, nameof(newCustomerId));
            if (newCustomerId == CustomerId)
            {
                return;
            }

            CustomerId = newCustomerId;
            var customerAiHistoryUpdatedEvent = new CustomerAiHistoryUpdatedEvent(this, "Mongo-History");
            Events.Add(customerAiHistoryUpdatedEvent);
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
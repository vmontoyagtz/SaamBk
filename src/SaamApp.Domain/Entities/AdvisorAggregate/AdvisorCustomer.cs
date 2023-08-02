using System;
using System.ComponentModel.DataAnnotations;
using Ardalis.GuardClauses;
using SaamApp.Domain.Events;
using SaamAppLib.SharedKernel;
using SaamAppLib.SharedKernel.Interfaces;

namespace SaamApp.Domain.Entities
{
    public class AdvisorCustomer : BaseEntityEv<int>, IAggregateRoot
    {
        private AdvisorCustomer() { } // EF required

        //[SetsRequiredMembers]
        public AdvisorCustomer(Guid advisorId, Guid customerId)
        {
            AdvisorId = Guard.Against.NullOrEmpty(advisorId, nameof(advisorId));
            CustomerId = Guard.Against.NullOrEmpty(customerId, nameof(customerId));
        }

        [Key] public int RowId { get; private set; }

        public virtual Advisor Advisor { get; private set; }

        public Guid AdvisorId { get; private set; }

        public virtual Customer Customer { get; private set; }

        public Guid CustomerId { get; private set; }


        public void UpdateAdvisorForAdvisorCustomer(Guid newAdvisorId)
        {
            Guard.Against.NullOrEmpty(newAdvisorId, nameof(newAdvisorId));
            if (newAdvisorId == AdvisorId)
            {
                return;
            }

            AdvisorId = newAdvisorId;
            var advisorCustomerUpdatedEvent = new AdvisorCustomerUpdatedEvent(this, "Mongo-History");
            Events.Add(advisorCustomerUpdatedEvent);
        }


        public void UpdateCustomerForAdvisorCustomer(Guid newCustomerId)
        {
            Guard.Against.NullOrEmpty(newCustomerId, nameof(newCustomerId));
            if (newCustomerId == CustomerId)
            {
                return;
            }

            CustomerId = newCustomerId;
            var advisorCustomerUpdatedEvent = new AdvisorCustomerUpdatedEvent(this, "Mongo-History");
            Events.Add(advisorCustomerUpdatedEvent);
        }
    }
}
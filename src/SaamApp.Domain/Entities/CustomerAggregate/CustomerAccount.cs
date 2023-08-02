using System;
using System.ComponentModel.DataAnnotations;
using Ardalis.GuardClauses;
using SaamApp.Domain.Events;
using SaamAppLib.SharedKernel;
using SaamAppLib.SharedKernel.Interfaces;

namespace SaamApp.Domain.Entities
{
    public class CustomerAccount : BaseEntityEv<int>, IAggregateRoot
    {
        private CustomerAccount() { } // EF required

        //[SetsRequiredMembers]
        public CustomerAccount(Guid accountId, Guid customerId)
        {
            AccountId = Guard.Against.NullOrEmpty(accountId, nameof(accountId));
            CustomerId = Guard.Against.NullOrEmpty(customerId, nameof(customerId));
        }

        [Key] public int RowId { get; private set; }

        public virtual Account Account { get; private set; }

        public Guid AccountId { get; private set; }

        public virtual Customer Customer { get; private set; }

        public Guid CustomerId { get; private set; }


        public void UpdateAccountForCustomerAccount(Guid newAccountId)
        {
            Guard.Against.NullOrEmpty(newAccountId, nameof(newAccountId));
            if (newAccountId == AccountId)
            {
                return;
            }

            AccountId = newAccountId;
            var customerAccountUpdatedEvent = new CustomerAccountUpdatedEvent(this, "Mongo-History");
            Events.Add(customerAccountUpdatedEvent);
        }


        public void UpdateCustomerForCustomerAccount(Guid newCustomerId)
        {
            Guard.Against.NullOrEmpty(newCustomerId, nameof(newCustomerId));
            if (newCustomerId == CustomerId)
            {
                return;
            }

            CustomerId = newCustomerId;
            var customerAccountUpdatedEvent = new CustomerAccountUpdatedEvent(this, "Mongo-History");
            Events.Add(customerAccountUpdatedEvent);
        }
    }
}
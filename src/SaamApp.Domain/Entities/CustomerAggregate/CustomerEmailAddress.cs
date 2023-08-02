using System;
using System.ComponentModel.DataAnnotations;
using Ardalis.GuardClauses;
using SaamApp.Domain.Events;
using SaamAppLib.SharedKernel;
using SaamAppLib.SharedKernel.Interfaces;

namespace SaamApp.Domain.Entities
{
    public class CustomerEmailAddress : BaseEntityEv<int>, IAggregateRoot
    {
        private CustomerEmailAddress() { } // EF required

        //[SetsRequiredMembers]
        public CustomerEmailAddress(Guid customerId, Guid emailAddressId, Guid emailAddressTypeId)
        {
            CustomerId = Guard.Against.NullOrEmpty(customerId, nameof(customerId));
            EmailAddressId = Guard.Against.NullOrEmpty(emailAddressId, nameof(emailAddressId));
            EmailAddressTypeId = Guard.Against.NullOrEmpty(emailAddressTypeId, nameof(emailAddressTypeId));
        }

        [Key] public int RowId { get; private set; }

        public virtual Customer Customer { get; private set; }

        public Guid CustomerId { get; private set; }

        public virtual EmailAddress EmailAddress { get; private set; }

        public Guid EmailAddressId { get; private set; }

        public virtual EmailAddressType EmailAddressType { get; private set; }

        public Guid EmailAddressTypeId { get; private set; }


        public void UpdateCustomerForCustomerEmailAddress(Guid newCustomerId)
        {
            Guard.Against.NullOrEmpty(newCustomerId, nameof(newCustomerId));
            if (newCustomerId == CustomerId)
            {
                return;
            }

            CustomerId = newCustomerId;
            var customerEmailAddressUpdatedEvent = new CustomerEmailAddressUpdatedEvent(this, "Mongo-History");
            Events.Add(customerEmailAddressUpdatedEvent);
        }


        public void UpdateEmailAddressForCustomerEmailAddress(Guid newEmailAddressId)
        {
            Guard.Against.NullOrEmpty(newEmailAddressId, nameof(newEmailAddressId));
            if (newEmailAddressId == EmailAddressId)
            {
                return;
            }

            EmailAddressId = newEmailAddressId;
            var customerEmailAddressUpdatedEvent = new CustomerEmailAddressUpdatedEvent(this, "Mongo-History");
            Events.Add(customerEmailAddressUpdatedEvent);
        }


        public void UpdateEmailAddressTypeForCustomerEmailAddress(Guid newEmailAddressTypeId)
        {
            Guard.Against.NullOrEmpty(newEmailAddressTypeId, nameof(newEmailAddressTypeId));
            if (newEmailAddressTypeId == EmailAddressTypeId)
            {
                return;
            }

            EmailAddressTypeId = newEmailAddressTypeId;
            var customerEmailAddressUpdatedEvent = new CustomerEmailAddressUpdatedEvent(this, "Mongo-History");
            Events.Add(customerEmailAddressUpdatedEvent);
        }
    }
}
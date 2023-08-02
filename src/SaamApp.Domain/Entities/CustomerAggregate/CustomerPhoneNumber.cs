using System;
using System.ComponentModel.DataAnnotations;
using Ardalis.GuardClauses;
using SaamApp.Domain.Events;
using SaamAppLib.SharedKernel;
using SaamAppLib.SharedKernel.Interfaces;

namespace SaamApp.Domain.Entities
{
    public class CustomerPhoneNumber : BaseEntityEv<int>, IAggregateRoot
    {
        private CustomerPhoneNumber() { } // EF required

        //[SetsRequiredMembers]
        public CustomerPhoneNumber(Guid customerId, Guid phoneNumberId, Guid phoneNumberTypeId)
        {
            CustomerId = Guard.Against.NullOrEmpty(customerId, nameof(customerId));
            PhoneNumberId = Guard.Against.NullOrEmpty(phoneNumberId, nameof(phoneNumberId));
            PhoneNumberTypeId = Guard.Against.NullOrEmpty(phoneNumberTypeId, nameof(phoneNumberTypeId));
        }

        [Key] public int RowId { get; private set; }

        public virtual Customer Customer { get; private set; }

        public Guid CustomerId { get; private set; }

        public virtual PhoneNumber PhoneNumber { get; private set; }

        public Guid PhoneNumberId { get; private set; }

        public virtual PhoneNumberType PhoneNumberType { get; private set; }

        public Guid PhoneNumberTypeId { get; private set; }


        public void UpdateCustomerForCustomerPhoneNumber(Guid newCustomerId)
        {
            Guard.Against.NullOrEmpty(newCustomerId, nameof(newCustomerId));
            if (newCustomerId == CustomerId)
            {
                return;
            }

            CustomerId = newCustomerId;
            var customerPhoneNumberUpdatedEvent = new CustomerPhoneNumberUpdatedEvent(this, "Mongo-History");
            Events.Add(customerPhoneNumberUpdatedEvent);
        }


        public void UpdatePhoneNumberForCustomerPhoneNumber(Guid newPhoneNumberId)
        {
            Guard.Against.NullOrEmpty(newPhoneNumberId, nameof(newPhoneNumberId));
            if (newPhoneNumberId == PhoneNumberId)
            {
                return;
            }

            PhoneNumberId = newPhoneNumberId;
            var customerPhoneNumberUpdatedEvent = new CustomerPhoneNumberUpdatedEvent(this, "Mongo-History");
            Events.Add(customerPhoneNumberUpdatedEvent);
        }


        public void UpdatePhoneNumberTypeForCustomerPhoneNumber(Guid newPhoneNumberTypeId)
        {
            Guard.Against.NullOrEmpty(newPhoneNumberTypeId, nameof(newPhoneNumberTypeId));
            if (newPhoneNumberTypeId == PhoneNumberTypeId)
            {
                return;
            }

            PhoneNumberTypeId = newPhoneNumberTypeId;
            var customerPhoneNumberUpdatedEvent = new CustomerPhoneNumberUpdatedEvent(this, "Mongo-History");
            Events.Add(customerPhoneNumberUpdatedEvent);
        }
    }
}
using System;
using System.ComponentModel.DataAnnotations;
using Ardalis.GuardClauses;
using SaamApp.Domain.Events;
using SaamAppLib.SharedKernel;
using SaamAppLib.SharedKernel.Interfaces;

namespace SaamApp.Domain.Entities
{
    public class CustomerAddress : BaseEntityEv<int>, IAggregateRoot
    {
        private CustomerAddress() { } // EF required

        //[SetsRequiredMembers]
        public CustomerAddress(Guid addressId, Guid addressTypeId, Guid customerId)
        {
            AddressId = Guard.Against.NullOrEmpty(addressId, nameof(addressId));
            AddressTypeId = Guard.Against.NullOrEmpty(addressTypeId, nameof(addressTypeId));
            CustomerId = Guard.Against.NullOrEmpty(customerId, nameof(customerId));
        }

        [Key] public int RowId { get; private set; }

        public virtual Address Address { get; private set; }

        public Guid AddressId { get; private set; }

        public virtual AddressType AddressType { get; private set; }

        public Guid AddressTypeId { get; private set; }

        public virtual Customer Customer { get; private set; }

        public Guid CustomerId { get; private set; }


        public void UpdateAddressForCustomerAddress(Guid newAddressId)
        {
            Guard.Against.NullOrEmpty(newAddressId, nameof(newAddressId));
            if (newAddressId == AddressId)
            {
                return;
            }

            AddressId = newAddressId;
            var customerAddressUpdatedEvent = new CustomerAddressUpdatedEvent(this, "Mongo-History");
            Events.Add(customerAddressUpdatedEvent);
        }


        public void UpdateAddressTypeForCustomerAddress(Guid newAddressTypeId)
        {
            Guard.Against.NullOrEmpty(newAddressTypeId, nameof(newAddressTypeId));
            if (newAddressTypeId == AddressTypeId)
            {
                return;
            }

            AddressTypeId = newAddressTypeId;
            var customerAddressUpdatedEvent = new CustomerAddressUpdatedEvent(this, "Mongo-History");
            Events.Add(customerAddressUpdatedEvent);
        }


        public void UpdateCustomerForCustomerAddress(Guid newCustomerId)
        {
            Guard.Against.NullOrEmpty(newCustomerId, nameof(newCustomerId));
            if (newCustomerId == CustomerId)
            {
                return;
            }

            CustomerId = newCustomerId;
            var customerAddressUpdatedEvent = new CustomerAddressUpdatedEvent(this, "Mongo-History");
            Events.Add(customerAddressUpdatedEvent);
        }
    }
}
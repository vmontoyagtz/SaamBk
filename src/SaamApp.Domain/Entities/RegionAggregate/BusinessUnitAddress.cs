using System;
using System.ComponentModel.DataAnnotations;
using Ardalis.GuardClauses;
using SaamApp.Domain.Events;
using SaamAppLib.SharedKernel;
using SaamAppLib.SharedKernel.Interfaces;

namespace SaamApp.Domain.Entities
{
    public class BusinessUnitAddress : BaseEntityEv<int>, IAggregateRoot
    {
        private BusinessUnitAddress() { } // EF required

        //[SetsRequiredMembers]
        public BusinessUnitAddress(Guid addressId, Guid addressTypeId, Guid businessUnitId)
        {
            AddressId = Guard.Against.NullOrEmpty(addressId, nameof(addressId));
            AddressTypeId = Guard.Against.NullOrEmpty(addressTypeId, nameof(addressTypeId));
            BusinessUnitId = Guard.Against.NullOrEmpty(businessUnitId, nameof(businessUnitId));
        }

        [Key] public int RowId { get; private set; }

        public virtual Address Address { get; private set; }

        public Guid AddressId { get; private set; }

        public virtual AddressType AddressType { get; private set; }

        public Guid AddressTypeId { get; private set; }

        public virtual BusinessUnit BusinessUnit { get; private set; }

        public Guid BusinessUnitId { get; private set; }


        public void UpdateAddressForBusinessUnitAddress(Guid newAddressId)
        {
            Guard.Against.NullOrEmpty(newAddressId, nameof(newAddressId));
            if (newAddressId == AddressId)
            {
                return;
            }

            AddressId = newAddressId;
            var businessUnitAddressUpdatedEvent = new BusinessUnitAddressUpdatedEvent(this, "Mongo-History");
            Events.Add(businessUnitAddressUpdatedEvent);
        }


        public void UpdateAddressTypeForBusinessUnitAddress(Guid newAddressTypeId)
        {
            Guard.Against.NullOrEmpty(newAddressTypeId, nameof(newAddressTypeId));
            if (newAddressTypeId == AddressTypeId)
            {
                return;
            }

            AddressTypeId = newAddressTypeId;
            var businessUnitAddressUpdatedEvent = new BusinessUnitAddressUpdatedEvent(this, "Mongo-History");
            Events.Add(businessUnitAddressUpdatedEvent);
        }


        public void UpdateBusinessUnitForBusinessUnitAddress(Guid newBusinessUnitId)
        {
            Guard.Against.NullOrEmpty(newBusinessUnitId, nameof(newBusinessUnitId));
            if (newBusinessUnitId == BusinessUnitId)
            {
                return;
            }

            BusinessUnitId = newBusinessUnitId;
            var businessUnitAddressUpdatedEvent = new BusinessUnitAddressUpdatedEvent(this, "Mongo-History");
            Events.Add(businessUnitAddressUpdatedEvent);
        }
    }
}
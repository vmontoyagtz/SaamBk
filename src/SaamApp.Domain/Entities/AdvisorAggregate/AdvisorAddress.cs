using System;
using System.ComponentModel.DataAnnotations;
using Ardalis.GuardClauses;
using SaamApp.Domain.Events;
using SaamAppLib.SharedKernel;
using SaamAppLib.SharedKernel.Interfaces;

namespace SaamApp.Domain.Entities
{
    public class AdvisorAddress : BaseEntityEv<int>, IAggregateRoot
    {
        private AdvisorAddress() { } // EF required

        //[SetsRequiredMembers]
        public AdvisorAddress(Guid addressId, Guid addressTypeId, Guid advisorId)
        {
            AddressId = Guard.Against.NullOrEmpty(addressId, nameof(addressId));
            AddressTypeId = Guard.Against.NullOrEmpty(addressTypeId, nameof(addressTypeId));
            AdvisorId = Guard.Against.NullOrEmpty(advisorId, nameof(advisorId));
        }

        [Key] public int RowId { get; private set; }

        public virtual Address Address { get; private set; }

        public Guid AddressId { get; private set; }

        public virtual AddressType AddressType { get; private set; }

        public Guid AddressTypeId { get; private set; }

        public virtual Advisor Advisor { get; private set; }

        public Guid AdvisorId { get; private set; }


        public void UpdateAddressForAdvisorAddress(Guid newAddressId)
        {
            Guard.Against.NullOrEmpty(newAddressId, nameof(newAddressId));
            if (newAddressId == AddressId)
            {
                return;
            }

            AddressId = newAddressId;
            var advisorAddressUpdatedEvent = new AdvisorAddressUpdatedEvent(this, "Mongo-History");
            Events.Add(advisorAddressUpdatedEvent);
        }


        public void UpdateAddressTypeForAdvisorAddress(Guid newAddressTypeId)
        {
            Guard.Against.NullOrEmpty(newAddressTypeId, nameof(newAddressTypeId));
            if (newAddressTypeId == AddressTypeId)
            {
                return;
            }

            AddressTypeId = newAddressTypeId;
            var advisorAddressUpdatedEvent = new AdvisorAddressUpdatedEvent(this, "Mongo-History");
            Events.Add(advisorAddressUpdatedEvent);
        }


        public void UpdateAdvisorForAdvisorAddress(Guid newAdvisorId)
        {
            Guard.Against.NullOrEmpty(newAdvisorId, nameof(newAdvisorId));
            if (newAdvisorId == AdvisorId)
            {
                return;
            }

            AdvisorId = newAdvisorId;
            var advisorAddressUpdatedEvent = new AdvisorAddressUpdatedEvent(this, "Mongo-History");
            Events.Add(advisorAddressUpdatedEvent);
        }
    }
}
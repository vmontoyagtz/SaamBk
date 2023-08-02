using System;
using System.ComponentModel.DataAnnotations;
using Ardalis.GuardClauses;
using SaamApp.Domain.Events;
using SaamAppLib.SharedKernel;
using SaamAppLib.SharedKernel.Interfaces;

namespace SaamApp.Domain.Entities
{
    public class BusinessUnitPhoneNumber : BaseEntityEv<int>, IAggregateRoot
    {
        private BusinessUnitPhoneNumber() { } // EF required

        //[SetsRequiredMembers]
        public BusinessUnitPhoneNumber(Guid businessUnitId, Guid phoneNumberId, Guid phoneNumberTypeId)
        {
            BusinessUnitId = Guard.Against.NullOrEmpty(businessUnitId, nameof(businessUnitId));
            PhoneNumberId = Guard.Against.NullOrEmpty(phoneNumberId, nameof(phoneNumberId));
            PhoneNumberTypeId = Guard.Against.NullOrEmpty(phoneNumberTypeId, nameof(phoneNumberTypeId));
        }

        [Key] public int RowId { get; private set; }

        public virtual BusinessUnit BusinessUnit { get; private set; }

        public Guid BusinessUnitId { get; private set; }

        public virtual PhoneNumber PhoneNumber { get; private set; }

        public Guid PhoneNumberId { get; private set; }

        public virtual PhoneNumberType PhoneNumberType { get; private set; }

        public Guid PhoneNumberTypeId { get; private set; }


        public void UpdateBusinessUnitForBusinessUnitPhoneNumber(Guid newBusinessUnitId)
        {
            Guard.Against.NullOrEmpty(newBusinessUnitId, nameof(newBusinessUnitId));
            if (newBusinessUnitId == BusinessUnitId)
            {
                return;
            }

            BusinessUnitId = newBusinessUnitId;
            var businessUnitPhoneNumberUpdatedEvent = new BusinessUnitPhoneNumberUpdatedEvent(this, "Mongo-History");
            Events.Add(businessUnitPhoneNumberUpdatedEvent);
        }


        public void UpdatePhoneNumberForBusinessUnitPhoneNumber(Guid newPhoneNumberId)
        {
            Guard.Against.NullOrEmpty(newPhoneNumberId, nameof(newPhoneNumberId));
            if (newPhoneNumberId == PhoneNumberId)
            {
                return;
            }

            PhoneNumberId = newPhoneNumberId;
            var businessUnitPhoneNumberUpdatedEvent = new BusinessUnitPhoneNumberUpdatedEvent(this, "Mongo-History");
            Events.Add(businessUnitPhoneNumberUpdatedEvent);
        }


        public void UpdatePhoneNumberTypeForBusinessUnitPhoneNumber(Guid newPhoneNumberTypeId)
        {
            Guard.Against.NullOrEmpty(newPhoneNumberTypeId, nameof(newPhoneNumberTypeId));
            if (newPhoneNumberTypeId == PhoneNumberTypeId)
            {
                return;
            }

            PhoneNumberTypeId = newPhoneNumberTypeId;
            var businessUnitPhoneNumberUpdatedEvent = new BusinessUnitPhoneNumberUpdatedEvent(this, "Mongo-History");
            Events.Add(businessUnitPhoneNumberUpdatedEvent);
        }
    }
}
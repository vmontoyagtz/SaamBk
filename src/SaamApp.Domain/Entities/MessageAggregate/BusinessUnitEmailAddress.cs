using System;
using System.ComponentModel.DataAnnotations;
using Ardalis.GuardClauses;
using SaamApp.Domain.Events;
using SaamAppLib.SharedKernel;
using SaamAppLib.SharedKernel.Interfaces;

namespace SaamApp.Domain.Entities
{
    public class BusinessUnitEmailAddress : BaseEntityEv<int>, IAggregateRoot
    {
        private BusinessUnitEmailAddress() { } // EF required

        //[SetsRequiredMembers]
        public BusinessUnitEmailAddress(Guid businessUnitId, Guid emailAddressId, Guid emailAddressTypeId)
        {
            BusinessUnitId = Guard.Against.NullOrEmpty(businessUnitId, nameof(businessUnitId));
            EmailAddressId = Guard.Against.NullOrEmpty(emailAddressId, nameof(emailAddressId));
            EmailAddressTypeId = Guard.Against.NullOrEmpty(emailAddressTypeId, nameof(emailAddressTypeId));
        }

        [Key] public int RowId { get; private set; }

        public virtual BusinessUnit BusinessUnit { get; private set; }

        public Guid BusinessUnitId { get; private set; }

        public virtual EmailAddress EmailAddress { get; private set; }

        public Guid EmailAddressId { get; private set; }

        public virtual EmailAddressType EmailAddressType { get; private set; }

        public Guid EmailAddressTypeId { get; private set; }


        public void UpdateBusinessUnitForBusinessUnitEmailAddress(Guid newBusinessUnitId)
        {
            Guard.Against.NullOrEmpty(newBusinessUnitId, nameof(newBusinessUnitId));
            if (newBusinessUnitId == BusinessUnitId)
            {
                return;
            }

            BusinessUnitId = newBusinessUnitId;
            var businessUnitEmailAddressUpdatedEvent = new BusinessUnitEmailAddressUpdatedEvent(this, "Mongo-History");
            Events.Add(businessUnitEmailAddressUpdatedEvent);
        }


        public void UpdateEmailAddressForBusinessUnitEmailAddress(Guid newEmailAddressId)
        {
            Guard.Against.NullOrEmpty(newEmailAddressId, nameof(newEmailAddressId));
            if (newEmailAddressId == EmailAddressId)
            {
                return;
            }

            EmailAddressId = newEmailAddressId;
            var businessUnitEmailAddressUpdatedEvent = new BusinessUnitEmailAddressUpdatedEvent(this, "Mongo-History");
            Events.Add(businessUnitEmailAddressUpdatedEvent);
        }


        public void UpdateEmailAddressTypeForBusinessUnitEmailAddress(Guid newEmailAddressTypeId)
        {
            Guard.Against.NullOrEmpty(newEmailAddressTypeId, nameof(newEmailAddressTypeId));
            if (newEmailAddressTypeId == EmailAddressTypeId)
            {
                return;
            }

            EmailAddressTypeId = newEmailAddressTypeId;
            var businessUnitEmailAddressUpdatedEvent = new BusinessUnitEmailAddressUpdatedEvent(this, "Mongo-History");
            Events.Add(businessUnitEmailAddressUpdatedEvent);
        }
    }
}
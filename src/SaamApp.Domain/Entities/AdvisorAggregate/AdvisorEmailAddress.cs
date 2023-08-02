using System;
using System.ComponentModel.DataAnnotations;
using Ardalis.GuardClauses;
using SaamApp.Domain.Events;
using SaamAppLib.SharedKernel;
using SaamAppLib.SharedKernel.Interfaces;

namespace SaamApp.Domain.Entities
{
    public class AdvisorEmailAddress : BaseEntityEv<int>, IAggregateRoot
    {
        private AdvisorEmailAddress() { } // EF required

        //[SetsRequiredMembers]
        public AdvisorEmailAddress(Guid advisorId, Guid emailAddressId, Guid emailAddressTypeId)
        {
            AdvisorId = Guard.Against.NullOrEmpty(advisorId, nameof(advisorId));
            EmailAddressId = Guard.Against.NullOrEmpty(emailAddressId, nameof(emailAddressId));
            EmailAddressTypeId = Guard.Against.NullOrEmpty(emailAddressTypeId, nameof(emailAddressTypeId));
        }

        [Key] public int RowId { get; private set; }

        public virtual Advisor Advisor { get; private set; }

        public Guid AdvisorId { get; private set; }

        public virtual EmailAddress EmailAddress { get; private set; }

        public Guid EmailAddressId { get; private set; }

        public virtual EmailAddressType EmailAddressType { get; private set; }

        public Guid EmailAddressTypeId { get; private set; }


        public void UpdateAdvisorForAdvisorEmailAddress(Guid newAdvisorId)
        {
            Guard.Against.NullOrEmpty(newAdvisorId, nameof(newAdvisorId));
            if (newAdvisorId == AdvisorId)
            {
                return;
            }

            AdvisorId = newAdvisorId;
            var advisorEmailAddressUpdatedEvent = new AdvisorEmailAddressUpdatedEvent(this, "Mongo-History");
            Events.Add(advisorEmailAddressUpdatedEvent);
        }


        public void UpdateEmailAddressForAdvisorEmailAddress(Guid newEmailAddressId)
        {
            Guard.Against.NullOrEmpty(newEmailAddressId, nameof(newEmailAddressId));
            if (newEmailAddressId == EmailAddressId)
            {
                return;
            }

            EmailAddressId = newEmailAddressId;
            var advisorEmailAddressUpdatedEvent = new AdvisorEmailAddressUpdatedEvent(this, "Mongo-History");
            Events.Add(advisorEmailAddressUpdatedEvent);
        }


        public void UpdateEmailAddressTypeForAdvisorEmailAddress(Guid newEmailAddressTypeId)
        {
            Guard.Against.NullOrEmpty(newEmailAddressTypeId, nameof(newEmailAddressTypeId));
            if (newEmailAddressTypeId == EmailAddressTypeId)
            {
                return;
            }

            EmailAddressTypeId = newEmailAddressTypeId;
            var advisorEmailAddressUpdatedEvent = new AdvisorEmailAddressUpdatedEvent(this, "Mongo-History");
            Events.Add(advisorEmailAddressUpdatedEvent);
        }
    }
}
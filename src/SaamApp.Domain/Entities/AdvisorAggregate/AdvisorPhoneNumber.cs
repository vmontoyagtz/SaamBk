using System;
using System.ComponentModel.DataAnnotations;
using Ardalis.GuardClauses;
using SaamApp.Domain.Events;
using SaamAppLib.SharedKernel;
using SaamAppLib.SharedKernel.Interfaces;

namespace SaamApp.Domain.Entities
{
    public class AdvisorPhoneNumber : BaseEntityEv<int>, IAggregateRoot
    {
        private AdvisorPhoneNumber() { } // EF required

        //[SetsRequiredMembers]
        public AdvisorPhoneNumber(Guid advisorId, Guid phoneNumberId, Guid phoneNumberTypeId)
        {
            AdvisorId = Guard.Against.NullOrEmpty(advisorId, nameof(advisorId));
            PhoneNumberId = Guard.Against.NullOrEmpty(phoneNumberId, nameof(phoneNumberId));
            PhoneNumberTypeId = Guard.Against.NullOrEmpty(phoneNumberTypeId, nameof(phoneNumberTypeId));
        }

        [Key] public int RowId { get; private set; }

        public virtual Advisor Advisor { get; private set; }

        public Guid AdvisorId { get; private set; }

        public virtual PhoneNumber PhoneNumber { get; private set; }

        public Guid PhoneNumberId { get; private set; }

        public virtual PhoneNumberType PhoneNumberType { get; private set; }

        public Guid PhoneNumberTypeId { get; private set; }


        public void UpdateAdvisorForAdvisorPhoneNumber(Guid newAdvisorId)
        {
            Guard.Against.NullOrEmpty(newAdvisorId, nameof(newAdvisorId));
            if (newAdvisorId == AdvisorId)
            {
                return;
            }

            AdvisorId = newAdvisorId;
            var advisorPhoneNumberUpdatedEvent = new AdvisorPhoneNumberUpdatedEvent(this, "Mongo-History");
            Events.Add(advisorPhoneNumberUpdatedEvent);
        }


        public void UpdatePhoneNumberForAdvisorPhoneNumber(Guid newPhoneNumberId)
        {
            Guard.Against.NullOrEmpty(newPhoneNumberId, nameof(newPhoneNumberId));
            if (newPhoneNumberId == PhoneNumberId)
            {
                return;
            }

            PhoneNumberId = newPhoneNumberId;
            var advisorPhoneNumberUpdatedEvent = new AdvisorPhoneNumberUpdatedEvent(this, "Mongo-History");
            Events.Add(advisorPhoneNumberUpdatedEvent);
        }


        public void UpdatePhoneNumberTypeForAdvisorPhoneNumber(Guid newPhoneNumberTypeId)
        {
            Guard.Against.NullOrEmpty(newPhoneNumberTypeId, nameof(newPhoneNumberTypeId));
            if (newPhoneNumberTypeId == PhoneNumberTypeId)
            {
                return;
            }

            PhoneNumberTypeId = newPhoneNumberTypeId;
            var advisorPhoneNumberUpdatedEvent = new AdvisorPhoneNumberUpdatedEvent(this, "Mongo-History");
            Events.Add(advisorPhoneNumberUpdatedEvent);
        }
    }
}
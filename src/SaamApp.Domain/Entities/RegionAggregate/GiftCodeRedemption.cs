using System;
using System.ComponentModel.DataAnnotations;
using Ardalis.GuardClauses;
using SaamApp.Domain.Events;
using SaamAppLib.SharedKernel;
using SaamAppLib.SharedKernel.Interfaces;

namespace SaamApp.Domain.Entities
{
    public class GiftCodeRedemption : BaseEntityEv<Guid>, IAggregateRoot
    {
        private GiftCodeRedemption() { } // EF required

        //[SetsRequiredMembers]
        public GiftCodeRedemption(Guid giftCodeRedemptionId, Guid customerId, Guid giftCodeId,
            DateTime giftCodeRedemptionDate)
        {
            GiftCodeRedemptionId = Guard.Against.NullOrEmpty(giftCodeRedemptionId, nameof(giftCodeRedemptionId));
            CustomerId = Guard.Against.NullOrEmpty(customerId, nameof(customerId));
            GiftCodeId = Guard.Against.NullOrEmpty(giftCodeId, nameof(giftCodeId));
            GiftCodeRedemptionDate =
                Guard.Against.OutOfSQLDateRange(giftCodeRedemptionDate, nameof(giftCodeRedemptionDate));
        }

        [Key] public Guid GiftCodeRedemptionId { get; private set; }

        public DateTime GiftCodeRedemptionDate { get; private set; }

        public virtual Customer Customer { get; private set; }

        public Guid CustomerId { get; private set; }

        public virtual GiftCode GiftCode { get; private set; }

        public Guid GiftCodeId { get; private set; }


        public void UpdateCustomerForGiftCodeRedemption(Guid newCustomerId)
        {
            Guard.Against.NullOrEmpty(newCustomerId, nameof(newCustomerId));
            if (newCustomerId == CustomerId)
            {
                return;
            }

            CustomerId = newCustomerId;
            var giftCodeRedemptionUpdatedEvent = new GiftCodeRedemptionUpdatedEvent(this, "Mongo-History");
            Events.Add(giftCodeRedemptionUpdatedEvent);
        }


        public void UpdateGiftCodeForGiftCodeRedemption(Guid newGiftCodeId)
        {
            Guard.Against.NullOrEmpty(newGiftCodeId, nameof(newGiftCodeId));
            if (newGiftCodeId == GiftCodeId)
            {
                return;
            }

            GiftCodeId = newGiftCodeId;
            var giftCodeRedemptionUpdatedEvent = new GiftCodeRedemptionUpdatedEvent(this, "Mongo-History");
            Events.Add(giftCodeRedemptionUpdatedEvent);
        }
    }
}
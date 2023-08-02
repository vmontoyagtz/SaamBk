using System;
using System.ComponentModel.DataAnnotations;
using Ardalis.GuardClauses;
using SaamApp.Domain.Events;
using SaamAppLib.SharedKernel;
using SaamAppLib.SharedKernel.Interfaces;

namespace SaamApp.Domain.Entities
{
    public class DiscountCodeRedemption : BaseEntityEv<int>, IAggregateRoot
    {
        private DiscountCodeRedemption() { } // EF required

        //[SetsRequiredMembers]
        public DiscountCodeRedemption(Guid customerId, Guid discountCodeId, DateTime discountCodeRedemptionDate)
        {
            CustomerId = Guard.Against.NullOrEmpty(customerId, nameof(customerId));
            DiscountCodeId = Guard.Against.NullOrEmpty(discountCodeId, nameof(discountCodeId));
            DiscountCodeRedemptionDate =
                Guard.Against.OutOfSQLDateRange(discountCodeRedemptionDate, nameof(discountCodeRedemptionDate));
        }

        [Key] public int RowId { get; private set; }

        public DateTime DiscountCodeRedemptionDate { get; private set; }

        public virtual Customer Customer { get; private set; }

        public Guid CustomerId { get; private set; }

        public virtual DiscountCode DiscountCode { get; private set; }

        public Guid DiscountCodeId { get; private set; }


        public void UpdateCustomerForDiscountCodeRedemption(Guid newCustomerId)
        {
            Guard.Against.NullOrEmpty(newCustomerId, nameof(newCustomerId));
            if (newCustomerId == CustomerId)
            {
                return;
            }

            CustomerId = newCustomerId;
            var discountCodeRedemptionUpdatedEvent = new DiscountCodeRedemptionUpdatedEvent(this, "Mongo-History");
            Events.Add(discountCodeRedemptionUpdatedEvent);
        }


        public void UpdateDiscountCodeForDiscountCodeRedemption(Guid newDiscountCodeId)
        {
            Guard.Against.NullOrEmpty(newDiscountCodeId, nameof(newDiscountCodeId));
            if (newDiscountCodeId == DiscountCodeId)
            {
                return;
            }

            DiscountCodeId = newDiscountCodeId;
            var discountCodeRedemptionUpdatedEvent = new DiscountCodeRedemptionUpdatedEvent(this, "Mongo-History");
            Events.Add(discountCodeRedemptionUpdatedEvent);
        }
    }
}
using System;
using System.ComponentModel.DataAnnotations;
using Ardalis.GuardClauses;
using SaamApp.Domain.Events;
using SaamAppLib.SharedKernel;
using SaamAppLib.SharedKernel.Interfaces;

namespace SaamApp.Domain.Entities
{
    public class PrepaidPackageRedemption : BaseEntityEv<Guid>, IAggregateRoot
    {
        private PrepaidPackageRedemption() { } // EF required

        //[SetsRequiredMembers]
        public PrepaidPackageRedemption(Guid prepaidPackageRedemptionId, Guid customerId, Guid prepaidPackageId,
            decimal prepaidPackageAmount, DateTime prepaidPackageRedemptionDate)
        {
            PrepaidPackageRedemptionId =
                Guard.Against.NullOrEmpty(prepaidPackageRedemptionId, nameof(prepaidPackageRedemptionId));
            CustomerId = Guard.Against.NullOrEmpty(customerId, nameof(customerId));
            PrepaidPackageId = Guard.Against.NullOrEmpty(prepaidPackageId, nameof(prepaidPackageId));
            PrepaidPackageAmount = Guard.Against.Negative(prepaidPackageAmount, nameof(prepaidPackageAmount));
            PrepaidPackageRedemptionDate =
                Guard.Against.OutOfSQLDateRange(prepaidPackageRedemptionDate, nameof(prepaidPackageRedemptionDate));
        }

        [Key] public Guid PrepaidPackageRedemptionId { get; private set; }

        public decimal PrepaidPackageAmount { get; private set; }

        public DateTime PrepaidPackageRedemptionDate { get; private set; }

        public virtual Customer Customer { get; private set; }

        public Guid CustomerId { get; private set; }

        public virtual PrepaidPackage PrepaidPackage { get; private set; }

        public Guid PrepaidPackageId { get; private set; }


        public void UpdateCustomerForPrepaidPackageRedemption(Guid newCustomerId)
        {
            Guard.Against.NullOrEmpty(newCustomerId, nameof(newCustomerId));
            if (newCustomerId == CustomerId)
            {
                return;
            }

            CustomerId = newCustomerId;
            var prepaidPackageRedemptionUpdatedEvent = new PrepaidPackageRedemptionUpdatedEvent(this, "Mongo-History");
            Events.Add(prepaidPackageRedemptionUpdatedEvent);
        }


        public void UpdatePrepaidPackageForPrepaidPackageRedemption(Guid newPrepaidPackageId)
        {
            Guard.Against.NullOrEmpty(newPrepaidPackageId, nameof(newPrepaidPackageId));
            if (newPrepaidPackageId == PrepaidPackageId)
            {
                return;
            }

            PrepaidPackageId = newPrepaidPackageId;
            var prepaidPackageRedemptionUpdatedEvent = new PrepaidPackageRedemptionUpdatedEvent(this, "Mongo-History");
            Events.Add(prepaidPackageRedemptionUpdatedEvent);
        }
    }
}
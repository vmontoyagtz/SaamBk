using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Ardalis.GuardClauses;
using SaamApp.Domain.Events;
using SaamAppLib.SharedKernel;
using SaamAppLib.SharedKernel.Interfaces;

namespace SaamApp.Domain.Entities
{
    public class DiscountCode : BaseEntityEv<Guid>, IAggregateRoot
    {
        private readonly List<DiscountCodeRedemption> _discountCodeRedemptions = new();

        private readonly List<SerfinsaPayment> _serfinsaPayments = new();

        private DiscountCode() { } // EF required

        //[SetsRequiredMembers]
        public DiscountCode(Guid discountCodeId, Guid regionId, string discountCodeName, string discountCodeValue,
            decimal discountCodePercentage, DateTime discountCodeStartDate, DateTime? discountCodeEndDate,
            DateTime createdAt, Guid createdBy, DateTime? updatedAt, Guid? updatedBy, bool? isDeleted, Guid tenantId)
        {
            DiscountCodeId = Guard.Against.NullOrEmpty(discountCodeId, nameof(discountCodeId));
            RegionId = Guard.Against.NullOrEmpty(regionId, nameof(regionId));
            DiscountCodeName = Guard.Against.NullOrWhiteSpace(discountCodeName, nameof(discountCodeName));
            DiscountCodeValue = Guard.Against.NullOrWhiteSpace(discountCodeValue, nameof(discountCodeValue));
            DiscountCodePercentage = Guard.Against.Negative(discountCodePercentage, nameof(discountCodePercentage));
            DiscountCodeStartDate =
                Guard.Against.OutOfSQLDateRange(discountCodeStartDate, nameof(discountCodeStartDate));
            DiscountCodeEndDate = discountCodeEndDate;
            CreatedAt = Guard.Against.OutOfSQLDateRange(createdAt, nameof(createdAt));
            CreatedBy = Guard.Against.NullOrEmpty(createdBy, nameof(createdBy));
            UpdatedAt = updatedAt;
            UpdatedBy = updatedBy;
            IsDeleted = isDeleted;
            TenantId = Guard.Against.NullOrEmpty(tenantId, nameof(tenantId));
        }

        [Key] public Guid DiscountCodeId { get; private set; }

        public string DiscountCodeName { get; private set; }

        public string DiscountCodeValue { get; private set; }

        public decimal DiscountCodePercentage { get; private set; }

        public DateTime DiscountCodeStartDate { get; private set; }

        public DateTime? DiscountCodeEndDate { get; private set; }

        public DateTime CreatedAt { get; private set; }

        public Guid CreatedBy { get; private set; }

        public DateTime? UpdatedAt { get; private set; }

        public Guid? UpdatedBy { get; private set; }

        public bool? IsDeleted { get; private set; }

        public Guid TenantId { get; private set; }

        public virtual Region Region { get; private set; }

        public Guid RegionId { get; private set; }
        public IEnumerable<DiscountCodeRedemption> DiscountCodeRedemptions => _discountCodeRedemptions.AsReadOnly();
        public IEnumerable<SerfinsaPayment> SerfinsaPayments => _serfinsaPayments.AsReadOnly();

        public void SetDiscountCodeName(string discountCodeName)
        {
            DiscountCodeName = Guard.Against.NullOrEmpty(discountCodeName, nameof(discountCodeName));
        }

        public void SetDiscountCodeValue(string discountCodeValue)
        {
            DiscountCodeValue = Guard.Against.NullOrEmpty(discountCodeValue, nameof(discountCodeValue));
        }

        public void UpdateRegionForDiscountCode(Guid newRegionId)
        {
            Guard.Against.NullOrEmpty(newRegionId, nameof(newRegionId));
            if (newRegionId == RegionId)
            {
                return;
            }

            RegionId = newRegionId;
            var discountCodeUpdatedEvent = new DiscountCodeUpdatedEvent(this, "Mongo-History");
            Events.Add(discountCodeUpdatedEvent);
        }


        public void AddNewDiscountCodeRedemption(DateTime discountCodeRedemptionDate, Guid customerId,
            Guid discountCodeId)
        {
            Guard.Against.OutOfSQLDateRange(discountCodeRedemptionDate, nameof(discountCodeRedemptionDate));
            Guard.Against.NullOrEmpty(customerId, nameof(customerId));
            Guard.Against.NullOrEmpty(discountCodeId, nameof(discountCodeId));

            var newDiscountCodeRedemption =
                new DiscountCodeRedemption(customerId, discountCodeId, discountCodeRedemptionDate);
            Guard.Against.DuplicateDiscountCodeRedemption(_discountCodeRedemptions, newDiscountCodeRedemption,
                nameof(newDiscountCodeRedemption));
            _discountCodeRedemptions.Add(newDiscountCodeRedemption);
            var discountCodeRedemptionAddedEvent =
                new DiscountCodeRedemptionCreatedEvent(newDiscountCodeRedemption, "Mongo-History");
            Events.Add(discountCodeRedemptionAddedEvent);
        }

        public void DeleteDiscountCodeRedemption(DateTime discountCodeRedemptionDate, Guid customerId,
            Guid discountCodeId)
        {
            Guard.Against.OutOfSQLDateRange(discountCodeRedemptionDate, nameof(discountCodeRedemptionDate));
            Guard.Against.NullOrEmpty(customerId, nameof(customerId));
            Guard.Against.NullOrEmpty(discountCodeId, nameof(discountCodeId));

            var discountCodeRedemptionToDelete = _discountCodeRedemptions
                .Where(dcr1 => dcr1.DiscountCodeRedemptionDate == discountCodeRedemptionDate)
                .Where(dcr2 => dcr2.CustomerId == customerId)
                .Where(dcr3 => dcr3.DiscountCodeId == discountCodeId)
                .FirstOrDefault();

            if (discountCodeRedemptionToDelete != null)
            {
                _discountCodeRedemptions.Remove(discountCodeRedemptionToDelete);
                var discountCodeRedemptionDeletedEvent =
                    new DiscountCodeRedemptionDeletedEvent(discountCodeRedemptionToDelete, "Mongo-History");
                Events.Add(discountCodeRedemptionDeletedEvent);
            }
        }

        public void AddNewSerfinsaPayment(SerfinsaPayment serfinsaPayment)
        {
            Guard.Against.Null(serfinsaPayment, nameof(serfinsaPayment));
            Guard.Against.NullOrEmpty(serfinsaPayment.SerfinsaPaymentId, nameof(serfinsaPayment.SerfinsaPaymentId));
            Guard.Against.DuplicateSerfinsaPayment(_serfinsaPayments, serfinsaPayment, nameof(serfinsaPayment));
            _serfinsaPayments.Add(serfinsaPayment);
            var serfinsaPaymentAddedEvent = new SerfinsaPaymentCreatedEvent(serfinsaPayment, "Mongo-History");
            Events.Add(serfinsaPaymentAddedEvent);
        }

        public void DeleteSerfinsaPayment(SerfinsaPayment serfinsaPayment)
        {
            Guard.Against.Null(serfinsaPayment, nameof(serfinsaPayment));
            var serfinsaPaymentToDelete = _serfinsaPayments
                .Where(sp => sp.SerfinsaPaymentId == serfinsaPayment.SerfinsaPaymentId)
                .FirstOrDefault();
            if (serfinsaPaymentToDelete != null)
            {
                _serfinsaPayments.Remove(serfinsaPaymentToDelete);
                var serfinsaPaymentDeletedEvent =
                    new SerfinsaPaymentDeletedEvent(serfinsaPaymentToDelete, "Mongo-History");
                Events.Add(serfinsaPaymentDeletedEvent);
            }
        }
    }
}
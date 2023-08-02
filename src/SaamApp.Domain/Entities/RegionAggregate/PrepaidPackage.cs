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
    public class PrepaidPackage : BaseEntityEv<Guid>, IAggregateRoot
    {
        private readonly List<PrepaidPackageRedemption> _prepaidPackageRedemptions = new();

        private readonly List<SerfinsaPayment> _serfinsaPayments = new();

        private PrepaidPackage() { } // EF required

        //[SetsRequiredMembers]
        public PrepaidPackage(Guid prepaidPackageId, Guid regionId, string prepaidPackageName,
            decimal prepaidPackagePrice, bool? prepaidPackageIsActive, DateTime createdAt, Guid createdBy,
            DateTime? updatedAt, Guid? updatedBy, bool? isDeleted, Guid tenantId)
        {
            PrepaidPackageId = Guard.Against.NullOrEmpty(prepaidPackageId, nameof(prepaidPackageId));
            RegionId = Guard.Against.NullOrEmpty(regionId, nameof(regionId));
            PrepaidPackageName = Guard.Against.NullOrWhiteSpace(prepaidPackageName, nameof(prepaidPackageName));
            PrepaidPackagePrice = Guard.Against.Negative(prepaidPackagePrice, nameof(prepaidPackagePrice));
            PrepaidPackageIsActive = prepaidPackageIsActive;
            CreatedAt = Guard.Against.OutOfSQLDateRange(createdAt, nameof(createdAt));
            CreatedBy = Guard.Against.NullOrEmpty(createdBy, nameof(createdBy));
            UpdatedAt = updatedAt;
            UpdatedBy = updatedBy;
            IsDeleted = isDeleted;
            TenantId = Guard.Against.NullOrEmpty(tenantId, nameof(tenantId));
        }

        [Key] public Guid PrepaidPackageId { get; private set; }

        public string PrepaidPackageName { get; private set; }

        public decimal PrepaidPackagePrice { get; private set; }

        public bool? PrepaidPackageIsActive { get; private set; }

        public DateTime CreatedAt { get; private set; }

        public Guid CreatedBy { get; private set; }

        public DateTime? UpdatedAt { get; private set; }

        public Guid? UpdatedBy { get; private set; }

        public bool? IsDeleted { get; private set; }

        public Guid TenantId { get; private set; }

        public virtual Region Region { get; private set; }

        public Guid RegionId { get; private set; }

        public IEnumerable<PrepaidPackageRedemption> PrepaidPackageRedemptions =>
            _prepaidPackageRedemptions.AsReadOnly();

        public IEnumerable<SerfinsaPayment> SerfinsaPayments => _serfinsaPayments.AsReadOnly();

        public void SetPrepaidPackageName(string prepaidPackageName)
        {
            PrepaidPackageName = Guard.Against.NullOrEmpty(prepaidPackageName, nameof(prepaidPackageName));
        }

        public void UpdateRegionForPrepaidPackage(Guid newRegionId)
        {
            Guard.Against.NullOrEmpty(newRegionId, nameof(newRegionId));
            if (newRegionId == RegionId)
            {
                return;
            }

            RegionId = newRegionId;
            var prepaidPackageUpdatedEvent = new PrepaidPackageUpdatedEvent(this, "Mongo-History");
            Events.Add(prepaidPackageUpdatedEvent);
        }


        public void AddNewPrepaidPackageRedemption(PrepaidPackageRedemption prepaidPackageRedemption)
        {
            Guard.Against.Null(prepaidPackageRedemption, nameof(prepaidPackageRedemption));
            Guard.Against.NullOrEmpty(prepaidPackageRedemption.PrepaidPackageRedemptionId,
                nameof(prepaidPackageRedemption.PrepaidPackageRedemptionId));
            Guard.Against.DuplicatePrepaidPackageRedemption(_prepaidPackageRedemptions, prepaidPackageRedemption,
                nameof(prepaidPackageRedemption));
            _prepaidPackageRedemptions.Add(prepaidPackageRedemption);
            var prepaidPackageRedemptionAddedEvent =
                new PrepaidPackageRedemptionCreatedEvent(prepaidPackageRedemption, "Mongo-History");
            Events.Add(prepaidPackageRedemptionAddedEvent);
        }

        public void DeletePrepaidPackageRedemption(PrepaidPackageRedemption prepaidPackageRedemption)
        {
            Guard.Against.Null(prepaidPackageRedemption, nameof(prepaidPackageRedemption));
            var prepaidPackageRedemptionToDelete = _prepaidPackageRedemptions
                .Where(ppr => ppr.PrepaidPackageRedemptionId == prepaidPackageRedemption.PrepaidPackageRedemptionId)
                .FirstOrDefault();
            if (prepaidPackageRedemptionToDelete != null)
            {
                _prepaidPackageRedemptions.Remove(prepaidPackageRedemptionToDelete);
                var prepaidPackageRedemptionDeletedEvent =
                    new PrepaidPackageRedemptionDeletedEvent(prepaidPackageRedemptionToDelete, "Mongo-History");
                Events.Add(prepaidPackageRedemptionDeletedEvent);
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
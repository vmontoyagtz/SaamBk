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
    public class GiftCode : BaseEntityEv<Guid>, IAggregateRoot
    {
        private readonly List<GiftCodeRedemption> _giftCodeRedemptions = new();

        private GiftCode() { } // EF required

        //[SetsRequiredMembers]
        public GiftCode(Guid giftCodeId, Guid regionId, string? giftCodeName, string giftCodeValue,
            decimal giftCodeAmount, DateTime giftCodeStartDate, DateTime? giftCodeEndDate, DateTime createdAt,
            Guid createdBy, DateTime? updatedAt, Guid? updatedBy, bool? isDeleted, Guid tenantId)
        {
            GiftCodeId = Guard.Against.NullOrEmpty(giftCodeId, nameof(giftCodeId));
            RegionId = Guard.Against.NullOrEmpty(regionId, nameof(regionId));
            GiftCodeName = giftCodeName;
            GiftCodeValue = Guard.Against.NullOrWhiteSpace(giftCodeValue, nameof(giftCodeValue));
            GiftCodeAmount = Guard.Against.Negative(giftCodeAmount, nameof(giftCodeAmount));
            GiftCodeStartDate = Guard.Against.OutOfSQLDateRange(giftCodeStartDate, nameof(giftCodeStartDate));
            GiftCodeEndDate = giftCodeEndDate;
            CreatedAt = Guard.Against.OutOfSQLDateRange(createdAt, nameof(createdAt));
            CreatedBy = Guard.Against.NullOrEmpty(createdBy, nameof(createdBy));
            UpdatedAt = updatedAt;
            UpdatedBy = updatedBy;
            IsDeleted = isDeleted;
            TenantId = Guard.Against.NullOrEmpty(tenantId, nameof(tenantId));
        }

        [Key] public Guid GiftCodeId { get; private set; }

        public string? GiftCodeName { get; private set; }

        public string GiftCodeValue { get; private set; }

        public decimal GiftCodeAmount { get; private set; }

        public DateTime GiftCodeStartDate { get; private set; }

        public DateTime? GiftCodeEndDate { get; private set; }

        public DateTime CreatedAt { get; private set; }

        public Guid CreatedBy { get; private set; }

        public DateTime? UpdatedAt { get; private set; }

        public Guid? UpdatedBy { get; private set; }

        public bool? IsDeleted { get; private set; }

        public Guid TenantId { get; private set; }

        public virtual Region Region { get; private set; }

        public Guid RegionId { get; private set; }
        public IEnumerable<GiftCodeRedemption> GiftCodeRedemptions => _giftCodeRedemptions.AsReadOnly();

        public void SetGiftCodeName(string giftCodeName)
        {
            GiftCodeName = giftCodeName;
        }

        public void SetGiftCodeValue(string giftCodeValue)
        {
            GiftCodeValue = Guard.Against.NullOrEmpty(giftCodeValue, nameof(giftCodeValue));
        }

        public void UpdateRegionForGiftCode(Guid newRegionId)
        {
            Guard.Against.NullOrEmpty(newRegionId, nameof(newRegionId));
            if (newRegionId == RegionId)
            {
                return;
            }

            RegionId = newRegionId;
            var giftCodeUpdatedEvent = new GiftCodeUpdatedEvent(this, "Mongo-History");
            Events.Add(giftCodeUpdatedEvent);
        }


        public void AddNewGiftCodeRedemption(GiftCodeRedemption giftCodeRedemption)
        {
            Guard.Against.Null(giftCodeRedemption, nameof(giftCodeRedemption));
            Guard.Against.NullOrEmpty(giftCodeRedemption.GiftCodeRedemptionId,
                nameof(giftCodeRedemption.GiftCodeRedemptionId));
            Guard.Against.DuplicateGiftCodeRedemption(_giftCodeRedemptions, giftCodeRedemption,
                nameof(giftCodeRedemption));
            _giftCodeRedemptions.Add(giftCodeRedemption);
            var giftCodeRedemptionAddedEvent = new GiftCodeRedemptionCreatedEvent(giftCodeRedemption, "Mongo-History");
            Events.Add(giftCodeRedemptionAddedEvent);
        }

        public void DeleteGiftCodeRedemption(GiftCodeRedemption giftCodeRedemption)
        {
            Guard.Against.Null(giftCodeRedemption, nameof(giftCodeRedemption));
            var giftCodeRedemptionToDelete = _giftCodeRedemptions
                .Where(gcr => gcr.GiftCodeRedemptionId == giftCodeRedemption.GiftCodeRedemptionId)
                .FirstOrDefault();
            if (giftCodeRedemptionToDelete != null)
            {
                _giftCodeRedemptions.Remove(giftCodeRedemptionToDelete);
                var giftCodeRedemptionDeletedEvent =
                    new GiftCodeRedemptionDeletedEvent(giftCodeRedemptionToDelete, "Mongo-History");
                Events.Add(giftCodeRedemptionDeletedEvent);
            }
        }
    }
}
using System;
using System.ComponentModel.DataAnnotations;
using Ardalis.GuardClauses;
using SaamApp.Domain.Events;
using SaamAppLib.SharedKernel;
using SaamAppLib.SharedKernel.Interfaces;

namespace SaamApp.Domain.Entities
{
    public class AccountAdjustment : BaseEntityEv<Guid>, IAggregateRoot
    {
        private AccountAdjustment() { } // EF required

        //[SetsRequiredMembers]
        public AccountAdjustment(Guid accountAdjustmentId, Guid accountId, Guid accountAdjustmentRefId,
            decimal adjustmentReason, string? totalChargeCredited, long totalTaxCredited, DateTime createdAt,
            Guid createdBy, DateTime? updatedAt, Guid? updatedBy, bool? isDeleted)
        {
            AccountAdjustmentId = Guard.Against.NullOrEmpty(accountAdjustmentId, nameof(accountAdjustmentId));
            AccountId = Guard.Against.NullOrEmpty(accountId, nameof(accountId));
            AccountAdjustmentRefId = Guard.Against.NullOrEmpty(accountAdjustmentRefId, nameof(accountAdjustmentRefId));
            AdjustmentReason = Guard.Against.Negative(adjustmentReason, nameof(adjustmentReason));
            TotalChargeCredited = totalChargeCredited;
            TotalTaxCredited = Guard.Against.NegativeOrZero(totalTaxCredited, nameof(totalTaxCredited));
            CreatedAt = Guard.Against.OutOfSQLDateRange(createdAt, nameof(createdAt));
            CreatedBy = Guard.Against.NullOrEmpty(createdBy, nameof(createdBy));
            UpdatedAt = updatedAt;
            UpdatedBy = updatedBy;
            IsDeleted = isDeleted;
        }

        [Key] public Guid AccountAdjustmentId { get; private set; }

        public decimal AdjustmentReason { get; private set; }

        public string? TotalChargeCredited { get; private set; }

        public long TotalTaxCredited { get; private set; }

        public DateTime CreatedAt { get; private set; }

        public Guid CreatedBy { get; private set; }

        public DateTime? UpdatedAt { get; private set; }

        public Guid? UpdatedBy { get; private set; }

        public bool? IsDeleted { get; private set; }

        public virtual Account Account { get; private set; }

        public Guid AccountId { get; private set; }

        public virtual AccountAdjustmentRef AccountAdjustmentRef { get; private set; }

        public Guid AccountAdjustmentRefId { get; private set; }

        public void SetTotalChargeCredited(string totalChargeCredited)
        {
            TotalChargeCredited = totalChargeCredited;
        }

        public void UpdateAccountForAccountAdjustment(Guid newAccountId)
        {
            Guard.Against.NullOrEmpty(newAccountId, nameof(newAccountId));
            if (newAccountId == AccountId)
            {
                return;
            }

            AccountId = newAccountId;
            var accountAdjustmentUpdatedEvent = new AccountAdjustmentUpdatedEvent(this, "Mongo-History");
            Events.Add(accountAdjustmentUpdatedEvent);
        }


        public void UpdateAccountAdjustmentRefForAccountAdjustment(Guid newAccountAdjustmentRefId)
        {
            Guard.Against.NullOrEmpty(newAccountAdjustmentRefId, nameof(newAccountAdjustmentRefId));
            if (newAccountAdjustmentRefId == AccountAdjustmentRefId)
            {
                return;
            }

            AccountAdjustmentRefId = newAccountAdjustmentRefId;
            var accountAdjustmentUpdatedEvent = new AccountAdjustmentUpdatedEvent(this, "Mongo-History");
            Events.Add(accountAdjustmentUpdatedEvent);
        }
    }
}
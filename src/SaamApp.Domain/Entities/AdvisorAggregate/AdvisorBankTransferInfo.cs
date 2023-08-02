using System;
using System.ComponentModel.DataAnnotations;
using Ardalis.GuardClauses;
using SaamApp.Domain.Events;
using SaamAppLib.SharedKernel;
using SaamAppLib.SharedKernel.Interfaces;

namespace SaamApp.Domain.Entities
{
    public class AdvisorBankTransferInfo : BaseEntityEv<Guid>, IAggregateRoot
    {
        private AdvisorBankTransferInfo() { } // EF required

        //[SetsRequiredMembers]
        public AdvisorBankTransferInfo(Guid advisorBankTransferInfoId, Guid advisorId, Guid bankAccountId,
            string? bankTransferNotes, DateTime createdAt, Guid createdBy, DateTime? updatedAt, Guid? updatedBy,
            bool? isDeleted)
        {
            AdvisorBankTransferInfoId =
                Guard.Against.NullOrEmpty(advisorBankTransferInfoId, nameof(advisorBankTransferInfoId));
            AdvisorId = Guard.Against.NullOrEmpty(advisorId, nameof(advisorId));
            BankAccountId = Guard.Against.NullOrEmpty(bankAccountId, nameof(bankAccountId));
            BankTransferNotes = bankTransferNotes;
            CreatedAt = Guard.Against.OutOfSQLDateRange(createdAt, nameof(createdAt));
            CreatedBy = Guard.Against.NullOrEmpty(createdBy, nameof(createdBy));
            UpdatedAt = updatedAt;
            UpdatedBy = updatedBy;
            IsDeleted = isDeleted;
        }

        [Key] public Guid AdvisorBankTransferInfoId { get; private set; }

        public string? BankTransferNotes { get; private set; }

        public DateTime CreatedAt { get; private set; }

        public Guid CreatedBy { get; private set; }

        public DateTime? UpdatedAt { get; private set; }

        public Guid? UpdatedBy { get; private set; }

        public bool? IsDeleted { get; private set; }

        public virtual Advisor Advisor { get; private set; }

        public Guid AdvisorId { get; private set; }

        public virtual BankAccount BankAccount { get; private set; }

        public Guid BankAccountId { get; private set; }

        public void SetBankTransferNotes(string bankTransferNotes)
        {
            BankTransferNotes = bankTransferNotes;
        }

        public void UpdateAdvisorForAdvisorBankTransferInfo(Guid newAdvisorId)
        {
            Guard.Against.NullOrEmpty(newAdvisorId, nameof(newAdvisorId));
            if (newAdvisorId == AdvisorId)
            {
                return;
            }

            AdvisorId = newAdvisorId;
            var advisorBankTransferInfoUpdatedEvent = new AdvisorBankTransferInfoUpdatedEvent(this, "Mongo-History");
            Events.Add(advisorBankTransferInfoUpdatedEvent);
        }


        public void UpdateBankAccountForAdvisorBankTransferInfo(Guid newBankAccountId)
        {
            Guard.Against.NullOrEmpty(newBankAccountId, nameof(newBankAccountId));
            if (newBankAccountId == BankAccountId)
            {
                return;
            }

            BankAccountId = newBankAccountId;
            var advisorBankTransferInfoUpdatedEvent = new AdvisorBankTransferInfoUpdatedEvent(this, "Mongo-History");
            Events.Add(advisorBankTransferInfoUpdatedEvent);
        }
    }
}
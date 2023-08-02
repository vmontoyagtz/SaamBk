using System;
using System.ComponentModel.DataAnnotations;
using Ardalis.GuardClauses;
using SaamApp.Domain.Events;
using SaamAppLib.SharedKernel;
using SaamAppLib.SharedKernel.Interfaces;

namespace SaamApp.Domain.Entities
{
    public class AdvisorBank : BaseEntityEv<int>, IAggregateRoot
    {
        private AdvisorBank() { } // EF required

        //[SetsRequiredMembers]
        public AdvisorBank(Guid advisorId, Guid bankAccountId, bool isDefault)
        {
            AdvisorId = Guard.Against.NullOrEmpty(advisorId, nameof(advisorId));
            BankAccountId = Guard.Against.NullOrEmpty(bankAccountId, nameof(bankAccountId));
            IsDefault = Guard.Against.Null(isDefault, nameof(isDefault));
        }

        [Key] public int RowId { get; private set; }

        public bool IsDefault { get; private set; }

        public virtual Advisor Advisor { get; private set; }

        public Guid AdvisorId { get; private set; }

        public virtual BankAccount BankAccount { get; private set; }

        public Guid BankAccountId { get; private set; }


        public void UpdateAdvisorForAdvisorBank(Guid newAdvisorId)
        {
            Guard.Against.NullOrEmpty(newAdvisorId, nameof(newAdvisorId));
            if (newAdvisorId == AdvisorId)
            {
                return;
            }

            AdvisorId = newAdvisorId;
            var advisorBankUpdatedEvent = new AdvisorBankUpdatedEvent(this, "Mongo-History");
            Events.Add(advisorBankUpdatedEvent);
        }


        public void UpdateBankAccountForAdvisorBank(Guid newBankAccountId)
        {
            Guard.Against.NullOrEmpty(newBankAccountId, nameof(newBankAccountId));
            if (newBankAccountId == BankAccountId)
            {
                return;
            }

            BankAccountId = newBankAccountId;
            var advisorBankUpdatedEvent = new AdvisorBankUpdatedEvent(this, "Mongo-History");
            Events.Add(advisorBankUpdatedEvent);
        }
    }
}
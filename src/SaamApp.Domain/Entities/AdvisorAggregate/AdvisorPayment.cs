using System;
using System.ComponentModel.DataAnnotations;
using Ardalis.GuardClauses;
using SaamApp.Domain.Events;
using SaamAppLib.SharedKernel;
using SaamAppLib.SharedKernel.Interfaces;

namespace SaamApp.Domain.Entities
{
    public class AdvisorPayment : BaseEntityEv<int>, IAggregateRoot
    {
        private AdvisorPayment() { } // EF required

        //[SetsRequiredMembers]
        public AdvisorPayment(Guid advisorId, Guid bankAccountId, Guid paymentMethodId,
            string advisorPaymentDescription, decimal advisorPaymentsAmount, DateTime createdAt, Guid createdBy,
            DateTime? updatedAt, Guid? updatedBy, bool? isDeleted)
        {
            AdvisorId = Guard.Against.NullOrEmpty(advisorId, nameof(advisorId));
            BankAccountId = Guard.Against.NullOrEmpty(bankAccountId, nameof(bankAccountId));
            PaymentMethodId = Guard.Against.NullOrEmpty(paymentMethodId, nameof(paymentMethodId));
            AdvisorPaymentDescription =
                Guard.Against.NullOrWhiteSpace(advisorPaymentDescription, nameof(advisorPaymentDescription));
            AdvisorPaymentsAmount = Guard.Against.Negative(advisorPaymentsAmount, nameof(advisorPaymentsAmount));
            CreatedAt = Guard.Against.OutOfSQLDateRange(createdAt, nameof(createdAt));
            CreatedBy = Guard.Against.NullOrEmpty(createdBy, nameof(createdBy));
            UpdatedAt = updatedAt;
            UpdatedBy = updatedBy;
            IsDeleted = isDeleted;
        }

        [Key] public int RowId { get; private set; }

        public string AdvisorPaymentDescription { get; private set; }

        public decimal AdvisorPaymentsAmount { get; private set; }

        public DateTime CreatedAt { get; private set; }

        public Guid CreatedBy { get; private set; }

        public DateTime? UpdatedAt { get; private set; }

        public Guid? UpdatedBy { get; private set; }

        public bool? IsDeleted { get; private set; }

        public virtual Advisor Advisor { get; private set; }

        public Guid AdvisorId { get; private set; }

        public virtual BankAccount BankAccount { get; private set; }

        public Guid BankAccountId { get; private set; }

        public virtual PaymentMethod PaymentMethod { get; private set; }

        public Guid PaymentMethodId { get; private set; }

        public void SetAdvisorPaymentDescription(string advisorPaymentDescription)
        {
            AdvisorPaymentDescription =
                Guard.Against.NullOrEmpty(advisorPaymentDescription, nameof(advisorPaymentDescription));
        }

        public void UpdateAdvisorForAdvisorPayment(Guid newAdvisorId)
        {
            Guard.Against.NullOrEmpty(newAdvisorId, nameof(newAdvisorId));
            if (newAdvisorId == AdvisorId)
            {
                return;
            }

            AdvisorId = newAdvisorId;
            var advisorPaymentUpdatedEvent = new AdvisorPaymentUpdatedEvent(this, "Mongo-History");
            Events.Add(advisorPaymentUpdatedEvent);
        }


        public void UpdateBankAccountForAdvisorPayment(Guid newBankAccountId)
        {
            Guard.Against.NullOrEmpty(newBankAccountId, nameof(newBankAccountId));
            if (newBankAccountId == BankAccountId)
            {
                return;
            }

            BankAccountId = newBankAccountId;
            var advisorPaymentUpdatedEvent = new AdvisorPaymentUpdatedEvent(this, "Mongo-History");
            Events.Add(advisorPaymentUpdatedEvent);
        }


        public void UpdatePaymentMethodForAdvisorPayment(Guid newPaymentMethodId)
        {
            Guard.Against.NullOrEmpty(newPaymentMethodId, nameof(newPaymentMethodId));
            if (newPaymentMethodId == PaymentMethodId)
            {
                return;
            }

            PaymentMethodId = newPaymentMethodId;
            var advisorPaymentUpdatedEvent = new AdvisorPaymentUpdatedEvent(this, "Mongo-History");
            Events.Add(advisorPaymentUpdatedEvent);
        }
    }
}
using System;
using System.ComponentModel.DataAnnotations;
using Ardalis.GuardClauses;
using SaamApp.Domain.Events;
using SaamAppLib.SharedKernel;
using SaamAppLib.SharedKernel.Interfaces;

namespace SaamApp.Domain.Entities
{
    public class CustomerPurchase : BaseEntityEv<Guid>, IAggregateRoot
    {
        private CustomerPurchase() { } // EF required

        //[SetsRequiredMembers]
        public CustomerPurchase(Guid customerPurchaseId, Guid customerId, Guid referenceId,
            string referenceIdDescription, decimal transactionAmount, decimal customerPurchaseTotal, bool isPositive,
            bool isNegative, DateTime createdAt, Guid createdBy, DateTime? updatedAt, Guid? updatedBy, bool? isDeleted)
        {
            CustomerPurchaseId = Guard.Against.NullOrEmpty(customerPurchaseId, nameof(customerPurchaseId));
            CustomerId = Guard.Against.NullOrEmpty(customerId, nameof(customerId));
            ReferenceId = Guard.Against.NullOrEmpty(referenceId, nameof(referenceId));
            ReferenceIdDescription =
                Guard.Against.NullOrWhiteSpace(referenceIdDescription, nameof(referenceIdDescription));
            TransactionAmount = Guard.Against.Negative(transactionAmount, nameof(transactionAmount));
            CustomerPurchaseTotal = Guard.Against.Negative(customerPurchaseTotal, nameof(customerPurchaseTotal));
            IsPositive = Guard.Against.Null(isPositive, nameof(isPositive));
            IsNegative = Guard.Against.Null(isNegative, nameof(isNegative));
            CreatedAt = Guard.Against.OutOfSQLDateRange(createdAt, nameof(createdAt));
            CreatedBy = Guard.Against.NullOrEmpty(createdBy, nameof(createdBy));
            UpdatedAt = updatedAt;
            UpdatedBy = updatedBy;
            IsDeleted = isDeleted;
        }

        [Key] public Guid CustomerPurchaseId { get; private set; }

        public Guid ReferenceId { get; private set; }

        public string ReferenceIdDescription { get; private set; }

        public decimal TransactionAmount { get; private set; }

        public decimal CustomerPurchaseTotal { get; private set; }

        public bool IsPositive { get; private set; }

        public bool IsNegative { get; private set; }

        public DateTime CreatedAt { get; private set; }

        public Guid CreatedBy { get; private set; }

        public DateTime? UpdatedAt { get; private set; }

        public Guid? UpdatedBy { get; private set; }

        public bool? IsDeleted { get; private set; }

        public virtual Customer Customer { get; private set; }

        public Guid CustomerId { get; private set; }

        public void SetReferenceIdDescription(string referenceIdDescription)
        {
            ReferenceIdDescription = Guard.Against.NullOrEmpty(referenceIdDescription, nameof(referenceIdDescription));
        }

        public void UpdateCustomerForCustomerPurchase(Guid newCustomerId)
        {
            Guard.Against.NullOrEmpty(newCustomerId, nameof(newCustomerId));
            if (newCustomerId == CustomerId)
            {
                return;
            }

            CustomerId = newCustomerId;
            var customerPurchaseUpdatedEvent = new CustomerPurchaseUpdatedEvent(this, "Mongo-History");
            Events.Add(customerPurchaseUpdatedEvent);
        }
    }
}
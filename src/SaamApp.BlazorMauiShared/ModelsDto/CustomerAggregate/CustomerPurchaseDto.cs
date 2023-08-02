using System;
using System.ComponentModel.DataAnnotations;
using Ardalis.GuardClauses;

namespace SaamApp.Domain.ModelsDto
{
    public class CustomerPurchaseDto
    {
        public CustomerPurchaseDto() { } // AutoMapper required

        public CustomerPurchaseDto(Guid customerPurchaseId, Guid customerId, Guid referenceId,
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

        public Guid CustomerPurchaseId { get; set; }

        [Required(ErrorMessage = "Reference Id is required")]
        public Guid ReferenceId { get; set; }

        [Required(ErrorMessage = "Reference Id Description is required")]
        [MaxLength(100)]
        public string ReferenceIdDescription { get; set; }

        [Required(ErrorMessage = "Transaction Amount is required")]
        public decimal TransactionAmount { get; set; }

        [Required(ErrorMessage = "Customer Purchase Total is required")]
        public decimal CustomerPurchaseTotal { get; set; }

        [Required(ErrorMessage = "Is Positive is required")]
        public bool IsPositive { get; set; }

        [Required(ErrorMessage = "Is Negative is required")]
        public bool IsNegative { get; set; }

        [Required(ErrorMessage = "Created At is required")]
        public DateTime CreatedAt { get; set; }

        [Required(ErrorMessage = "Created By is required")]
        public Guid CreatedBy { get; set; }

        public DateTime? UpdatedAt { get; set; }

        public Guid? UpdatedBy { get; set; }

        public bool? IsDeleted { get; set; }

        public CustomerDto Customer { get; set; }

        [Required(ErrorMessage = "Customer is required")]
        public Guid CustomerId { get; set; }
    }
}
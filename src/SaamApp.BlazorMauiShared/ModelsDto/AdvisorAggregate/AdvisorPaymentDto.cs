using System;
using System.ComponentModel.DataAnnotations;
using Ardalis.GuardClauses;

namespace SaamApp.Domain.ModelsDto
{
    public class AdvisorPaymentDto
    {
        public AdvisorPaymentDto() { } // AutoMapper required

        public AdvisorPaymentDto(Guid advisorId, Guid bankAccountId, Guid paymentMethodId,
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

        public int RowId { get; set; }

        [Required(ErrorMessage = "Advisor Payment Description is required")]
        [MaxLength(100)]
        public string AdvisorPaymentDescription { get; set; }

        [Required(ErrorMessage = "Advisor Payments Amount is required")]
        public decimal AdvisorPaymentsAmount { get; set; }

        [Required(ErrorMessage = "Created At is required")]
        public DateTime CreatedAt { get; set; }

        [Required(ErrorMessage = "Created By is required")]
        public Guid CreatedBy { get; set; }

        public DateTime? UpdatedAt { get; set; }

        public Guid? UpdatedBy { get; set; }

        public bool? IsDeleted { get; set; }

        public AdvisorDto Advisor { get; set; }

        [Required(ErrorMessage = "Advisor is required")]
        public Guid AdvisorId { get; set; }

        public BankAccountDto BankAccount { get; set; }

        [Required(ErrorMessage = "Bank Account is required")]
        public Guid BankAccountId { get; set; }

        public PaymentMethodDto PaymentMethod { get; set; }

        [Required(ErrorMessage = "Payment Method is required")]
        public Guid PaymentMethodId { get; set; }
    }
}
using System;
using System.ComponentModel.DataAnnotations;
using Ardalis.GuardClauses;

namespace SaamApp.Domain.ModelsDto
{
    public class AdvisorBankTransferInfoDto
    {
        public AdvisorBankTransferInfoDto() { } // AutoMapper required

        public AdvisorBankTransferInfoDto(Guid advisorBankTransferInfoId, Guid advisorId, Guid bankAccountId,
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

        public Guid AdvisorBankTransferInfoId { get; set; }

        [MaxLength(100)] public string? BankTransferNotes { get; set; }

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
    }
}
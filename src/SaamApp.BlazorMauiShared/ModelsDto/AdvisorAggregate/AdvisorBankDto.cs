using System;
using System.ComponentModel.DataAnnotations;
using Ardalis.GuardClauses;

namespace SaamApp.Domain.ModelsDto
{
    public class AdvisorBankDto
    {
        public AdvisorBankDto() { } // AutoMapper required

        public AdvisorBankDto(Guid advisorId, Guid bankAccountId, bool isDefault)
        {
            AdvisorId = Guard.Against.NullOrEmpty(advisorId, nameof(advisorId));
            BankAccountId = Guard.Against.NullOrEmpty(bankAccountId, nameof(bankAccountId));
            IsDefault = Guard.Against.Null(isDefault, nameof(isDefault));
        }

        public int RowId { get; set; }

        [Required(ErrorMessage = "Is Default is required")]
        public bool IsDefault { get; set; }

        public AdvisorDto Advisor { get; set; }

        [Required(ErrorMessage = "Advisor is required")]
        public Guid AdvisorId { get; set; }

        public BankAccountDto BankAccount { get; set; }

        [Required(ErrorMessage = "Bank Account is required")]
        public Guid BankAccountId { get; set; }
    }
}
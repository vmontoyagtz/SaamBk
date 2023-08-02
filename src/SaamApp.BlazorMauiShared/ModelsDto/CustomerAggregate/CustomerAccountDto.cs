using System;
using System.ComponentModel.DataAnnotations;
using Ardalis.GuardClauses;

namespace SaamApp.Domain.ModelsDto
{
    public class CustomerAccountDto
    {
        public CustomerAccountDto() { } // AutoMapper required

        public CustomerAccountDto(Guid accountId, Guid customerId)
        {
            AccountId = Guard.Against.NullOrEmpty(accountId, nameof(accountId));
            CustomerId = Guard.Against.NullOrEmpty(customerId, nameof(customerId));
        }

        public int RowId { get; set; }

        public AccountDto Account { get; set; }

        [Required(ErrorMessage = "Account is required")]
        public Guid AccountId { get; set; }

        public CustomerDto Customer { get; set; }

        [Required(ErrorMessage = "Customer is required")]
        public Guid CustomerId { get; set; }
    }
}
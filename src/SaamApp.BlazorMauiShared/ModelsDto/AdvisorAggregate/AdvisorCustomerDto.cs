using System;
using System.ComponentModel.DataAnnotations;
using Ardalis.GuardClauses;

namespace SaamApp.Domain.ModelsDto
{
    public class AdvisorCustomerDto
    {
        public AdvisorCustomerDto() { } // AutoMapper required

        public AdvisorCustomerDto(Guid advisorId, Guid customerId)
        {
            AdvisorId = Guard.Against.NullOrEmpty(advisorId, nameof(advisorId));
            CustomerId = Guard.Against.NullOrEmpty(customerId, nameof(customerId));
        }

        public int RowId { get; set; }

        public AdvisorDto Advisor { get; set; }

        [Required(ErrorMessage = "Advisor is required")]
        public Guid AdvisorId { get; set; }

        public CustomerDto Customer { get; set; }

        [Required(ErrorMessage = "Customer is required")]
        public Guid CustomerId { get; set; }
    }
}
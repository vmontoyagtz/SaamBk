using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Ardalis.GuardClauses;

namespace SaamApp.Domain.ModelsDto
{
    public class PaymentFrequencyDto
    {
        public PaymentFrequencyDto() { } // AutoMapper required

        public PaymentFrequencyDto(Guid paymentFrequencyId, string paymentFrequencyName, string paymentFrequencyValue,
            Guid tenantId)
        {
            PaymentFrequencyId = Guard.Against.NullOrEmpty(paymentFrequencyId, nameof(paymentFrequencyId));
            PaymentFrequencyName = Guard.Against.NullOrWhiteSpace(paymentFrequencyName, nameof(paymentFrequencyName));
            PaymentFrequencyValue =
                Guard.Against.NullOrWhiteSpace(paymentFrequencyValue, nameof(paymentFrequencyValue));
            TenantId = Guard.Against.NullOrEmpty(tenantId, nameof(tenantId));
        }

        public Guid PaymentFrequencyId { get; set; }

        [Required(ErrorMessage = "Payment Frequency Name is required")]
        [MaxLength(100)]
        public string PaymentFrequencyName { get; set; }

        [Required(ErrorMessage = "Payment Frequency Value is required")]
        [MaxLength(100)]
        public string PaymentFrequencyValue { get; set; }

        [Required(ErrorMessage = "Tenant Id is required")]
        public Guid TenantId { get; set; }

        public List<AdvisorDto> Advisors { get; set; } = new();
    }
}